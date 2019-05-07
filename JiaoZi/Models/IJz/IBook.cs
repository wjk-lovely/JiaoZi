using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    public  interface IBook
    {
        IList<salestop3> FindAllBookName();
        //近期发表书籍
        IQueryable<Books>BookByTime(int a, int b);
    }
}
