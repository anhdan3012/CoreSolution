using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.ParIndex
{
    public class DanhMucQuanHuyen
    {
        public string QuanHuyenId { set; get; }
        public string TenQuanHuyen { set; get; }
        public string TinhThanhId { set; get; }

        public DanhMucQuanHuyen danhMucTinhThanh { set; get; }
    }
}
