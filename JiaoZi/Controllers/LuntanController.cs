using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaoZi.Models;
using PagedList;
using JiaoZi.Attributes;



namespace JiaoZi.Controllers
{
    public class LuntanController : Controller
    {
        jiaoziEntities db = new jiaoziEntities();
        Models.TieziViewModel tieziviewmodel = new Models.TieziViewModel();

        // GET: Luntan
        public ActionResult Index(int? page)
        {
            IRemark_User_Comments_Reply ir = new RRemark_User_Comments_Reply();
            var remarks = ir.Getsall();
            int pagesize = 15;
            int pageNumber = (page ?? 1);
            return View(remarks.ToPagedList(pageNumber, pagesize));
         
        }
        //public ActionResult Search(string title,int ? page)
        //{
        //    var p = from t in db.Remark_User_Comments_Reply.OrderByDescending(t=>t.Remark_time)
                  
        //            select t;
        //    if(title!=null)
        //    {
        //        page = 1;
        //    }
        //    if (p == null)
        //        return Content("您查找的帖子不存在!");
        //    else
        //        p = p.Where(r => (r.Title.Contains(title)));
        //    int pageSize = 8;
        //    int pageNumber = (page ?? 1);
        //    return View(p.ToPagedList(pageNumber,pageSize));

        //}
        //public ActionResult News_ten()
        //{
        //    var news = (from n in db.News
        //                orderby n.News_Time
        //                select n).Take(10);
        //    return PartialView(news);
                       
                      
        //}
        
        //public ActionResult News(int? page)
        //{
        //    INews1 iw = new RNews1();
        //    var news = iw.getallnews();
        //    int pagesize = 8;
        //    int pageNumber = (page ?? 1);
        //    return View(news.ToPagedList(pageNumber,pagesize));

        //}
        //public ActionResult Newsdetails(int Newsid)
        //{
        //    INews2 news = new RNews2();
            
        //    return View(news.FindNewsbyid(Newsid));
        //}
        public ActionResult Index2(int id)
        {
            Session["Remarkid"] = id;
            IRemarks ir = new RRemarks();
            IRemarkcomments ire = new RRemarkcomments();
            //ViewBag.Remarkid = id;

            //var remarkcomment = db.RemarkComments.OrderByDescending(p=>p.RemarkCommentID==id);
            //var remarkreply = from o in db.RemarkReply
            //                  join b in db.RemarkComments on o.RemarkCommentID equals b.RemarkCommentID
            //                  join c in db.Remarks on b.RemarkID equals c.RemarkID
            //                  where c.RemarkID == id
            //                  select o;
            var ima_nam = from a in db.Users
                          join b in db.Remarks on a.UserID equals b.UserID
                          where b.RemarkID == id
                          select a;


            TieziViewModel tiz = new TieziViewModel()
            {
                
                Gettiezi = ir.FindRemarksByID(id),
                GetIma_nam = ima_nam.Take(1)


            };
            return View(tiz);
        }
       //评论的Ｇet请求

        public ActionResult PL(int id)
        {
            id = int.Parse(Session["Remarkid"].ToString());


            IRemarks ir = new RRemarks();
            IRemarkcomments ire = new RRemarkcomments();
            TieziViewModel tiz = new TieziViewModel()
            {
                Getpinglun = ire.Getcommentsbyid(id)
            };

            return PartialView(tiz);

        }

        //将评论写入
        [HttpPost]
 
        [ValidateInput(false)]  //富文本编辑器使用
        [Login]

        public ActionResult PL(RemarkComments res)
        {
            int tieziid = int.Parse(Session["Remarkid"].ToString());
            //IRemarkcomments ire = new RRemarkcomments();
            //var usercomments = ire.Getcommentsbyid(tieziid);
            //ViewBag.tiezicomment = usercomments;
            IComments ic = new RComments();
            string textarea = Request["pingluntextarea"];
            if (ModelState.IsValid)
            {
                //if (textarea != "")
                //{

                //登录后再完善
                int aa;
                res.Comment_Time = System.DateTime.Now;

                aa = System.Convert.ToInt32(Session["User_id"]);
                res.UserID = aa;
                //res.UserID = 1;

                //res.Comment_Content = Request["TextBox1"];
                res.Comment_Content = textarea;
                res.RemarkID = int.Parse(Session["Remarkid"].ToString());

                ic.Comments(res);
               
                db.SaveChanges();

                return Content("<script>alert('评论成功!');window.location.reload();</script>");

            }
            

            else return RedirectToAction("Index2", "Luntan", new { id = tieziid });
           

        }


        public ActionResult HF(int pinglunid)
        {
            var remarkreply = from o in db.RemarkReply
                              join b in db.RemarkComments on o.RemarkCommentID equals b.RemarkCommentID
                              where b.RemarkCommentID == pinglunid
                              select o;
            TieziViewModel tiz = new TieziViewModel()
            {
                Gethuifu = remarkreply
            };
            return PartialView(tiz);

        }
        [HttpPost]
        [ValidateInput(false)]  //富文本编辑器使用
        //[ValidateAntiForgeryToken]
        //将回复写入
        [Login]
        public ActionResult HF(RemarkReply rep, int pinglunid)
        {
            IReply ir = new RReply();
            //Session["pinglunid"] = pinglunid;
            var t = from o in db.Remarks
                    join b in db.RemarkComments on o.RemarkID equals b.RemarkID
                    where b.RemarkCommentID == pinglunid
                    select o.RemarkID;
            if (ModelState.IsValid)
            {
                rep.RemarkCommentID = pinglunid;
                rep.UserID = int.Parse(Session["User_id"].ToString());
                //rep.UserID = 1;
                rep.Reply_Content = Request["TextBox2"];
                rep.Reply_Time = System.DateTime.Now;
                ir.Reply(rep, pinglunid);
                db.SaveChanges();
                return Content("<script>;alert('回复成功!');history.go(-1)</script>");
            }
            //return RedirectToAction("Index2","Luntan",new { id=t});
            return Content("<script>;alert('回复失败!');history.go(-1)</script>");
        }

        public ActionResult fatie()
        {
            return View();
        }
        [HttpPost]
        [Login]
        public ActionResult fatie(Remarks re)
        {
            string fatietextarea = Request["fatietextarea"];
            string fatietitle = Request["fatietitle"];
            IFatie ite = new RFatie();
            if (ModelState.IsValid)
            {
                //int aa;

                //aa = System.Convert.ToInt32(Session["User_id"]);
                ////res.UserID = aa;
                //re.UserID = aa;
                re.UserID = int.Parse(Session["User_id"].ToString());

                re.Remark_Time = System.DateTime.Now;
                re.RemarkContent = fatietextarea;
                re.Title = fatietitle;
                ite.publishremarks(re);
                db.SaveChanges();
                //return Content("<script>;alert('发帖成功!');history.go(-1)</script>");
                return Content("<script>alert('发表成功!');window.location.href='../Luntan/Index';</script>");
            }
            else
            {
                return Content("<script>alert('请先登录');window.location.href='../UserInfo/RegisteLogin';</script>");

            }

        }
    }
}
      
