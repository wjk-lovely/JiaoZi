using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Mall:IMall
    {
        jiaoziEntities db = new jiaoziEntities();
        //获取全部图书
       public IEnumerable<Books> GetBooks()
        {
            var books = db.Books.ToList();
            return books;
        }
        //获得单独一本书的详情
        public Books GetBooksById(int? id)
        {
            var books = db.Books.Find(id);
            return books;
        }
        //根据书名或者作者名进行搜索
        public IEnumerable<Books> Search(string search)
        {
            var sear = from p in db.Books
                       where p.BookName.Contains(search) || p.BookAuthor.Contains(search)
                       select p;
            return sear.ToList();
        }
        //升序排列 找出数量最少的三本 热销榜
        public IEnumerable<Books> GetBooksByAmount()
        {
            var AmountBooks = (from p in db.Books
                               orderby p.Amount ascending
                               select p).Take(3);
            return AmountBooks;
                           
        }
        //获取图书的种类
        public IEnumerable<Category> Category()
        {
            var category = (from p in db.Category                         
                           select p).ToList();
            return category;
        }

        //根据id查每类的图书
       public IEnumerable<Books> GetBooksByCategory(int id)
        {
            var categorybooks = from p in db.Books
                                where p.CategoryId == id
                                select p;
            return categorybooks;
        }


        //根据时间查书
        public IEnumerable<Books> GetBooksByTime()
        {
            var Books = (from p in db.Books
                         orderby p.IssueTime descending
                         select p).Take(4);
            return Books;
        }

        //根据价格查书
        public IEnumerable<Books> GetBooksByPrice()
        {
            var books = from p in db.Books
                         orderby p.Price ascending
                         select p;
            return books.ToList();
        }

       
        //添加购物车
        public void AddBooks(int Num,int BookID,int UserID)
        {
            var Books = db.Cars.Where(o => o.BookID == BookID).FirstOrDefault();
            if (Books == null)
            {
                var cars = new Cars()
                {
                    BookID = BookID,
                    UserID = UserID,
                    Count = Num,
                };
                db.Cars.Add(cars);
                db.SaveChanges();
            }
            else
            {
                Books.Count = Books.Count + Num;
                db.SaveChanges();
            }
        }


        //发表评论 正式代码
        public void AddComment(BookComment comment)
        {
            db.BookComment.Add(comment);
            db.SaveChanges();
        }

        //发表评论 实验代码  可删除
        public void BbookComments(int UserID, int BookID, string Comment_Content, DateTime dateTime)
        {
            var bookComment = new BookComment()
            {
                UserID = UserID,
                BookID = BookID,
                Comment_Content = Comment_Content,
                Comment_Time = dateTime
            };
            db.BookComment.Add(bookComment);
            db.SaveChanges();
        }

        public void BookReply(int id, int UserID, DateTime dateTime, string Re_Content,int ReID)
        {
            var bookreply = new BookRelpy()
            {
                BookCommentID = id,
                UserID = UserID,
                Reply_Time = dateTime,
                Reply_Content = Re_Content,
                Ruser_ID = ReID,
            };
            db.BookRelpy.Add(bookreply);
            db.SaveChanges();

        }


        //查询购物车
        public IEnumerable<Cars> Cars(int? id)
        {
            var cars = from q in db.Cars
                       where q.UserID == id
                       select q;
            return cars.ToList();
        }


        //查询用户订单
        public IEnumerable<Orders> Ord(int? id)
        {
           
            var orders= from m in db.Orders
                             where m.UserID == id 
                             select m;
            return orders.ToList();
            
         }
           

        //订单详情
        public IEnumerable<OrderDetails> OrderDetails(int? id)
        {
            var order = from q in db.OrderDetails
                        where  q.OrderId==id
                        select q;
            return order.ToList();
        }

        //修改数量
        public void Update(int Num,int CarID)
        {
            var cars = db.Cars.Where(o => o.CartID == CarID).FirstOrDefault();
            cars.Count = Num;
            db.SaveChanges();
        }


        //删除某条订单
        public void Delete(int CartID)
        {
            var Cars = db.Cars.Where(o => o.CartID == CartID).FirstOrDefault();
            db.Cars.Remove(Cars);
            db.SaveChanges();
        }

        //存储订单地址等信息
        public void Order(string Name,string Add,string Tel,string total,int id,DateTime dateTime)
        {
           
            var orders = new Orders()
            {
                UserID=id,
                Tel = Tel,
                Name = Name,
                Address = Add,
                Time = dateTime,
                total = Convert.ToDouble(total)
            };
            db.Orders.Add(orders);
            
            db.SaveChanges();
          

        }


        //下单
        public Cars Pay(int? id, DateTime dateTime,int ID)
        {
            //将选中订单的flag设置为1          
              var  cars = db.Cars.FirstOrDefault(o => o.CartID == id);
              cars.flag = 1;
              db.SaveChanges();  
            //获取书 ID  并修改库存
            var bookid = cars.BookID;
            var books = db.Books.Where(o => o.BookID == bookid).FirstOrDefault();
            books.Amount = books.Amount - cars.Count;
            db.SaveChanges();
            //添加进订单详情         
            var orders = db.Orders.Where(o => o.UserID == ID);
            foreach (var i in orders)
            {
                if (String.Compare(i.Time.Ticks.ToString(), dateTime.Ticks.ToString()) == 0)
                {
                    var OrderID = i.OrderID;
                    var orderdetails = new OrderDetails()
                    {
                        BookID = cars.BookID,
                        Count = cars.Count,
                        UserID = cars.UserID,
                        OrderId = OrderID
                    };
                    db.OrderDetails.Add(orderdetails);
                   
                }
            }
            db.SaveChanges();
            //未将对象设置引用到实例,时间比较有问题  linq不支持trick,tostring....
            #region
            //var Datetime = dateTime.ToString();
            //var Or = db.Orders.Where(o => o.Time.ToString().CompareTo(Datetime) == 0).FirstOrDefault();
            //var OrderID = Or.OrderID;
            ////var OrderID = (from p in db.Orders
            ////         where p.Time.ToString("yyyy-mm-nn aa:bb:cc").CompareTo(dateTime.ToString("yyyy-mm-nn aa:bb:cc")) == 0 && p.UserID == ID
            ////         select p).FirstOrDefault().OrderID;

            //var orderdetails = new OrderDetails()
            //{
            //    BookID = cars.BookID,
            //    Count = cars.Count,
            //    UserID = cars.UserID,
            //    OrderId = OrderID
            //};
            //db.OrderDetails.Add(orderdetails);
            //db.SaveChanges();
            #endregion
            //删除购物车中的订单
            var carts = db.Cars.Where(o => o.CartID == id && o.flag == 1).FirstOrDefault();
            db.Cars.Remove(carts);           
            db.SaveChanges();
            return cars;
        }

        //id用户ID
        public void DirectBuy(int BookID,DateTime dateTime,int ID,int Num)
        {
            var Books = db.Books.Where(o => o.BookID == BookID).FirstOrDefault();
            Books.Amount = Books.Amount - Num;
            db.SaveChanges();
            var orders = db.Orders.Where(o => o.UserID == ID);
            foreach (var i in orders)
            {
                if (String.Compare(i.Time.Ticks.ToString(), dateTime.Ticks.ToString()) == 0)
                {
                    var OrderID = i.OrderID;
                    var orderdetails = new OrderDetails()
                    {
                        BookID = BookID,
                        Count = Num,
                        UserID = ID,
                        OrderId = OrderID
                    };
                    db.OrderDetails.Add(orderdetails);
                }
            }
            db.SaveChanges();
        }


       
    }
}