using Base;
using System;
using System.Threading;
using WeatherApiManager;

namespace WcfService
{
    //TODO: Yapıcı sınıf oluştur, config işlemlerini orda yap
    public class MessageConsumer
    {
        private MSMQueue m_MessageManager = new MSMQueue(".\\Private$\\StajQueue");
        public string CityName = "";
        public Guid RequestGuid = new Guid();
        private object m_Message;
        public Response ResponseModel;
        private JsonResponse.ResponseWeather m_ApiResponseJson;
        public MessageConsumer()
        {
            Base.AutoMapperConfig.Initialize();
            Base.DbInitializer.Initialize();
        }

        public void Consume()
        {
            while (true)
            {
                if (Service.MessageQueue.Count > 0)
                {
                    Console.WriteLine("Mesaj okunuyor");
                    m_Message = Service.MessageQueue.Dequeue();
                    CityName = m_Message.ToString().Substring(0, m_Message.ToString().IndexOf("$"));
                    RequestGuid = Guid.Parse(m_Message.ToString().Substring(m_Message.ToString().IndexOf("$") + 1));
                    if(TestFlags.MessageConsume_QueueTestFlag==true)
                    {
                        return;
                    }
                    Console.WriteLine("Mesaj okundu");
                    try
                    {
                        m_ApiResponseJson = ApiHelper.GetJsonResponse(CityName);
                        try
                        {
                            ResponseModel = Base.AutoMapperConfig.Mapper.Map<JsonResponse.ResponseWeather, Response>(m_ApiResponseJson);
                            ResponseModel.Id = Guid.NewGuid();
                            ResponseModel.Status = Status.Querying;
                            ResponseModel.Request = Request.Find(RequestGuid);
                            
                        }
                        catch (Exception ex)
                        {
                            Logger.Log.Error("Response modeli oluşturulamadı", ex);
                        }
                        try
                        {
                            SendMessage(ResponseModel);
                            Service.MessageQueue.Clear();
                        }
                        catch (Exception ex)
                        {
                            Logger.Log.Error("Response modeli MSMQ'ya aktarılırken hata", ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("API'dan cevap alınırken beklenmedik bir hata oluştu, Şehir ismini kontrol edin ve tekrar girmeyi deneyin..");
                        Logger.Log.Warn(ex);
                    }

                }
                Thread.Sleep(2000);
            }
        }
        public void SendMessage(Response response)
        {
            m_MessageManager.Send(response);
        }
    }
}
