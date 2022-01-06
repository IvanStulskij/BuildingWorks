using System;
using System.Globalization;
using System.Windows.Data;

namespace BuildingWorks.Models.Converters
{
    public class BuildingObjectConverter : IMultiValueConverter
    {
        private const int NameIndex = 0;
        private const int RegionIndex = 1;
        private const int TownIndex = 2;
        private const int StreetIndex = 3;
        private const int CustomerIndex = 4;
        private const int TypeIndex = 5;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Tuple<string, object, object, object, string, string> buildingObject = new Tuple<string, object, object, object, string, string>
                (
                    values[NameIndex].ToString(),
                    values[RegionIndex],
                    values[TownIndex],
                    values[StreetIndex],
                    values[CustomerIndex].ToString(),
                    values[TypeIndex].ToString()
                );

            return buildingObject;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { string.Empty };
        }
    }
}
