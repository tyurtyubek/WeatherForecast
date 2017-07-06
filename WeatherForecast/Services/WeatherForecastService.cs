using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public class WeatherForecastService
    {
        //private WeatherInfo weatherInfo;

        //public WeatherInfoService()
        //{
        //    weatherInfo = new WeatherInfo();
        //}

        //public WeatherInfo GetInfos()
        //{
        //    return weatherInfo;
        //}

        //public object GetInfoByCity(string cityName, int countDays)
        //{
        //    WeekWeatherInfo rootObject = new WeekWeatherInfo();
        //    if (cityName != null)
        //    {
        //        /*Calling API http://openweathermap.org/api */
        //        string apiKey = "af9f860fa9d00a8c953339a9a354d6b4";
        //        HttpWebRequest apiRequest =
        //            WebRequest.Create($"http://api.openweathermap.org/data/2.5/forecast/daily?q={cityName}&appid={apiKey}&units=metric&cnt={countDays}") as HttpWebRequest;

        //        string apiResponse = "";
        //        using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
        //        {
        //            StreamReader reader = new StreamReader(response.GetResponseStream());
        //            apiResponse = reader.ReadToEnd();
        //        }
        //        /*End*/

        //        /*http://json2csharp.com*/
        //        rootObject = JsonConvert.DeserializeObject<WeekWeatherInfo>(apiResponse);
        //    }

        //    return rootObject;
        //}

        public Forecast Get(string city, int days)
        {

            string path = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&units=metric&APPID=030e0de55deb68d47090aec778996d58";

            WebClient client = new WebClient();
            try
            {
                string jsonInfo = @"" + (client.DownloadString(path)).Replace('"', '\'');

                Forecast forecast = new Forecast(JsonConvert.DeserializeObject<RootObject>(jsonInfo));
                forecast.SetDays(days);
                return forecast;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
