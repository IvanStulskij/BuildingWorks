using System;
using System.Globalization;
using System.Windows.Data;

namespace BuildingWorks.Models.Converters
{
    public class WorkerConverter : IMultiValueConverter
    {
        private const int NameIndex = 0;
        private const int BrigadeIndex = 1;
        private const int WorkDateIndex = 2;
        private const int PostIndex = 3;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[WorkDateIndex] != null)
            {
                bool isCorrectDate = DateTime.TryParse(values[WorkDateIndex].ToString(), out DateTime startWorkDate);

                if (isCorrectDate)
                {
                    Tuple<string, object, DateTime, object> buildingObject = Tuple.Create
                    (
                        values[NameIndex].ToString(),
                        values[BrigadeIndex],
                        startWorkDate,
                        values[PostIndex]
                    );

                    return buildingObject;
                }
                
            }

            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
