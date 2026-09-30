using HumanBenchmark.Commands;
using System.Windows.Input;
using PropertyChanged;
using HumanBenchmark.ViewModels.Sequence;

namespace HumanBenchmark.ViewModels.Shell;

[AddINotifyPropertyChangedInterface]
public class MainShellViewModel
{
    public object CurrentGame { get; set; } = new SequenceGameViewModel();
    public string Title { get; set; }

    public MainShellViewModel()
    {
        Title = "Standardvärde";
    }

    private void ChangeTitle(string title)
    {
        Title = title;
    }
}
