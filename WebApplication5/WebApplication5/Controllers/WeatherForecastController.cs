using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlTypes;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetCoins")]
        public string Get()
        {
            List<ExchangeRateResponseDTO> exchangeRateResponseDTO = new List<ExchangeRateResponseDTO>();
            String URLString = "https://boi.org.il/PublicApi/GetExchangeRates?asXML=true";
            XmlTextReader reader = new XmlTextReader(URLString);
            int i = 0;
            double CurrentChange=0;
            double CurrentExchangeRate = 0;
            string Key = "";
            string LastUpdate="";
            int Unit = 0;
            while (reader.Read())
            {

                // Do some work here on the data.
                Console.WriteLine(reader.Name);
                string s = reader.Value;
                if (s != "")
                {
                    if (i == 0)
                    {
                        CurrentChange = double.Parse(s);
                    }
                    else if (i == 1)
                    {
                        CurrentExchangeRate = double.Parse(s);
                    }
                    else
                    {
                        if (i == 2)
                        {
                            Key = s;
                        }
                        else if (i == 3)
                        {
                            LastUpdate = s;
                        }
                        else
                        {
                            Unit = int.Parse(s);
                            ExchangeRateResponseDTO e = new ExchangeRateResponseDTO(CurrentChange, CurrentExchangeRate, Key, LastUpdate, Unit);
                            exchangeRateResponseDTO.Add(e);
                            i = -1;
                        }
                    }
                    i++;
                }
            }
            var json = JsonConvert.SerializeObject(exchangeRateResponseDTO);
            return json;
        }
        private static void ProcessFile()
        {
            
        }
    }
}
