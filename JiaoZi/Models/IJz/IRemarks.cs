using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IRemarks
    {
        IQueryable<Remarks> FindRemarksByID(int id);



        //List<Iviewmodel> Findbyid(int id);

    }
}
