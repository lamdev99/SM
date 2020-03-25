using System;
using System.Collections.Generic;

namespace SubstationManagement.Entity.Models
{
    public partial class TramBienAp
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public double KinhDo { get; set; }
        public double ViDo { get; set; }
        public string GhiChu { get; set; }

        public virtual QuanLy QuanLy { get; set; }
        public virtual ThamSo ThamSo { get; set; }
    }
}
