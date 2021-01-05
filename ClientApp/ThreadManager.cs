using Base;
using System;
using System.Messaging;
using System.Threading;

namespace ClientApp
{
    public class ThreadManager
    {
        public void MsmqReader()
        {
            MSMQueue m_MessageManager = new MSMQueue(".\\Private$\\StajQueue");
            Message m_Message;
            Response m_Response;
            while (true)
            {
                try
                {
                    m_Message = m_MessageManager.Receive(TimeSpan.FromSeconds(20), typeof(Response));
                    if (m_Message.Body != null)
                    {
                        Console.WriteLine("Response modeli okunuyor.");
                        m_Response = (Response)m_Message.Body;
                        m_Response.Status = Status.Completed;
                        m_Response.Save();
                        Console.WriteLine("Response modeli okundu ve kaydedildi");
                        Console.WriteLine(m_Response.CityName + " Sıcaklık değeri: " + m_Response.Temp.ToString() +
                            "\nNem değeri: " + m_Response.Humidity.ToString() +
                            "\nBasınç değeri:" + m_Response.Pressure.ToString() +
                            "\nSorgulamak için şehir adı giriniz: (Çıkmak için 0 giriniz)");
                    }

                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.Log.Error("Response modeli MSMQ'dan okunurken beklenmedik bir hata oluştu.", ex);
                    }
                    //TODO: Log kaydı alınacak
                }
                Thread.Sleep(3000);
            }
        }
    }
}
