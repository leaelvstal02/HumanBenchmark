using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HumanBenchmark.ViewModels.Sequence;

public class SequenceEndViewModel
{
    public ICommand SaveScoreCommand { get; }
    public ICommand RestartCommand { get; }
    public int Level { get; set; }

    public SequenceEndViewModel(ICommand saveScoreCommand, ICommand restartCommand)
    {
        SaveScoreCommand = saveScoreCommand;
        RestartCommand = restartCommand;
    }
}
