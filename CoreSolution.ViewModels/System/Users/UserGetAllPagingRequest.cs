using CoreSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.ViewModels.System.Users
{
    public class UserGetAllPagingRequest: PagingRequest
    {
        public string Keyword { set; get; }
    }
}
