using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Kongjianban
    {
        //该用户所有的说说
        public IEnumerable<Shuoshuo> UserAllShuo { get; set; }
       //说说的评论
        public IEnumerable<ShuoshuoComment> ShuoCommentById { get; set; }
        //发说说
        public Shuoshuo sendshuo { get; set; }
        //用户上传过的所有文件
        public IEnumerable<Text> userupload{ get; set; }
        //用户上传的视频
        public IEnumerable<Video> uservideo { get; set; }
        //评论
        public ShuoshuoComment comment { get; set; }
        //用户粉丝数量
        public int fennum { get; set; }
    }
}