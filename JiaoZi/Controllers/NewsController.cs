using JiaoZi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace JiaoZi.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        jiaoziEntities db = new jiaoziEntities();
        Models.TieziViewModel tieziviewmodel = new Models.TieziViewModel();
        public ActionResult Index(int? page)
        {
            INews1 iw = new RNews1();
            var news = iw.getallnews();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pagesize));
        }
        public ActionResult Newsdetails(int Newsid)
        {
            INews2 news = new RNews2();

            return View(news.FindNewsbyid(Newsid));
        }
        public ActionResult Latestnewsten()
        {
            var news = (from n in db.News
                        orderby n.News_Time
                        select n).Take(10);
            return PartialView(news);
        }
            
        
            
            
    }
}