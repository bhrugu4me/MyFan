using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


public class SignUpProfessionalMemberViewModel
{
    public int categoryID { get; set; }

    private List<SelectListItem> _category { get; set; }

    public List<SelectListItem> CategoryList
    {
        get { return _category; }
    }

    public string JobTitle { get; set; }

    public bool isSelfEmployeed { get; set; }

    public string BusinessPlaceName { get; set; }

    [Required(ErrorMessage = "City/State is required.")]
    public string CityState { get; set; }

    [Required(ErrorMessage = "ZipCode is required.")]
    public string zipcode { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Month is required.")]
    public int month { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    public int year { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public int date { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public bool gender { get; set; }
}
