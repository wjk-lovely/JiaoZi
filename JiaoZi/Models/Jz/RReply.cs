using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RReply:IReply
    {
        jiaoziEntities db = new jiaoziEntities();
        void IReply.Reply(RemarkReply rep,int pinglunid)
        {
            db.RemarkReply.Add(rep);
            db.SaveChanges();
        }
        IQueryable<RemarkReply> IReply.FindRemarksBycommentid(int id)
        {
            return db.RemarkReply.Where(b=>b.RemarkCommentID==id);
        }
    }
}