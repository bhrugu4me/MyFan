//using System.Web.Http.Filters;
//using System.Web.Http.Controllers;
//using System.Reflection;
//using System.Web.Mvc;
//using System.Collections.Generic;
//using System;
//public class Sanitize : ActionFilterAttribute
//{

//    public override void OnActionExecuting(HttpActionContext actionContext)
//    {
//        CleanParams(actionContext.ActionArguments);
//        base.OnActionExecuting(actionContext);
//    }

//    // '' <summary>
//    // '' Loop through the action arguments and sanitize them
//    // '' </summary>
//    // '' <param name="Collection"></param>
//    // '' <remarks></remarks>
//    private static void CleanParams(Dictionary<String, object> Collection)
//    {
//        //Regex _inputCleaner = new Regex("<[^>]+>", RegexOptions.Compiled);
//        Dictionary<string, object> Params = new Dictionary<string, object>();
//        foreach (var item in Collection.Keys)
//        {
//            if (Collection[item].GetType().ToString() == "String")
//            {
//                //if (string.IsNullOrWhiteSpace(Collection[item]))
//                //{
                    
//                //}
//            }
//        }
//        //foreach (Key in Collection.Keys) {
//        //    if ((Collection.Item[Key].GetType() == System.String)) {
//        //        if (string.IsNullOrWhiteSpace(Collection.Item[Key])) {
//        //            Params.Add(Key, Collection.Item[Key]);
//        //            // TODO: Continue For... Warning!!! not translated
//        //        }
//        //        Params.Add(Key, HttpUtility.HtmlEncode(_inputCleaner.Replace(Collection.Item[Key], String.Empty)));
//        //    }
//        //    else {
//        //        Params.Add(Key, Collection.Item[Key]);
//        //    }
//        //}
//        //Collection.Clear();
//        //if ((Params.Count > 0)) {
//        //    foreach (Key in Params.Keys) {
//        //        Collection.Add(Key, Params.Item[Key]);
//        //    }
//        //}
//    }
//}
