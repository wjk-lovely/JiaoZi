using JiaoZi.Attributes;
using JiaoZi.Models;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaoZi.Controllers
{
    public class MallController : Controller
    {
        jiaoziEntities db = new jiaoziEntities();
        
        IMall imall;
        public MallController()
        {
            
            imall = new Mall();
        }
        // GET: Mall


        //主页显示
        public ActionResult Index()
        {
            #region
            Models.Mallview viewModel = new Models.Mallview

            {

                Hotsale = imall.GetBooksByAmount(),
                Category = imall.Category(),
                CateBooks = imall.GetBooksByCategory(1),
                CateBooks1 = imall.GetBooksByCategory(2),
                CateBooks2 = imall.GetBooksByCategory(3),
                CateBooks3 = imall.GetBooksByCategory(4),
                CateBooks4 = imall.GetBooksByCategory(5),
                NewBooks = imall.GetBooksByTime(),
                Onsale=imall.GetBooksByPrice(),
            };
            #endregion
            return View(viewModel);
        }
        
        //搜索图书
        [HttpPost]
        public ActionResult Sear()
        {
            string search = Request.Form["search"].ToString();
            var Searchbooks = imall.Search(search);
            if(Searchbooks!=null)
            {
                return PartialView(Searchbooks);
            }
            else                                 
                return HttpNotFound();
        }


        //获取导航条
        public ActionResult Nav()
        {
            var CatagoryName = imall.Category();

            return PartialView(CatagoryName);
        }


        //获取数目
        public ActionResult Num()
        {
            int? UserID = Convert.ToInt32(Session["User_id"]);        
            int sum = 0;
            if (UserID!=null)
            {
                foreach(var i in db.Cars.Where(o=>o.UserID==UserID))
                {
                    sum += Convert.ToInt32(i.Count);
                }
                return Content(sum.ToString());
            }
            else
            return Content(0.ToString());
        }

        //根据ID查某本图书的详情及所有评论
        public ActionResult BooksDetails(int id)
        {
            Session["BookID"] = id;
            var a = db.Books.Where(o => o.BookID == id).FirstOrDefault();
            return View(a);
        }

        //分页显示某类图书
        public ActionResult  BooksType(string CategoryName,string currentFilter, int ? page)
        {
            var books = imall.GetBooks();
            if (CategoryName != null)
            {
                page = 1;
            }
            else
            {
                CategoryName = currentFilter;
            }
            ViewBag.CurrentFilter = CategoryName;
            if (!string.IsNullOrEmpty(CategoryName))
            {
                books = books.Where(x => x.Category == CategoryName);

            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return PartialView(books.ToPagedList(pageNumber, pageSize));
        }

        //显示图书
        public ActionResult BooksShow(string CategoryName)
        {
            var books = imall.GetBooks().Where(x => x.Category == CategoryName);
            return View(books);
        }


        //显示评论
        public ActionResult Comment()
        {
            int id = Convert.ToInt32(Session["BookID"]);
            var comment = db.BookComment.Where(x => x.BookID == id);
            return PartialView(comment);
        }


        //异步评论  代码有待改进 
        [HttpPost]
        [Login]
        public ActionResult Comment(BookComment comment,  int CommentBookID, string Comment_Content)
        {
            #region       
            BooksDetails a = new BooksDetails(CommentBookID);
            int UserID;
            var UserComment = a.Bc;
            ViewBag.Comment = UserComment;          
                UserID = Convert.ToInt32(Session["User_id"]);
                //string textarea = Request["Comment_Content"];
                if (ModelState.IsValid)
                {
                    if (Comment_Content!= "")
                    {
                        comment.UserID = UserID;
                        comment.BookID = CommentBookID;
                        comment.Comment_Content = Comment_Content;
                        comment.Comment_Time = System.DateTime.Now;
                        imall.AddComment(comment);
                        UserComment = a.Bc;
                    ViewBag.Comment = UserComment;                   
                    return PartialView(ViewBag.Comment as IEnumerable<BookComment>);
                   
                }
                    else
                    {                     
                    return PartialView(ViewBag.Comment as IEnumerable<BookComment>);
                }
                }
                    return PartialView(ViewBag.Comment as IEnumerable<BookComment>);
            #endregion

        }

        //评论的实验代码
        #region
        //  [HttpPost]
        //  [Login]
        //  public ActionResult Comment()
        //   {
        //    int BookID = Convert.ToInt32(Request.Form["Comment_BookID"].ToString());
        //    BooksDetails a = new BooksDetails(BookID);
        //    int UserID;
        //    var UserComment = a.Bc;
        //    ViewBag.Comment = UserComment;
        //    if (Session["User_id"]!=null)
        //        {
        //        UserID = Convert.ToInt32(Session["User_id"]);
        //        string textarea = Request["Comment_Content"];
        //        DateTime dateTime = System.DateTime.Now;
        //        if(textarea!=null)
        //        {
        //            imall.bookComments(UserID, BookID, textarea, dateTime);
        //            return PartialView(UserComment);
        //        }
        //        else
        //        {
        //            return Content("<script>alert(评论不能为空')</script>");
        //        }
        //    }
        //    return Content("<script>alert('请先登录');window.location.href='../UserInfo/RegisteLogin';</script>");
        //}
        #endregion

        //显示回复    
        public ActionResult Reply(int id)
        {
            var BooksReply = db.BookRelpy.Where(o => o.BookCommentID == id);        
            return PartialView(BooksReply.ToList());
        }

        [HttpGet]
        public ActionResult ReplyBox()
        {
            return PartialView();
        }

        [HttpPost]
        [Login]
        public JsonResult ReplyBox(int id, string Re_Content, int ReID)
        {
            int UserID = Convert.ToInt32(Session["User_id"]);
            DateTime dateTime = System.DateTime.Now;
            if (Re_Content == "")
            {
                //return Content("<script>alert(评论不能为空')</script>");
                return base.Json("评论不能为空");
            }
            else
                imall.BookReply(id,ReID,dateTime,Re_Content,UserID);
            AjaxMsg msg = new AjaxMsg()
            {
                Mess = "评论成功"
            };
            return base.Json(msg);
        }

        #region
        //[HttpPost]
        //[Login]
        //public JsonResult Reply(int id, string Re_Content, int ReID)
        //{
        //    int UserID = Convert.ToInt32(Session["User_id"]);
        //    DateTime dateTime = System.DateTime.Now;
        //    AjaxMsg msg = new AjaxMsg()
        //    {
        //        Mess = "更改成功"
        //    };
        //    if (Re_Content == "")
        //    {
        //        return base.Json("回复失败");
        //    }
        //    else
        //        imall.BookReply(id, Re_Content, ReID, UserID, dateTime);
        //    //var BooksReply = db.BookRelpy.Where(o => o.BookCommentID == id);
        //    return base.Json(msg);
        //}
        #endregion
        #region
        //[HttpPost]
        //[Login]
        //public ActionResult Reply(int id, string Re_Content, int ReID)
        //{
        //    int UserID = Convert.ToInt32(Session["User_id"]);
        //    DateTime dateTime = System.DateTime.Now;
        //    IEnumerable<BookRelpy> a;
        //    if (Re_Content == "")
        //    {
        //        return Content("<script>alert(评论不能为空')</script>");
        //    }
        //    else
        //    a=  imall.BookReply(id, Re_Content, ReID, UserID, dateTime);
        //    //var BooksReply = db.BookRelpy.Where(o => o.BookCommentID == id);
        //    return PartialView(a);
        //}
        #endregion

        //显示购物车购物车
        public ActionResult Cars()
         {
            var id = Convert.ToInt32(Session["User_id"]);
            var cars = imall.Cars(id);
            return View(cars);
         }

        //加入购物车
        [HttpPost]
        [Login]
        public ActionResult Cars(int BookID)
        {
            int ID = Convert.ToInt32(Session["User_id"]);
            var number = Convert.ToInt32(Request.Form["number"].ToString());
            var count = db.Books.Find(BookID).Amount;
            if (number > count)
            {
                return Content("<script>alert('库存不足，加入失败');history.go(-1);</script>");
            }
            else
            {
                imall.AddBooks(number, BookID, ID);
               
                return Content("<script>alert('加入成功');window.location.href='../Mall/index';</script>");
            }
        }


        //修改数量
        [Login]
        public JsonResult UpdateCar(string  Num,int CarID)
        {
            int num = Convert.ToInt32(Num);
            imall.Update(num, CarID);
            AjaxMsg msg = new AjaxMsg()
            {
                Mess = "更改成功"
            };
            return base.Json(msg);
        }

        //删除某条订单
        [Login]
        public JsonResult DeleteCar(int CarID)
        {
            imall.Delete(CarID);
            AjaxMsg msg = new AjaxMsg()
            {
                Mess = "删除成功"
            };
            return base.Json(msg);

        }

        //显示已购订单
        [Login]
        public ActionResult Order(int? id)
        {
            
            var orders = imall.Ord(id);
            if (orders.Count() > 0)
            {
                return View(orders);
            }
            else
                return View();
        }


        //显示用户所选商品
        [Login]
        public ActionResult OrderDetails(int? id)
        {
            var Ordersdetails = imall.OrderDetails(id);
            return PartialView(Ordersdetails);
        }
    


        //完成订单
        //参数分别传cartID,姓名，地址，电话，价格     下文ID为用户ID
        [HttpPost]
        [Login]
        public JsonResult Buy(int[] a,string Name,string Add,string Tel,string Total)
        {
            int ID = Convert.ToInt32(Session["User_id"]);
            var datetime = System.DateTime.Now;
            imall.Order(Name, Add, Tel, Total, ID, datetime);
            for (int i=0;i<a.Length;i++)
            {             
                imall.Pay(a[i],datetime,ID);           
            }
            AjaxMsg msg = new AjaxMsg()
            {
                Mess = "下单成功"
            };        
            return base.Json(msg);
        }


        //直接购买
        [HttpPost]
        [Login]
        public JsonResult DirectBuy(int BoID, string Name, string Add, string Tel, string Total,string Num)
        {
            int ID = Convert.ToInt32(Session["User_id"]);
            int num = Convert.ToInt32(Num);
            var datetime = System.DateTime.Now;
            imall.Order(Name, Add, Tel, Total, ID, datetime);
            imall.DirectBuy(BoID, datetime, ID, num);
            AjaxMsg msg = new AjaxMsg()
            {
                Mess = "下单成功"
            };
            return base.Json(msg);
        }
    }
}