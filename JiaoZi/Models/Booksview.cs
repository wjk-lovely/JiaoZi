using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Booksview
    {
        public IEnumerable<Books> Search { get; set; }
    }
}