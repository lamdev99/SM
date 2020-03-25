using System;
using System.Collections.Generic;

namespace SubstationManagement.Entity.Models
{
    public partial class QuanLy
    {
        public int Tba { get; set; }
        public string NhanVien { get; set; }

        public virtual NhanVien NhanVienNavigation { get; set; }
        public virtual TramBienAp TbaNavigation { get; set; }
    }
}
