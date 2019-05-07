using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IMall
    {
        IEnumerable<Books> GetBooks();
        Books GetBooksById(int? id);
        IEnumerable<Books> Search(string search);
        IEnumerable<Books> GetBooksByAmount();
        IEnumerable<Category> Category();
        IEnumerable<Books> GetBooksByPrice();
        IEnumerable<Books> GetBooksByTime();
        void AddBooks(int Num, int BookID, int UserID);
        IEnumerable<Books> GetBooksByCategory(int id);
        void AddComment(BookComment comment);
        IEnumerable<Cars> Cars(int? id);
        IEnumerable<Orders> Ord(int? id);
        IEnumerable<OrderDetails> OrderDetails(int? id);
        Cars Pay(int? id, DateTime dateTime,int ID);
        void Order(string Name, string Add, string Tel, string total, int id, DateTime dateTime);
        void Update(int Num, int CarID);
        void Delete(int CartID);
        void DirectBuy(int BookID, DateTime dateTime, int ID, int Num);
        void BbookComments(int UserID, int BookID, string Comment_Content, DateTime dateTime);
       
        void BookReply(int id, int UserID, DateTime dateTime, string Re_Content, int ReID);

    }
}
