using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Producto3.Models
{
    public class ConversionResponse
    {
        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("target_currency")]
        public string TargetCurrency { get; set; }

        [JsonProperty("base_amount")]
        public double BaseAmount { get; set; }

        [JsonProperty("converted_amount")]
        public double ConvertedAmount { get; set; }

        [JsonProperty("exchange_rate")]
        public double ExchangeRate { get; set; }

        [JsonProperty("last_updated")]
        public long LastUpdated { get; set; }
    }
}