using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RNews1:INews1
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IList<News> INews1.getallnews()
        {
            return db.News.ToList();
        }
    }
}