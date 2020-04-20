using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.ParIndex
{
    public class DanhMucTieuChi
    {
        public string TieuChiId{set;get;}
        public string TenTieuChi { set; get; }
        public int ThuTuUuTien { set; get; } 
        public string LinhVucId { set; get; }

        public DanhMucLinhVuc danhMucLinhVuc { set; get; }
    }
}
