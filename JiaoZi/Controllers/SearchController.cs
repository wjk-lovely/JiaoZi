using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using JiaoZi.Models;

namespace JiaoZi.Controllers
{
    public class SearchController : Controller
    {
        //GET: Search
        jiaoziEntities db = new jiaoziEntities();
        Models.TieziViewModel tieziviewmodel = new Models.TieziViewModel();
        public ActionResult Search(string title)
        {
            
            var p = from t in db.Remark_User_Comments_Reply.OrderByDescending(t=>t.Remark_time)
                    select t;
            

            //if (title == null)
            //    return Content("<script>;alert('您查找的帖子不存在');</script>");
            //else
            p = p.Where(r => (r.Title.Contains(title)));
            if(p == null)
                return Content("<script>;alert('您查找的帖子不存在');</script>");

            
            
            return View(p);

        }
    }
}