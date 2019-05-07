using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaoZi.Models;

namespace JiaoZi.Controllers
{
    public class ResouceController : Controller
    {
        Models.jiaoziEntities db = new Models.jiaoziEntities();
        IResource iresource = new RResource();
        ResourceViewModel resourceviewmodel = new ResourceViewModel();
        // GET: Resouce
        public ActionResult Index()
        {
            resourceviewmodel.alltextresource = iresource.alltextresource();
            resourceviewmodel.allvideoresource = iresource.allvideoresource();
            resourceviewmodel.youertextresource = iresource.TextResourceByStage("幼儿");
            resourceviewmodel.youervideoresource = iresource.VideoResourceByStage("幼儿");
            resourceviewmodel.xiaoxuetextresource = iresource.TextResourceByStage("小学");
            resourceviewmodel.xiaoxuevideoresource = iresource.VideoResourceByStage("小学");
            resourceviewmodel.chuzhongtextresource = iresource.TextResourceByStage("初中");
            resourceviewmodel.chuzhongvideoresource = iresource.VideoResourceByStage("初中");
            resourceviewmodel.gaozhongtextresource = iresource.TextResourceByStage("高中");
            resourceviewmodel.gaozhongvideoresource = iresource.VideoResourceByStage("高中");
            return View(resourceviewmodel);
        }
        public ActionResult allresource()
        {
            resourceviewmodel.alltextresource = iresource.alltextresource();
            resourceviewmodel.allvideoresource = iresource.allvideoresource();
            resourceviewmodel.youertextresource = iresource.TextResourceByStage("幼儿");
            resourceviewmodel.youervideoresource = iresource.VideoResourceByStage("幼儿");
            resourceviewmodel.xiaoxuetextresource = iresource.TextResourceByStage("小学");
            resourceviewmodel.xiaoxuevideoresource = iresource.VideoResourceByStage("小学");
            resourceviewmodel.chuzhongtextresource = iresource.TextResourceByStage("初中");
            resourceviewmodel.chuzhongvideoresource = iresource.VideoResourceByStage("初中");
            resourceviewmodel.gaozhongtextresource = iresource.TextResourceByStage("高中");
            resourceviewmodel.gaozhongvideoresource = iresource.VideoResourceByStage("高中");
            return View(resourceviewmodel);
        }
        public ActionResult videoresouce()
        {
            return View();
        }
        public ActionResult fileresouce()
        {
            var allresource = iresource.alltextresource();
            return View(allresource);
        }
        //搜索资源
        public ActionResult searchresouce()
        {
            string searchString1 = Request["searchString"];
            var text= iresource.searchtextresource(searchString1);
            var video= iresource.searchvideoresource(searchString1);
            resourceviewmodel.searchtextresource = text;
            resourceviewmodel.searchvideoresource = video;
            if (text.FirstOrDefault()== null && video.FirstOrDefault() == null)
            {
                return Content("<script>;alert('不好意思没找到您要的资源');window.history.go(-1);</script>");
                //return Content("不好意思没找到您要的资源");
            }
            //return View("searchresouce");
            else return View(resourceviewmodel);

        }
    }
}