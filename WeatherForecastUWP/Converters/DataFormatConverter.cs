using System;
using Windows.UI.Xaml.Data;

namespace WeatherForecastUWP.Converters
{
    public class DataFormatConverter:  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;

            var date = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime().AddSeconds((int)value).ToString("dd/MM/yyyy");
            return date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
