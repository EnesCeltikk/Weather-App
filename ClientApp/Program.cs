using Base;
using ClientApp.ServiceReference;
using System;
using System.Threading;
using System.Data.SqlClient;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DbInitializer.Initialize();
            Request Request = new Request();
            string CityName = "";
            Guid Guid = new Guid();
            ServiceClient Client = new ServiceClient("BasicHttpBinding_IService");
            ThreadManager MessageReceiver = new ThreadManager();
            Thread Thread = new Thread(MessageReceiver.MsmqReader);
            Thread.Start();
            Console.WriteLine("Sorgulamak için şehir adı giriniz: (Çıkmak için 0 giriniz)");
            while (CityName != "0")
            {
                CityName = Console.ReadLine();
                if (CityName == "0") break;
                Guid = Guid.NewGuid();
                try
                {
                    Request.CityName = CityName;
                    Request.Date = DateTime.Now;
                    Request.Status = Status.Waiting;
                    Request.Id = Guid;
                    Request.Save();
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Request modeli veritabanına kaydedilemedi", ex);
                }
                try
                {
                    if (Client.Query(Guid, CityName))
                    {
                        Console.WriteLine("Sorgu mesaj kuyruğuna yollandı");
                    }
                    else
                    {
                        Console.WriteLine("Sorgu mesaj kuyruğuna yollanamadı.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Query metodu çağrılamadı", ex);
                }

            }
            Console.WriteLine("Sorgu uygulaması kapatıldı.");
            Console.ReadKey();
        }
    }
}
