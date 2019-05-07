using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RRemarks:IRemarks
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<Remarks> IRemarks.FindRemarksByID(int id)
        {
            return db.Remarks.Where(b => b.RemarkID == id);
        }
        //List<Iviewmodel> IRemarks.Findbyid(int id)
        //{
        //    return Iviewmodel.Equals(List < Remarks > remList, List < RemarkComments > comList);
        //}
    }
}