using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using HumanBenchmark.Commands;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Sequence;

[AddINotifyPropertyChangedInterface]

public class PadViewModel
{
    public int Id { get; private set; }
    public bool IsLit { get; set; }
    public ICommand ClickCommand { get; private set; }
    public PadViewModel(int id, Action<int> onClick)
    {
        Id = id;
        ClickCommand = new RelayCommand(_ => onClick(Id));
    }
}
