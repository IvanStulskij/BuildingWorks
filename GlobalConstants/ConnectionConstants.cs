namespace BuildingWorks.GlobalConstants
{
    public static class ConnectionConstants
    {
        public const string ConnectionString = "server = " + Server + " port = " + Port + " database = "
            + Database + " user = " + User + " password = " + Password + " SSL Mode = " + SslState;

        public const string Server = "localhost;";
        public const string Port = "3306;";
        public const string Database = "buildingworks;";
        public const string User = "mysql;";
        public const string Password = "mysql;";
        public const string SslState = "None;";
    }
}
