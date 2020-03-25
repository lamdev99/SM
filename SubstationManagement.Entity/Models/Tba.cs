using System;
using System.Collections.Generic;

namespace SubstationManagement.Entity.Models
{
    public partial class Tba
    {
        public int Id { get; set; }
        public double KinhDo { get; set; }
        public double ViDo { get; set; }
        public string Ten { get; set; }
        public double NhietDo { get; set; }
        public int CongSuat { get; set; }
        public string Loai { get; set; }
    }
}
