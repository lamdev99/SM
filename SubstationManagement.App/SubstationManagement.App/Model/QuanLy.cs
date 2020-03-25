using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubstationManagement.App.Model
{
	class QuanLy
	{
		[JsonProperty("tba")]
		public int tba { get; set; }
		[JsonProperty("nhanVien")]
		public string nhanVien { get; set; }
		[JsonProperty("tbaNavigation")]
		public TbaNavigation tbaNavigation { get; set; }
	}
}
