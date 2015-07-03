using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MYFAN.BusinessObjects;



public class SignUpMemberTypeViewModel
{
    [Display(Name = "Choose a Member Type")]
    [Required(ErrorMessage = "Please choose a member type.")]
    public MyFanCommon.eMemberType MemberType { get; set; } 
}
