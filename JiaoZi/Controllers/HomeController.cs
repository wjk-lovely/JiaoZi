using JiaoZi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaoZi.Controllers
{
    public class HomeController : Controller
    {
        jiaoziEntities db = new jiaoziEntities();
        INews inew = new RNews();
        IBook ibook = new RBook();
        IResource iresource = new RResource();
        Models.shouyeban shouyeban = new Models.shouyeban();
        //测试用的首页
        public ActionResult Page()
        {
            var list = db.Users;
            return View(list);
        }
     
        //首页
        public ActionResult Index()
        {
            return View();
        }
        //首页最新资讯
        public ActionResult homezixun()
        {
            //INews inew = new RNews();
            //var zixun = inew.NewsByTime2();
            //Models.Newsban newsban = new Models.Newsban();
            //newsban.zixun = zixun;
            //return View(zixun);
            var newtop0_7 = inew.NewsByTime(0, 6);
            shouyeban.newstops = newtop0_7;
            return PartialView(shouyeban);

        }
        //首页新书上架
        public ActionResult homeziyuan()
        {
            var resource = iresource.ResourceByTime(0, 6);
            shouyeban.newtextresource = resource;
            return PartialView(shouyeban);
        }
        //public ActionResult homenewbook()
        //{
        //    return View();
        //}
        public ActionResult newissuebook()
        {
            var newissuebook = ibook.BookByTime(0,4);
            shouyeban.Newissuebook = newissuebook;
            return PartialView(shouyeban);
        }
        public ActionResult TX()
        {
            return View();
        }
        public ActionResult Booksalestop3()
        {
            IBook sa = new RBook();
            if (sa.FindAllBookName() != null)
                return PartialView(sa.FindAllBookName());
            return PartialView(shouyeban);
        }
    }
}