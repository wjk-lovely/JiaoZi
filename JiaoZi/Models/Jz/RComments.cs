using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RComments:IComments
    {
        protected jiaoziEntities db = new jiaoziEntities();
         void IComments.Comments(RemarkComments res)
        {
            db.RemarkComments.Add(res);
          
            db.SaveChanges();
          

        }
    }
}