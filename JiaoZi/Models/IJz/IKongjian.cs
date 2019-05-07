using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IKongjian
    {
        //通过用户id查找粉丝
        IQueryable<Attention> fens(int userid);
        //通过用户id查找关注
        IQueryable<Attention> attention(int userid);
        //添加关注
        void addattention(Attention attention);
        //删除关注
        bool deleteattention(int id);
        //通过说说评论id找说说评论回复
        IQueryable<ShuoshuoComment_Reply> allshuoshuocommentreply(int shuoshuocommentid);
        //添加评论回复
        void addshuocommentreply(ShuoshuoComment_Reply shuocommentreply);
    }
}
