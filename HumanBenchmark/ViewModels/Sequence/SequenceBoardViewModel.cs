using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using HumanBenchmark.Commands;
using HumanBenchmark.Enums;
using HumanBenchmark.ViewModels.Common;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Sequence;

[AddINotifyPropertyChangedInterface]

public class SequenceBoardViewModel : ISupportPadInput
{
    private List<int> _sequence = new();

    private int _playerProgress = 0;

    private readonly Random _random = new Random();
    public string Title { get; set; } = "Följ sekvensen";
    public ObservableCollection<PadViewModel> Pads { get; private set; } = new();

    public FeedbackState Feedback { get; set; } = FeedbackState.Neutral;

    public ICommand PressPadIndexCommand { get; }
    public event Action<int>? Mistake;

    public SequenceBoardViewModel()
    {
        PressPadIndexCommand = new RelayCommand(parameter => 
        {
            if (parameter is null)
            {
                return;
            }
            OnButtonClicked(Convert.ToInt32(parameter));
        });
        ConfigurePads();
    }

    public async Task StartNewGameAsync()
    {
        _playerProgress = 0;
        _sequence.Clear();
        AddRandomToSequence();
        await ShowSequence();
    }

    private void AddRandomToSequence()
    {
        int next = _random.Next(0, 9);
        _sequence.Add(next);
    }

    private async Task ShowSequence()
    {
        var snapshot = _sequence.ToArray();
        foreach (var index in snapshot)
        {
            await ToggleButton(index);
        }
        _playerProgress = 0;
    }

    private async Task ToggleButton(int index, int delay=350)
    {
        Pads[index].IsLit = true;
        await Task.Delay(delay);
        Pads[index].IsLit = false;
    }

    private void ConfigurePads()
    {
        for (int i = 0; i < 9; i++)
        {
            Pads.Add(new PadViewModel(i, OnButtonClicked));
        }
    }

    private async void OnButtonClicked(int index)
    {
        await ToggleButton(index, 100);
        if (index == _sequence[_playerProgress])
        {
            _playerProgress++;
            if (_playerProgress == _sequence.Count)
            {
                await OnPlayerCompletedAsync();
                await ShowSequence();
            }
        }
        else
        {
            Feedback = FeedbackState.Wrong;
            await Task.Delay(800);
            Feedback = FeedbackState.Correct;
            Mistake?.Invoke(_playerProgress);
        }
    }

    private async Task OnPlayerCompletedAsync()
    {
        AddRandomToSequence();
        Feedback = FeedbackState.Finished;
        await Task.Delay(500);
        Feedback = FeedbackState.Neutral;
    }
}
