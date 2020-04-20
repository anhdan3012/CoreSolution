using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.ParIndex
{
    public class DanhMucCoQuan
    {
        public string CoQuanId { set; get; }
        public string TenCoQuan { set; get; }
        public int CapThucHienId { set; get; }
        public string CoQuanChuQuanId { set; get; }
        public string DiaChi { set; get; }
        public string TinhThanhId { set; get; }
        public string QuanHuyenId { set; get; }
        public string XaPhuongId { set; get; }
        public string DienThoai { set; get; }
        public string Email { set; get; }

        public DanhMucCapThucHien danhMucCapThucHien { set; get; }
        public DanhMucTinhThanh danhMucTinhThanh { set; get; }
        public DanhMucQuanHuyen danhMucQuanHuyen { set; get; }
        public DanhMucXaPhuong danhMucXaPhuong { set; get; }
    }
}
