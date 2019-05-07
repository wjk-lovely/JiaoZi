using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RKongjian:IKongjian
    {
        protected jiaoziEntities db = new jiaoziEntities();
        //用户粉丝
        IQueryable<Attention> IKongjian.fens(int userid)
        {
            return db.Attention.Where(f => f.Attention_UserID == userid);

        }
        //用户关注
        IQueryable<Attention> IKongjian.attention(int userid)
        {

            return db.Attention.Where(a => a.UserID == userid);
        }
        //添加关注
        void IKongjian.addattention(Attention attention)
        {
            db.Attention.Add(attention);
            db.SaveChanges();
        }
        bool IKongjian.deleteattention(int id)
        {
            Attention attention = db.Attention.Where(b => b.AttentionID==id).FirstOrDefault();
            if (attention != null)
            {
                db.Attention.Remove(attention);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        IQueryable<ShuoshuoComment_Reply> IKongjian.allshuoshuocommentreply(int shuoshuocommentid)
        {
            return db.ShuoshuoComment_Reply.Where(b => b.ShuoshuoCommentID == shuoshuocommentid);
        }
        void IKongjian.addshuocommentreply(ShuoshuoComment_Reply shuocommentreply)
        {
            db.ShuoshuoComment_Reply.Add(shuocommentreply);
            db.SaveChanges();
        }
      
    }
}