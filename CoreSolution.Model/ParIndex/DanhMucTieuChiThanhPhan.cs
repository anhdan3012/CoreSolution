using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.ParIndex
{
    public class DanhMucTieuChiThanhPhan
    {
        public string TieuChiThanhPhanId{set;get;}
        public string TenTieuChiThanhPhan { set; get; }
        public int ThuTuUuTien { set; get; } 
        public string TieuChiId { set; get; }

        public DanhMucTieuChi danhMucTieuChi { set; get; }
    }
}
