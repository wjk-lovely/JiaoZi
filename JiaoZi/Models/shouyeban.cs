using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class shouyeban
    {  
        //首页view model
        //最新出版书籍
        public IEnumerable<Books> Newissuebook { get; set; }
        //最新新闻
        public IEnumerable<News> newstops { get; set; }
        //最新文本资源
        public IEnumerable<TextResource> newtextresource { get; set; }

    }
}