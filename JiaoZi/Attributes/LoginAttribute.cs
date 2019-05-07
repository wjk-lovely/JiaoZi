using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaoZi.Attributes
{
    public class LoginAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext.Session["User_id"] == null)
            {

                ContentResult cr = new ContentResult();
                cr.Content = "<script>alert('您尚未登陆，请登陆'); window.window.location.href = '/UserInfo/RegisteLogin'</script>";

                filterContext.Result = cr;
            }
        }
    }
}