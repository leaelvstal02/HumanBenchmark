using HumanBenchmark.Commands;
using System.Windows.Input;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Sequence;

[AddINotifyPropertyChangedInterface]
public class SequenceGameViewModel
{
    public ICommand ChangeTitleCommand { get; private set; }
    public SequenceBoardViewModel GameViewModel { get; private set; } = new();
    public SequenceEndViewModel EndViewModel { get; private set; }
    public SequenceStartViewModel StartViewModel { get; private set; }
    public object Screen { get; set; }
    public string Title { get; set; }
    public SequenceGameViewModel()
    {
        ChangeTitleCommand = new RelayCommand(_ => Title = "Sequence game"); //(p => ChangeTitle(p?.ToString() ?? Title)); //?? är en if-sats som kollar om parametern är null
        StartViewModel = new SequenceStartViewModel(new RelayCommand(async _ => await StartAsync()));
        GameViewModel.Mistake += async () =>
        {
            Screen = EndViewModel;
        };

        EndViewModel = new SequenceEndViewModel(
            saveScoreCommand: new RelayCommand(async _ => await SaveScoreAsync()),
            restartCommand: new RelayCommand(async _ => await StartAsync())
            );

        Screen = StartViewModel;
    }

    private async Task SaveScoreAsync()
    {

    }

    public async Task StartAsync()
    {
        Screen = GameViewModel;
        await GameViewModel.StartNewGameAsync();
    }
}
