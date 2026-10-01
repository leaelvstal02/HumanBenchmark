using HumanBenchmark.Commands;
using System.Windows.Input;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Sequence;

[AddINotifyPropertyChangedInterface]
public class SequenceGameViewModel
{
    public ICommand ChangeTitleCommand { get; private set; }
    public SequenceBoardViewModel GameViewModel { get; private set; } = new();
    public object Screen { get; set; }
    public string Title { get; set; }
    public SequenceGameViewModel()
    {
        ChangeTitleCommand = new RelayCommand(_ => Title = "Sequence game"); //(p => ChangeTitle(p?.ToString() ?? Title)); //?? är en if-sats som kollar om parametern är null
        Screen = GameViewModel;
        GameViewModel.StartNewGame();
    }
}
