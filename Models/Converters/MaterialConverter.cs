using System;
using System.Globalization;
using System.Windows.Data;

namespace BuildingWorks.Models.Converters
{
    public class MaterialConverter : IMultiValueConverter
    {
        private const int NameIndex = 0;
        private const int PriceIndex = 1;
        private const int MeasureIndex = 2;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCorrect = decimal.TryParse(values[PriceIndex].ToString(), out decimal price);

            if (values[PriceIndex].ToString() != string.Empty && isCorrect)
            {
                Tuple<string, decimal, string> dataToAdd = Tuple.Create(
                    values[NameIndex].ToString(),
                    price,
                    values[MeasureIndex].ToString()
                );

                return dataToAdd;
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
