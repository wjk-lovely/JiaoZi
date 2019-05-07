using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RUser:IUser
    {
        public string FindPassword(string Email, string TrueName)
        {
            using (jiaoziEntities db = new jiaoziEntities())
            {
                var passwords = db.Users.Where(m => m.Email == Email && m.TrueName == TrueName).FirstOrDefault();
                if (passwords != null)
                {
                    var password = passwords.Password;
                    return password;
                }
                else
                {
                    string message = "提交信息有误，找回密码失败！";
                    return message;
                }
            }
        }
        public bool Login(int? UserID, string PasswordL)
        {
            using (jiaoziEntities db = new jiaoziEntities())
            {
                var users = db.Users.Where(x => x.UserID == UserID && x.Password == PasswordL).FirstOrDefault();
                if (users != null)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public bool Registe(string TrueName, string PasswordR, string Email)
        {
            using (jiaoziEntities db = new jiaoziEntities())
            {

                if (db.Users.Any(x => x.Email == Email))
                {
                    return false;
                }
                else
                {
                    var users = new Users()
                    {
                        TrueName = TrueName,

                        Password = PasswordR,
                        Email = Email
                    };
                    db.Users.Add(users);
                    db.SaveChanges();
                    return true;
                }
            }
        }
    }
}