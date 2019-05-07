using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IVideo
    {
        //查询用户的所有视频
        IQueryable<Video> AllVideoByUserId(int id);
        //添加视频
        void addvideo(Video video);

    }
}
