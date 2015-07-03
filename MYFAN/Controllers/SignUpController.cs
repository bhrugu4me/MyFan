using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYFAN.Presentation.Controllers
{
    public class SignUpController : Controller
    {
        [ActionName("signup")]
        public ActionResult SignUp()
        {
            SingUpViewModel vmSignUp = new SingUpViewModel();
            return View(vmSignUp);
        }

        [ActionName("signup")]
        [HttpPost()]
        public ActionResult SignUp(SingUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                Session["BasicSignUp"] = model;
                return RedirectToAction("signup-options");
            }
            return View(model);
        }

        [ActionName("signup-options")]
        public ActionResult SignUpOption()
        {
            SignUpMemberTypeViewModel vmOptionModel = new SignUpMemberTypeViewModel();
            return View(vmOptionModel);
        }

        [ActionName("signup-options")]
        [HttpPost()]
        public ActionResult SignUpOption(SignUpMemberTypeViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.MemberType == BusinessObjects.MyFanCommon.eMemberType.Business)
                {
                    return RedirectToAction("signup-business");
                }
                else if (model.MemberType == BusinessObjects.MyFanCommon.eMemberType.Normal)
                {
                    return RedirectToAction("signup-basic");
                }
                else
                {
                    return RedirectToAction("signup-professional");
                }

            }
            return View(model);
        }

        [ActionName("signup-professional-option")]
        public ActionResult SignUpProfessionlOption()
        {
            SignUpProfessionalType vmProfType = new SignUpProfessionalType();
            return View(vmProfType);
        }

        [ActionName("signup-business-option")]
        public ActionResult SignUpBusinessOption()
        {
            SignUpBusinessTypeViewModel vmBusinessType = new SignUpBusinessTypeViewModel();
            return View(vmBusinessType);
        }

        [ActionName("signup-basic")]
        public ActionResult SignUpBasicMember()
        {
            SignUpBasicMember vmBasicMember = new SignUpBasicMember();
            return View(vmBasicMember);
        }

        [ActionName("signup-business-member")]
        public ActionResult SignUpBusinessMember()
        {
            BusinessTypeCommunityBrandViewModel vmBusinessMembers = new BusinessTypeCommunityBrandViewModel();
            return View(vmBusinessMembers);
        }

        [ActionName("signup-business-local")]
        public ActionResult SignUpBusinessLocalMember()
        {
            SignUpLocalBusinessViewModel vmBusinessMembers = new SignUpLocalBusinessViewModel();
            return View(vmBusinessMembers);
        }

        [ActionName("signup-professional")]
        public ActionResult SignUpProfessionalMember()
        {
            SignUpProfessionalMemberViewModel vmProfMembers = new SignUpProfessionalMemberViewModel();
            return View(vmProfMembers);
        }


    }
}