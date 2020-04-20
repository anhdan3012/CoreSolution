using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.ParIndex
{
    public class DanhMucXaPhuong
    {
        public string XaPhuongId { set; get; }
        public string TenXaPhuong { set; get; }
        public string QuanHuyenId { set; get; } 

        public DanhMucQuanHuyen danhMucQuanHuyen { set; get; }
    }
}
