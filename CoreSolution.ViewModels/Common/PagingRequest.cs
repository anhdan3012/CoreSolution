﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.ViewModels.Common
{
    public class PagingRequest: RequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
