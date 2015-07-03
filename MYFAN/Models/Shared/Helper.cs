using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public class Helper
{
    internal List<SelectListItem> MapCategories()
    {
        List<SelectListItem> list = new List<SelectListItem>();
        list.Add(new SelectListItem() { Text = "select category", Value = "-1" });
        foreach (MYFAN.BusinessObjects.Category collection in (new MYFAN.BusinessLogic.Category()).ReadAll())
        {
            list.Add(new SelectListItem() { Text = Convert.ToString(collection.Name), Value = Convert.ToString(collection.ID) });
        }
        return list;
    }


    internal List<SelectListItem> MapContries()
    {
        List<SelectListItem> list = new List<SelectListItem>();
        foreach (MYFAN.BusinessObjects.Country collection in (new MYFAN.BusinessLogic.Country()).ReadAll())
        {
             list.Add(new SelectListItem() { Text = Convert.ToString(collection.Name), Value = Convert.ToString(collection.ID) });
        }
        return list;
    }
    
    internal List<SelectListItem> MapSates()
    {
        List<SelectListItem> list = new List<SelectListItem>();
        foreach (MYFAN.BusinessObjects.State collection in (new MYFAN.BusinessLogic.State()).ReadAll())
        {
             list.Add(new SelectListItem() { Text = Convert.ToString(collection.Name), Value = Convert.ToString(collection.ID) });
        }
        return list;
    }
}
