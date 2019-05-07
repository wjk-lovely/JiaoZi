using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RFatie:IFatie
    {
        protected jiaoziEntities db = new jiaoziEntities();
       void IFatie.publishremarks(Remarks re)
        {
           
            db.Remarks.Add(re);
            db.SaveChanges();
            
        }
    }
}