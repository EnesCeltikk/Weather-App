using Base;
using System;
using System.Threading;
using WcfService;

namespace ServiceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread Thread;
            MessageConsumer MessageSender = new MessageConsumer();
            Service Service = new Service();
            ServiceInstaller Host = ServiceInstaller.getSingletonObject();
            try
            {
                Console.WriteLine(Service.GetStatus());
            }
            catch
            {
                Console.WriteLine("Service Closed");
            }
            try
            {
                Thread = new Thread(MessageSender.Consume);
                Thread.Start();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
            Console.ReadKey();
        }
    }
}
