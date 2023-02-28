using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobs27.Models.ViewModels
{
    public class PageInfo
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int NumPages => (int) Math.Ceiling((double) Total / PageSize);
    }
}
