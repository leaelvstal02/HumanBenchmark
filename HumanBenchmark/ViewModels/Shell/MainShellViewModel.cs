using HumanBenchmark.Commands;
using System.Windows.Input;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Shell;

[AddINotifyPropertyChangedInterface]
public class MainShellViewModel
{
    public ICommand ChangeTitleCommand { get; private set; }
    public string Title { get; set; }

    public MainShellViewModel()
    {
        Title = "Standardvärde";
        ChangeTitleCommand = new RelayCommand(p => ChangeTitle(p?.ToString() ?? Title)); //?? är en if-sats som kollar om parametern är null
    }

    private void ChangeTitle(string title)
    {
        Title = title;
    }
}
