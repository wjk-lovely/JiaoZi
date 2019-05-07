using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class BooksDetails
    {
        public IEnumerable<BookComment> Bc{ get;set;}
        public string Comment_Content { get; set; }
        public Books B { get; set; }
        public BooksDetails(int id)
        {
            
            jiaoziEntities db = new jiaoziEntities();
            Bc = db.BookComment.Where(o => o.BookID == id);
            B= db.Books.Where(b => b.BookID == id).FirstOrDefault();
        }
        
    }
}