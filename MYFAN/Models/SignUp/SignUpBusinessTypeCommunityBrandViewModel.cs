using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MYFAN.BusinessObjects;

public class BusinessTypeCommunityBrandViewModel
{
    public int categoryID { get; set; }

    private List<SelectListItem> _category { get; set; }

    public List<SelectListItem> CategoryList
    {
        get { return _category; }
    }

    public string companyname { get; set; }

    public MyFanCommon.eBusinessTypePage BusinessType { get; set; }

    public void New(MyFanCommon.eBusinessTypePage businessType)
    {
        this.BusinessType = businessType;
    }
}
