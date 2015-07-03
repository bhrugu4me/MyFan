using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public class SingUpViewModel
{
    #region properties
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(50, ErrorMessage = "First Name is maximum 50 character.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50, ErrorMessage = "Last Name is maximum 50 character.")]
    public string LastName { get; set; }


    [Required(ErrorMessage = "Email Address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(254, MinimumLength = 6, ErrorMessage = "Invalid Email Address or Password.")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Email Address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(254, MinimumLength = 6, ErrorMessage = "Invalid Email Address or Password.")]
    public string ConfirmEmailAddress { get; set; }



    #endregion

    #region methods

    #endregion
}
