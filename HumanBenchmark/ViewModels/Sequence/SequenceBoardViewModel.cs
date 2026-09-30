using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PropertyChanged;

namespace HumanBenchmark.ViewModels.Sequence;

[AddINotifyPropertyChangedInterface]

public class SequenceBoardViewModel
{
    public string Title { get; set; } = "Följ sekvensen";
    public ObservableCollection<PadViewModel> Pads { get; private set; } = new();

    public SequenceBoardViewModel()
    {
        ConfigurePads();
    }


    private void ConfigurePads()
    {
        for (int i = 0; i < 9; i++)
        {
            Pads.Add(new PadViewModel(i, OnButtonClicked));
        }
    }

    private void OnButtonClicked(int index)
    {

    }
}
