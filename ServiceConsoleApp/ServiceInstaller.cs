using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfService;

namespace ServiceConsoleApp
{
    public class ServiceInstaller
    {
        public Uri BaseAddress = new Uri("http://localhost:4501");
        public ServiceHost Host;
        private static ServiceInstaller m_SingletonObject;
        private ServiceInstaller()
        {
            OpenHost();
        }

        ~ServiceInstaller()
        {
            Host.Close();
            Console.WriteLine("Uygulamayı kapatmak için bir tuşa basınız.");
            Console.ReadKey();
        }

        public static ServiceInstaller getSingletonObject()
        {
            if (m_SingletonObject == null)
            {
                m_SingletonObject = new ServiceInstaller();
            }
            return m_SingletonObject;
        }

        public void OpenHost()
        {
            try
            {
                Host = new ServiceHost(typeof(Service), BaseAddress);
                Host.AddServiceEndpoint(typeof(IService), new BasicHttpBinding(), BaseAddress.ToString());

                ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;

                Host.Description.Behaviors.Add(metadataBehavior);
                Host.Open();
                //Console.WriteLine(m_Service.GetStatus(m_BaseAdress.ToString()));
            }
            catch (Exception ex)
            {
                Base.Logger.Log.Error("Servis kurulurken beklenmedik bir hata: ", ex);
            }
        }



    }
}

