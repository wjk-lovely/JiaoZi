using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{

    public class RShuoshuocomment:IShuoshuocomment
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<ShuoshuoComment> IShuoshuocomment.ShuoCommentById(int shuoid)
        {
            return db.ShuoshuoComment.Where(b => b.ShuoshuoID == shuoid);
        }
        void IShuoshuocomment.addshuocomment(ShuoshuoComment shuoshuocomment)
        {
            db.ShuoshuoComment.Add(shuoshuocomment);
            db.SaveChanges();
        }
        bool IShuoshuocomment.deletecomment(int commentid)
        {
            ShuoshuoComment shuoshuocomment = db.ShuoshuoComment.Where(b => b.ShuoshuoCommentID ==commentid).FirstOrDefault();
            if (shuoshuocomment != null)
            {
                db.ShuoshuoComment.Remove(shuoshuocomment);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}