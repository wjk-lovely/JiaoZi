using JiaoZi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IRemarksbytime
    {
        IList<Remark_User_Comments_Reply> Contentbytime();
    }
}
