using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
public class LoginViewModel
{
    #region properties

    [Required(ErrorMessage = "Email Address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(254, MinimumLength = 6, ErrorMessage = "Invalid Email Address or Password.")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "Invalid Email Address or Password.")]
    public string Password { get; set; }
    public bool iskeepSignin { get; set; }

    #endregion

    #region Methods

    internal bool validate(LoginViewModel login)
    {
        if (login.EmailAddress == "sysadmin@myamdin.com" && login.Password == "Password")
        {
            return true;
        }
        return false;
    }

    #endregion


}