using HumanBenchmark.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace HumanBenchmark.Views.Converters;

public class FeedbackToBrushConverter : IValueConverter
{
    private static readonly SolidColorBrush Blue = Make("#2B87D1");
    private static readonly SolidColorBrush Red = Make("#FFDC3545");
    private static readonly SolidColorBrush LightBlue = Make("#B7D5F7");
    private static readonly SolidColorBrush Green = Make("#FF28A745");

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is FeedbackState state)
        {
            return state switch
            {
                FeedbackState.Wrong => Red,
                FeedbackState.Correct => Green,
                FeedbackState.Finished => LightBlue,
                FeedbackState.Neutral => Blue,
                _ => Blue
            };
        }
        return Blue;
        
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    private static SolidColorBrush Make(string hex)
    {
        var color = (Color)ColorConverter.ConvertFromString(hex);
        var b = new SolidColorBrush(color);
        return b;
    }
}
