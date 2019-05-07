using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IText
    {
        //添加文本
        void addtext(Text text);
        //通过用户id获取文件
        IQueryable<Text> UserUploadText(int id);
    }
}
