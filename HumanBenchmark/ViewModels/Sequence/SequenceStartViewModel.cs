using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HumanBenchmark.ViewModels.Sequence;

public class SequenceStartViewModel
{
    public ICommand StartCommand { get; private set; }

    public SequenceStartViewModel(ICommand startCommand)
    {
        StartCommand = startCommand;
    }
}
