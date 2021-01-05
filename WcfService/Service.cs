using System;
using System.Collections.Generic;

namespace WcfService
{
    public class Service : IService
    {
        public static Queue<object> MessageQueue = new Queue<object>();
        public Service()
        {

        }
        public string GetStatus()
        {
            return "Service Opened";
        }
        public bool Query(Guid id, string cityName)
        {
            try
            {
                MessageQueue.Enqueue(cityName + "$" + id);
                return true;
            }
            catch (Exception ex)
            {
                Base.Logger.Log.Error("Query çağrılırken beklenmeyen hata: ", ex);
                return false;
            }
        }
    }
}
