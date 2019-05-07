using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaoZi.Models;
using System.IO;
using JiaoZi.Attributes;

namespace JiaoZi.Controllers
{
    [Login]
    public class KongjianController : Controller
    {
        Models.jiaoziEntities db = new Models.jiaoziEntities();
        IShuoshuo shuo = new RShuoshuo();
        IText itext = new RText();
        IShuoshuocomment shuocomment = new RShuoshuocomment();
        IVideo ivideo = new RVideo();
        IKongjian ikongjian = new RKongjian();
        Kongjianban kongjianban = new Kongjianban();
        // GET: Kongjian
        public ActionResult Index()
        {
            return View();
        }
        //关注
        public ActionResult guanzhu(int userid1)
        {
            var guanzhuuser = ikongjian.attention(userid1);
            return View(guanzhuuser);
        }
        public ActionResult guanzhu1(int userid1)
        {
            var guanzhuuser = ikongjian.attention(userid1);
            return View(guanzhuuser);
        }
        //粉丝
        public ActionResult fen(int userid1)
        {
            var fens = ikongjian.fens(userid1);
            return View(fens);
        }
        public ActionResult fen1(int userid1)
        {
            var fens = ikongjian.fens(userid1);
            return View(fens);
        }
        /// <summary>
        /// 说说
        /// </summary>
        /// <returns></returns>
        public ActionResult shuoshuo()
        {
            return View();
        }
        //发说说
        [HttpPost]
        public ActionResult shuoshuo(Shuoshuo shuoshuo)
        {
            string shuoshuotextarea = Request["shuoshuoinput"];
            try
            {
                if (ModelState.IsValid)
                {
                    shuoshuo.Shuoshuo_Content = shuoshuotextarea;
                    shuoshuo.Shuoshuo_Time = DateTime.Now;
                    shuoshuo.Thumb_Num = 0;
                    shuoshuo.UserID = Convert.ToInt32(Session["User_id"]);
                    //便于测试
                    //shuoshuo.UserID = 1;
                    shuo.Add(shuoshuo);
                    db.SaveChanges();
                    //return Content("<script>;confirm('发布成功！');window.history.go(0);</script>");
                    return Content("<script>;alert('发布成功！');window.history.go(-1);</script>");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return RedirectToAction("shuoshuo");
        }
        public ActionResult dongtai()
        {
            int id1= Convert.ToInt32(Session["User_id"]);
            var dongtai1 = from s in db.Shuoshuo
                           join a in db.Attention
                           on s.UserID equals a.Attention_UserID
                           where a.UserID ==id1
                           select s;
            return View(dongtai1);
        }
        //列出所有的说说
        public ActionResult allshuoshuo()
        {
            //通过用户id找说说
            var usershuoshuo = shuo.AllShuoByID(Convert.ToInt32(Session["User_id"]));
            //便于测试
            //var usershuoshuo = shuo.AllShuoByID(1);
            //通过说说id找说说评论

            kongjianban.UserAllShuo = usershuoshuo;
            //说说评论
           
            return PartialView(kongjianban);
        }
        //删除说说
        [HttpPost]
        public ActionResult deldeteshuoshuo(int shuoshuoid)
        {
            shuo.delete(shuoshuoid);
            db.SaveChanges();
            //return Content("<script>;alert('删除成功！');window.history.go(-1);</script>");
            return RedirectToAction("shuoshuo");
        }
        //说说评论分部视图
        public ActionResult shuoshuocomment(int shuoshuoid)
        {
            Session["shuoshuoid1"] = shuoshuoid;
            var shuoshuocomment1 = shuocomment.ShuoCommentById(shuoshuoid);
            kongjianban.ShuoCommentById = shuoshuocomment1;
            return PartialView(kongjianban);
        }
        //[HttpPost]
        //public ActionResult shuoshuocomment(ShuoshuoComment comment, int shuoshuoid)
        //{
        //    string commentcontent = Request["commentcontent"];
        //    //ShuoshuoComment comment = new ShuoshuoComment();
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            comment.Comment_Content = commentcontent;
        //            comment.Comment_Time = DateTime.Now;
        //            //session代替
        //            comment.UserID = 1;
        //            comment.ShuoshuoID = Convert.ToInt32(Session["shuoshuoid1"]);
        //            shuocomment.addshuocomment(comment);
        //            db.SaveChanges();
        //            return PartialView(kongjianban);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //    return RedirectToAction("shuoshuocomment");
        //}
        //发表评论
        [HttpPost]
        public ActionResult postshuoshuocomment(int shuoshuoid)
        {
            string commentcontent = Request["commentcontent"];
            ShuoshuoComment comment = new ShuoshuoComment();
            try
            {
                if (ModelState.IsValid)
                {
                    comment.Comment_Content = commentcontent;
                    comment.Comment_Time = DateTime.Now;
                    //session代替
                    comment.UserID = Convert.ToInt32(Session["User_id"]);
                    comment.ShuoshuoID = shuoshuoid;
                    shuocomment.addshuocomment(comment);
                    db.SaveChanges();
                    //return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            //return Content("<script>alert('关注成功')</script>;window.history.go(-1);");
            return RedirectToAction("shuoshuo");
        }
        //删除评论
        [HttpPost]
        public ActionResult delcomment(int commentid)
        {

            shuocomment.deletecomment(commentid);
            db.SaveChanges();
            return Content("<script>;alert('删除成功！');window.history.go(-1);</script>");
        }
        //用户回复用户评论显示
        public ActionResult shuoshuocommentreply(int commentid)
        {
            var commentreply = ikongjian.allshuoshuocommentreply(commentid);
            return View(commentreply);
        }
        //用户回复用户提交
        [HttpPost]
        public ActionResult postshuoshuocommentreply(ShuoshuoComment_Reply shuocommentreply1,int commentid)
        {
            string commentreplycontent = Request["commentreplycontent"];
            try
            {
                if (ModelState.IsValid)
                {
                    shuocommentreply1.Reply_Content = commentreplycontent;
                    shuocommentreply1.Reply_Time = DateTime.Now;
                    shuocommentreply1.ShuoshuoCommentID = commentid;
                    //后期改成session
                    shuocommentreply1.UserID = Convert.ToInt32(Session["User_id"]);
                    ikongjian.addshuocommentreply(shuocommentreply1);
                    db.SaveChanges();
                    //return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            //return Content("<script>alert('关注成功')</script>;window.history.go(-1);");
            return RedirectToAction("shuoshuo");
        }

        /// <summary>
        /// 文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult File()
        {
            return View();
        }
        //上传文件
        [HttpPost]
        public ActionResult File(HttpPostedFileBase file, Text text)
        {
            //存入项目
            var fileName = file.FileName;
            //string fileName =file.FileName.Replace(Convert.ToChar(DateTime.Now), Convert.ToChar(file.FileName));
            var filePath = Server.MapPath(string.Format("~/{0}", "Text"));
            var newfilePath = Path.Combine(filePath,fileName);
            //相对路径保存至数据库
            var newfilepath = Path.Combine("../Text/", fileName);
            file.SaveAs(newfilePath);
            //保存至数据库
            try
            {
                if (ModelState.IsValid)
                {
                   
                    text.Text_path = newfilepath;
                    text.Text_Time = DateTime.Now;
                    //后期改成 text.UserID = Convert.ToInt32(Session["User_id"]);
                    text.UserID = 1;
                    itext.addtext(text);
                    db.SaveChanges();
                    return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View();
        }
        //查找所有文件
        public ActionResult allfill()
        {
            var useruploadfile = itext.UserUploadText(1);
            kongjianban.userupload = useruploadfile;
            return PartialView(kongjianban);
        }
        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public ActionResult video()
        {
            return View();
        }
        [HttpPost]
        public ActionResult video(HttpPostedFileBase file,Video video)
        {
            //存入项目
            var videoName = file.FileName;
            //string fileName =file.FileName.Replace(Convert.ToChar(DateTime.Now), Convert.ToChar(file.FileName));
            var videoPath = Server.MapPath(string.Format("~/{0}", "Video/"));
            var newvideoPath = Path.Combine(videoPath, videoName);
            file.SaveAs(newvideoPath);
            //保存至数据库
            try
            {
                if (ModelState.IsValid)
                {
                    //video名字获取传入存在问题，自动变成blob,视频上传自动分块
                    video.VideoPath = newvideoPath;
                    video.Video_Time = DateTime.Now;
                    //后期改成 video.UserID = Convert.ToInt32(Session["User_id"]);
                    video.UserID = 1;
                    video.downloadcount = 0;
                    ivideo.addvideo(video);
                    db.SaveChanges();
                    //return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View();
        }
        public ActionResult allvideo()
        {
            //后期用 Convert.ToInt32(Session["User_id"])替换数字1
            var uservideo = ivideo.AllVideoByUserId(1);
            return PartialView(uservideo);
        }
        //他人主页
        public ActionResult otheruserkongjian(int otheruserid)
        {
            Session["otheruserid"] = otheruserid;
            Session["otheruserimg"] = db.Users.Where(m => m.UserID == otheruserid).FirstOrDefault().HeadImage;
            kongjianban.UserAllShuo = shuo.AllShuoByID(otheruserid);
            kongjianban.userupload = itext.UserUploadText(otheruserid);
            kongjianban.uservideo = ivideo.AllVideoByUserId(otheruserid);
            return View(kongjianban);
        }
        //用户关注用户
        [HttpPost]
        public ActionResult UAttentionU(Attention attenion,int user2id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    attenion.Attention_Time = DateTime.Now;
                    //attenion.UserID = Convert.ToInt32(Session["User_id"]);
                    attenion.UserID =1 ;
                    attenion.Attention_UserID =user2id;
                    attenion.Condition = true;
                    ikongjian.addattention(attenion);
                    db.SaveChanges();
                    //return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("<script>alert('关注成功');history.go(-1);</script>");

        }
        //取消关注
        [HttpPost]
        public ActionResult quxiaoguanzhu(int guanzhuid)
        {
            ikongjian.deleteattention(guanzhuid);
            db.SaveChanges();
            return Content("<script>;alert('取关成功');history.go(-1);</script>");
        }

    }

}