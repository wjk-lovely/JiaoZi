using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class ResourceViewModel
    {
        //所有文本资源
      public IEnumerable<TextResource> alltextresource { get; set; }
        //所有视频资源
       public IEnumerable<VideoResource> allvideoresource { get; set; }
        //幼儿文本资源
       public IEnumerable<TextResource> youertextresource { get; set; }
        //幼儿视频资源
       public IEnumerable<VideoResource> youervideoresource { get; set; }
        //小学文本资源
       public IEnumerable<TextResource> xiaoxuetextresource { get; set; }
        //小学视频资源
       public IEnumerable<VideoResource> xiaoxuevideoresource { get; set; }
        //初中文本资源
       public IEnumerable<TextResource> chuzhongtextresource { get; set; }
        //初中视频资源
       public IEnumerable<VideoResource> chuzhongvideoresource { get; set; }
        //高中文本资源
       public IEnumerable<TextResource> gaozhongtextresource { get; set; }
        //高中视频资源
       public IEnumerable<VideoResource> gaozhongvideoresource { get; set; }
        //搜索出来的视频资源
        public IEnumerable<VideoResource> searchvideoresource { get; set; }
        //搜索出来的文本资源
        public IEnumerable<TextResource> searchtextresource { get; set; }

    }
}