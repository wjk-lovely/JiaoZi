using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JiaoZi.Models;

namespace JiaoZi.Models
{
    public class RRemarkcomments:IRemarkcomments
    {
        IQueryable<RemarkComments> IRemarkcomments.Getcommentsbyid(int id)
        {
            jiaoziEntities db = new jiaoziEntities();
            return db.RemarkComments.OrderByDescending(p => p.RemarkID).Where(p => p.RemarkID == id);
        }
    }
}