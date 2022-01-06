namespace BuildingWorks.Models.Databasable
{
    public class TemplateConditionalSelectQuery
    {
        private readonly string _tableName;
        private readonly string _valueToCompare;
        private readonly string _propertyName;

        public TemplateConditionalSelectQuery(string tableName, string propertyName, string valueToCompare)
        {
            _tableName = tableName;
            _valueToCompare = valueToCompare;
            _propertyName = propertyName;
        }
        
        public string Query {
            get
            {
                if (_propertyName != null || _valueToCompare != null)
                {
                    return $"select * from {_tableName} where {_propertyName} = '{_valueToCompare}';";
                }
                else
                {
                    return $"select * from {_tableName};";
                }
            }
            private set
            {

            }
        }
    }
}
