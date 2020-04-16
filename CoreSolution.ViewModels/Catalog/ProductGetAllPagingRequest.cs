using CoreSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.ViewModels.Catalog
{
    public class ProductGetAllPagingRequest: PagingRequest
    {
        public string Keyword { set; get; }
        public int? CategoryId { get; set; }
    }
}
