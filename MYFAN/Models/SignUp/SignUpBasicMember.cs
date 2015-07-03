using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MYFAN.BusinessObjects;
using System.Web.Mvc;

public class SignUpBasicMember
{
    public int countryId { get; set; }

    private List<SelectListItem> _countryList { get; set; }

    public List<SelectListItem> CountryList
    {
        get
        {
            return (new Helper()).MapContries();
        }
    }

    [Required(ErrorMessage = "City/State is required.")]
    public string CityState { get; set; }

    [Required(ErrorMessage = "ZipCode is required.")]
    public string zipcode { get; set; }

    [Required(ErrorMessage = "Month is required.")]
    public int month { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    public int year { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public int date { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public bool gender { get; set; }

    [Required(ErrorMessage = "Current profession is required.")]
    public MyFanCommon.eBasicMemberType currenttype { get; set; }
}
