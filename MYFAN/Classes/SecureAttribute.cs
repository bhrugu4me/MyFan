using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
public class SecureAttribute : System.Web.Mvc.ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.ActionDescriptor.ControllerDescriptor.ToString().ToLower() == "home" || filterContext.HttpContext.User.Identity.Name == String.Empty)
        {
            base.OnActionExecuting(filterContext);
            return;
        }
        HttpResponseBase res = filterContext.HttpContext.Response;
        base.OnActionExecuting(filterContext);
    }  

} 