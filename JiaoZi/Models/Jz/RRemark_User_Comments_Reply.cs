using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RRemark_User_Comments_Reply: IRemark_User_Comments_Reply
    {
        private jiaoziEntities db = new jiaoziEntities();
        IList<Remark_User_Comments_Reply> IRemark_User_Comments_Reply.Getsall()
        {
            return db.Remark_User_Comments_Reply.ToList();
        }
    }
}