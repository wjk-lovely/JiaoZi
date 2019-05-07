using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RNews2:INews2
    {
        IQueryable<News> INews2.FindNewsbyid(int Newsid)
        {
            jiaoziEntities db = new jiaoziEntities();
            return db.News.Where(n => n.NewsID == Newsid);
        }
    }
}