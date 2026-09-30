using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Sequence;

[AddINotifyPropertyChangedInterface]

public class SequenceBoardViewModel
{
    public string Title { get; set; } = "Följ sekvensen";
}
