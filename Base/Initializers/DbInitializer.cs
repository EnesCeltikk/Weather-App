using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;


namespace Base
{
    public static class DbInitializer
    {
        public static IConfigurationSource Source = System.Configuration.ConfigurationManager.GetSection("activerecord") as IConfigurationSource;
        public static void Initialize()
        {
            if (TestFlags.DbInitializeTestFlag == false)
            {
                ActiveRecordStarter.Initialize(Source, typeof(Request), typeof(Response));
            }
        }
    }
}
