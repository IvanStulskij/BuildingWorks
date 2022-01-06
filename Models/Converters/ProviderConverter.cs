using System;
using System.Globalization;
using System.Windows.Data;

namespace BuildingWorks.Models.Converters
{
    public class ProviderConverter : IMultiValueConverter
    {
        private const int NameIndex = 0;
        private const int CountryNameIndex = 1;
        private const int AdditionalDataIndex = 2;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Tuple<string, string, string> tuple = new Tuple<string, string, string>
            (
                values[NameIndex].ToString(),
                values[CountryNameIndex].ToString(),
                values[AdditionalDataIndex].ToString()
            );

            return tuple;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { string.Empty };
        }
    }
}
