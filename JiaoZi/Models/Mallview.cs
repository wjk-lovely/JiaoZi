using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Mallview
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Books> CateBooks { get; set; }
        public IEnumerable<Books> CateBooks1 { get; set; }
        public IEnumerable<Books> CateBooks2 { get; set; }
        public IEnumerable<Books> CateBooks3 { get; set; }
        public IEnumerable<Books> CateBooks4 { get; set; }
        public IEnumerable<Books> Search { get; set; }
        public IEnumerable<Books> Hotsale { get; set; }
        public IEnumerable<Books> Onsale { get; set; }
        public IEnumerable<Books> NewBooks { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
       
    }


}