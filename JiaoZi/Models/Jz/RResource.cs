using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RResource:IResource
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<TextResource> IResource.ResourceByTime(int a, int b)
        {
            var resource =
                from o in db.TextResource
                orderby o.Text_Time
                select o;
            //foreach (var news in news1)
            return resource.Skip(a).Take(b);

        }
        IEnumerable<TextResource> IResource.alltextresource()
        {
            return db.TextResource.ToList();
        }
        //所有视频资源
        IEnumerable<VideoResource> IResource.allvideoresource()
        {
            return db.VideoResource;
        }
        //通过年级类别查文本资源
        IQueryable<TextResource> IResource.TextResourceByStage(string stage)
        {
            return db.TextResource.Where(b => b.Stage == stage);
        }
        //通过年级类别查资源
        IQueryable<VideoResource> IResource.VideoResourceByStage(string stage)
        {
            return db.VideoResource.Where(b => b.Stage == stage);
        }
        //通过名称查找视频
        IQueryable<VideoResource> IResource.searchvideoresource(string name)
        {
            var video = from v in db.VideoResource
                        where v.Video_Name.Contains(name)
                        select v;
            return video;
        }
        //通过名称查找文本
        IQueryable<TextResource> IResource.searchtextresource(string name)
        {
            var text = from t in db.TextResource
                       where t.Text_Name.Contains(name)
                       select t;
            return text;
        }
    }
}