using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{  
    public class RNews:INews
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<News> INews.NewsByTime(int a,int b)
        {
            var news1 =
                from o in db.News
                orderby o.News_Time
                select o;
            //foreach (var news in news1)
            return news1.Skip(a).Take(b);

        }
        //IQueryable<News> INews.NewsByTime2()
        //{
        //    var news2 =
        //        from o in db.News
        //        orderby o.News_Time
        //        select o;
        //    return news2.Skip(3).Take(7);
        //}
        //News INews.GetNewsById(int id)
        //{
        //    return db.News.Where(b => b.NewsID==id).FirstOrDefault();
        //}

    }
}