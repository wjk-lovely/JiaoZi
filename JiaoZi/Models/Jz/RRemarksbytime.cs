using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RRemarksbytime: IRemarksbytime
    {
        private jiaoziEntities db = new jiaoziEntities();
        IList<Remark_User_Comments_Reply> IRemarksbytime.Contentbytime()
        {
            //IList< Remark_User_Comments_Reply> li=
            return db.Remark_User_Comments_Reply.OrderByDescending(r=>r.Remark_time).ToList();
        }
    }
}
    
