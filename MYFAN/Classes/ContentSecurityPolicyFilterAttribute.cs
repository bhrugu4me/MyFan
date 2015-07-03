using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class ContentSecurityPolicyFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var response = filterContext.HttpContext.Response;
        response.AddHeader("Content-Security-Policy", "frame-src \'none\'");
        response.AddHeader("X-WebKit-CSP", "frame-src \'none\'");
        response.AddHeader("X-Content-Security-Policy", "frame-src \'none\'");
        response.AddHeader("X-Frame-Options", "DENY");
        base.OnActionExecuting(filterContext);
    }
}
