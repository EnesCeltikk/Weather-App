using Base;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WeatherApiManager
{
    public static class ApiHelper
    {
        private static string m_ApiKey = "41311c811adf12a7a038f6aa8582776b";
        private static HttpWebRequest m_HttpWebRequest;
        private static HttpWebResponse m_HttpWebResponse;
        private static StreamReader m_Reader;
        public static JsonResponse.ResponseWeather GetJsonResponse(string CityName)
        {
            m_HttpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=" + CityName + "&appid=" + m_ApiKey + "&units=metric&lang=TR");
            m_HttpWebResponse = m_HttpWebRequest.GetResponse() as HttpWebResponse;
            using (m_HttpWebResponse as HttpWebResponse)
            {
                m_Reader = new StreamReader(m_HttpWebResponse.GetResponseStream());
                return JsonConvert.DeserializeObject<JsonResponse.ResponseWeather>(m_Reader.ReadToEnd());

            }
        }
    }
}
