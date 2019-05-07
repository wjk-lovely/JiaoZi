using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IUser
    {
        
            //登录
            bool Login(int? UserID, string PasswordL);


            //注册
            bool Registe(string TrueName, string PasswordR, string Email);


            //找回密码
            string FindPassword(string Email, string TrueName);
        
    }
}
