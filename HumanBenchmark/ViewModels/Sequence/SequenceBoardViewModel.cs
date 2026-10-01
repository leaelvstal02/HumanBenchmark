using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Sequence;

[AddINotifyPropertyChangedInterface]

public class SequenceBoardViewModel
{
    private List<int> _sequence = new();

    private int _playerProgress = 0;

    private readonly Random _random = new Random();
    public string Title { get; set; } = "Följ sekvensen";
    public ObservableCollection<PadViewModel> Pads { get; private set; } = new();

    public event Action? Mistake;

    public SequenceBoardViewModel()
    {
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
        await ToggleButton(index);
        if (index == _sequence[_playerProgress])
        {
            _playerProgress++;
            if (_playerProgress==_sequence.Count)
            {
                await OnPlayerCompletedAsync();
                await Task.Delay(500);
            }
        }
        else
        {
            Mistake?.Invoke();
        }
    }

    private async Task OnPlayerCompletedAsync()
    {
        AddRandomToSequence();
        await ShowSequence();
        await Task.Delay(800);
    }
}
