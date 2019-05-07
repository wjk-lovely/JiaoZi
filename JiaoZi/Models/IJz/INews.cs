using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface INews
    {
        //查询日期最新前跳a,取b条新闻
        IQueryable<News> NewsByTime(int a,int b);
        ////跳过前3条取7条
        //IQueryable<News> NewsByTime2();
    }
}
