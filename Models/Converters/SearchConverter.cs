using System;
using System.Globalization;
using System.Windows.Data;

namespace BuildingWorks.Models.Converters
{
    public class SearchConverter : IMultiValueConverter
    {
        private const int PropertyNameIndex = 0;
        private const int ValueToCompareIndex = 1;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[PropertyNameIndex] != null || values[PropertyNameIndex] != null)
            {
                Tuple<string, string> conditionSource = new Tuple<string, string>
                (
                    values[PropertyNameIndex].ToString(),
                    values[ValueToCompareIndex].ToString()
                );

                return conditionSource;
            }
            else
            {
                return string.Empty;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { string.Empty };
        }
    }
}
