using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


public class SignUpLocalBusinessViewModel
{
    public int categoryID { get; set; }

    private List<SelectListItem> _category { get; set; }

    public List<SelectListItem> CategoryList
    {
        get { return _category; }
    }

    public string BusinessPlaces { get; set; }

    public string StreetAddress { get; set; }

    [Required(ErrorMessage = "City/State is required.")]
    public string CityState { get; set; }

    [Required(ErrorMessage = "ZipCode is required.")]
    public string zipcode { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    public string Phone { get; set; }

    public SignUpLocalBusinessViewModel()
    {
        _category = new List<SelectListItem>();
        _category.Add(new SelectListItem { Text = "Choose a Category", Value = "-1", Selected = true });
    }
}
