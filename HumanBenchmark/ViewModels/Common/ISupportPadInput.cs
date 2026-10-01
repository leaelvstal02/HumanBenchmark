using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HumanBenchmark.ViewModels.Common;

public interface ISupportPadInput
{
    public ICommand PressPadIndexCommand { get; }
}
