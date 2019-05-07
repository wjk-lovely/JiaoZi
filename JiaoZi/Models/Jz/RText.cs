using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RText:IText
    {
        protected jiaoziEntities db = new jiaoziEntities();
        void IText.addtext(Text text)
        {
            db.Text.Add(text);
            db.SaveChanges();
        }
        IQueryable<Text> IText.UserUploadText(int id)
        {
            return db.Text.OrderByDescending(o=>o.Text_Time).Where(t => t.UserID == id);
        }
    }
}