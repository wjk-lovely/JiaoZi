using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IReply
    {
        void Reply(RemarkReply rep,int pinglunid);
        IQueryable<RemarkReply> FindRemarksBycommentid(int id);
    }
}
