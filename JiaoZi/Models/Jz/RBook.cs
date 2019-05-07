using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RBook:IBook
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IList<salestop3> IBook.FindAllBookName()
        {
            return db.salestop3.ToList();
        }
        //近期发表书籍
        IQueryable<Books> IBook.BookByTime(int a, int b)
        {
            var book =  from o in db.Books
                orderby o.IssueTime
                select o;
            //foreach (var news in news1)
            return book.Skip(a).Take(b);
        }
    }
}