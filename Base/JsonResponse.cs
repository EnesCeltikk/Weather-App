﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Base
{
    public class JsonResponse
    {
        public class Coord
        {
            [JsonProperty("lon")]
            public double Longitude { get; set; }

            [JsonProperty("lat")]
            public double Latitude { get; set; }
        }

        public class Weather
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("main")]
            public string Main { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }
        }

        public class Main
        {
            [JsonProperty("temp")]
            public double Temp { get; set; }

            [JsonProperty("pressure")]
            public int Pressure { get; set; }

            [JsonProperty("humidity")]
            public int Humidity { get; set; }

            [JsonProperty("temp_min")]
            public double MinTemp { get; set; }

            [JsonProperty("temp_max")]
            public double MaxTemp { get; set; }
        }

        public class Wind
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }

            [JsonProperty("deg")]
            public int Degree { get; set; }
        }

        public class Clouds
        {
            [JsonProperty("all")]
            public int All { get; set; }
        }

        public class Sys
        {
            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("message")]
            public double Message { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("sunrise")]
            public int Sunrise { get; set; }

            [JsonProperty("sunset")]
            public int Sunset { get; set; }
        }

        public class ResponseWeather
        {
            [JsonProperty("coord")]
            public Coord Coord { get; set; }

            [JsonProperty("weather")]
            public List<Weather> Weather { get; set; }

            [JsonProperty("base")]
            public string Base { get; set; }

            [JsonProperty("main")]
            public Main Main { get; set; }

            [JsonProperty("visibility")]
            public int Visibility { get; set; }

            [JsonProperty("wind")]
            public Wind Wind { get; set; }

            [JsonProperty("clouds")]
            public Clouds Clouds { get; set; }

            [JsonProperty("dt")]
            public int Dt { get; set; }

            [JsonProperty("sys")]
            public Sys Sys { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("cod")]
            public int Cod { get; set; }


        }
    }
}
