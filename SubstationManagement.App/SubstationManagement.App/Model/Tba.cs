using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubstationManagement.App.Model
{
	class Tba
	{
        public Tba()
        {
            quanLy = new List<QuanLy>();    
        }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("ten")]
        public string ten { get; set; }
        [JsonProperty("dienThoai")]
        public string dienThoai { get; set; }
        [JsonProperty("quanLy")]
        public List<QuanLy> quanLy { get; set; }
    }
}
