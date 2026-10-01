using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HumanBenchmark.Views.Converters;

public class LitToBrushConverter : IValueConverter
{
    public Brush LitBrush { get; set; } = Brushes.White;
    public Brush UnlitBrush { get; set; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#2574c1");
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool b && b)
        {
            return LitBrush;
        }
        return UnlitBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
