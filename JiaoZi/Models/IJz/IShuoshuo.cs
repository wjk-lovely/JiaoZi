using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IShuoshuo
    {
        //通过用户id查询所有说说
        IQueryable<Shuoshuo> AllShuoByID(int id);
        //添加说说
        void Add(Shuoshuo shuoshuo);
        //删除说说
        bool delete(int id);
    }
}
