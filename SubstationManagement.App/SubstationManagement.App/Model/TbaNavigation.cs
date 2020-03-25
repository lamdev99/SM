using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubstationManagement.App.Model
{
	class TbaNavigation
	{
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("ten")]
        public string ten { get; set; }
        [JsonProperty("kinhDo")]
        public double kinhDo { get; set; }
        [JsonProperty("viDo")]
        public double viDo { get; set; }
        [JsonProperty("ghiChu")]
        public string ghiChu { get; set; }
        [JsonProperty("thamSo")]
        public ThamSo thamSo { get; set; }
    }
}
