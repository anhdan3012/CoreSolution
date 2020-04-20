using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.ParIndex
{
    public class ThucHienDanhGia
    {
        public string ThucHienDanhGiaId { set; get; }
        public string CoQuanId { set; get; }
        public string ChiSoDanhGiaId { set; get; } 
        public decimal DiemDanhGia { set; get; }
        public string MoTaDanhGia { set; get; }
        public decimal DiemThamDinh { set; get; }
        public string MoTaThamDinh { set; get; }

        public DanhMucLinhVuc danhMucLinhVuc { set; get; }
        public DanhMucTieuChi danhMucTieuChi { set; get; }
        public DanhMucTieuChiThanhPhan danhMucTieuChiThanhPhan { set; get; }
    }
}
