using System;
using System.Collections.Generic;

namespace SubstationManagement.Entity.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            QuanLy = new HashSet<QuanLy>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<QuanLy> QuanLy { get; set; }
    }
}
