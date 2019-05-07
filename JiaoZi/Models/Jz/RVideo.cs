using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RVideo:IVideo
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<Video> IVideo.AllVideoByUserId(int id)
        {
            return db.Video.Where(b => b.UserID == id);
        }
        void IVideo.addvideo(Video video)
        {
            db.Video.Add(video);
            db.SaveChanges();
        }
    }
}