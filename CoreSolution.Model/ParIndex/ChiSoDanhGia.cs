using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.ParIndex
{
    public class ChiSoDanhGia
    {
        public string Id { set; get; }
        public string LinhVucId { set; get; }
        public string TieuChiId { set; get; }
        public string TieuChiThanhPhanId { set; get; }
        public int NamDanhGia { set; get; }
        public decimal DiemChuan { set; get; }
        public string MoTa { set; get; }
         
        public DanhMucLinhVuc danhMucLinhVuc { set; get; }
        public DanhMucTieuChi danhMucTieuChi { set; get; }
        public DanhMucTieuChiThanhPhan danhMucTieuChiThanhPhan { set; get; }
    }
}
