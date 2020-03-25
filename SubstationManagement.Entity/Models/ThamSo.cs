using System;
using System.Collections.Generic;

namespace SubstationManagement.Entity.Models
{
    public partial class ThamSo
    {
        public int Tba { get; set; }
        public double? U { get; set; }
        public double? Ia { get; set; }
        public double? Ib { get; set; }
        public double? Ic { get; set; }
        public double? TTcA { get; set; }
        public double? TTcB { get; set; }
        public double? TTcC { get; set; }
        public double? TCatA { get; set; }
        public double? TCatB { get; set; }
        public double? TCatC { get; set; }
        public double? TMt { get; set; }
        public double? DoAm { get; set; }
        public int? CanhBaoChay { get; set; }
        public int? CanhBaoMoCua { get; set; }

        public virtual TramBienAp TbaNavigation { get; set; }
    }
}
