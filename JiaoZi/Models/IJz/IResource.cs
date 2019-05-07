using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IResource
    {
        //最新文本资源
        IQueryable<TextResource> ResourceByTime(int a, int b);
        //所有文本资源资源
        IEnumerable<TextResource> alltextresource();
        //所有视频资源
        IEnumerable<VideoResource> allvideoresource();
        //通过年级类别查文本资源
        IQueryable<TextResource>TextResourceByStage(string stage);
        //通过年级类别查资源
        IQueryable<VideoResource>VideoResourceByStage(string stage);
        //通过名称查找视频
        IQueryable<VideoResource> searchvideoresource(string name);
        //通过名称查找文本
        IQueryable<TextResource> searchtextresource(string name);

    }
}
