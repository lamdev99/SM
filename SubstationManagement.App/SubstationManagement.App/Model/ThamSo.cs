using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubstationManagement.App.Model
{
	class ThamSo
	{
        [JsonProperty("tba")]
        public int tba { get; set; }
        [JsonProperty("u")]
        public double? u { get; set; }
        [JsonProperty("ia")]
        public double? ia { get; set; }
        [JsonProperty("ib")]
        public double? ib { get; set; }
        [JsonProperty("ic")]
        public double? ic { get; set; }
        [JsonProperty("tTcA")]
        public double? tTcA { get; set; }
        [JsonProperty("tTcB")]
        public double? tTcB { get; set; }
        [JsonProperty("tTcC")]
        public double? tTcC { get; set; }
        [JsonProperty("tCatA")]
        public double? tCatA { get; set; }
        [JsonProperty("tCatB")]
        public double? tCatB { get; set; }
        [JsonProperty("tCatC")]
        public double? tCatC { get; set; }
        [JsonProperty("tMt")]
        public double? tMt { get; set; }
        [JsonProperty("doAm")]
        public double? doAm { get; set; }
        [JsonProperty("canhBaoChay")]
        public int? canhBaoChay { get; set; }
        [JsonProperty("canhBaoMoCua")]
        public int? canhBaoMoCua { get; set; }
    }
}
