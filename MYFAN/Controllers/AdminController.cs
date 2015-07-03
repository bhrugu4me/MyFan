using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYFAN.Presentation.Controllers
{
    public class AdminController : Controller
    {

        #region "Category"

        public ActionResult Index()
        {
            ManageCategoryViewModel vmCategory = new ManageCategoryViewModel();
            vmCategory.Read();
            return View(vmCategory);
        }

        [ActionName("create-category")]
        public ActionResult CreateCategory()
        {
            CategoryViewModel vmCategory = new CategoryViewModel();
            return View(vmCategory);
        }

        [HttpPost]
        [ActionName("create-category")]
        public ActionResult CreateCategory(CategoryViewModel model)
        {
            try
            {
                int id = model.Create();
                if (id > 0)
                {
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        [ActionName("update-category")]
        public ActionResult UpdateCategory(int id)
        {
            CategoryViewModel vmCategory = new CategoryViewModel();
            vmCategory.Read(id);
            return View(vmCategory);
        }

        [HttpPost]
        [ActionName("update-category")]
        public ActionResult UpdateCategory(CategoryViewModel model)
        {
            try
            {
                bool result = model.Update();
                if (result)
                {
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        #endregion

        #region "states"


        [ActionName("states")]
        public ActionResult ViewStateIndex()
        {
            ManageStateViewModel vmState = new ManageStateViewModel();
            vmState.Read();
            return View(vmState);
        }

        [ActionName("create-state")]
        public ActionResult CreateState()
        {
            StateViewModel vmState = new StateViewModel();
            return View(vmState);
        }

        [HttpPost]
        [ActionName("create-state")]
        public ActionResult CreateState(StateViewModel model)
        {
            try
            {
                int id = model.Create();
                if (id > 0)
                {
                    return RedirectToAction("states");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        [ActionName("update-state")]
        public ActionResult UpdateState(int id)
        {
            StateViewModel vmState = new StateViewModel();
            vmState.Read(id);
            return View(vmState);
        }

        [HttpPost]
        [ActionName("update-state")]
        public ActionResult UpdateState(StateViewModel model)
        {
            try
            {
                bool result = model.Update();
                if (result)
                {
                    return RedirectToAction("states");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        #endregion

        #region "Cities"

        [ActionName("cities")]
        public ActionResult ViewCityIndex()
        {
            ManageCityViewModel vmCity = new ManageCityViewModel();
            vmCity.Read();
            return View(vmCity);
        }
        [ActionName("create-city")]
        public ActionResult CreateCity()
        {
            CityViewModel vmCity = new CityViewModel();
            return View(vmCity);
        }
        [ActionName("create-city")]
        [HttpPost]
        public ActionResult CreateCity(CityViewModel model)
        {
            try
            {
                int id = model.Create();
                if (id > 0)
                {
                    return RedirectToAction("cities");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        [ActionName("update-city")]
        public ActionResult UpdateCity(int id)
        {
            CityViewModel vmState = new CityViewModel();
            vmState.Read(id);
            return View(vmState);
        }

        [HttpPost]
        [ActionName("update-city")]
        public ActionResult UpdateCity(CityViewModel model)
        {
            try
            {
                bool result = model.Update();
                if (result)
                {
                    return RedirectToAction("cities");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        #endregion

        #region "Countries"

        [ActionName("countries")]
        public ActionResult ViewCountryIndex()
        {
            ManageCountryViewModel vmCountry = new ManageCountryViewModel();
            vmCountry.Read();
            return View(vmCountry);
        }


        [ActionName("create-country")]
        public ActionResult CreateCountry()
        {
            CountryViewModel vmCountry = new CountryViewModel();
            return View(vmCountry);
        }

        [HttpPost]
        [ActionName("create-country")]
        public ActionResult CreateCountry(CountryViewModel model, HttpPostedFileBase uploadIcon, HttpPostedFileBase uploadImage)
        {
            try
            {
                model.Icon = savefile(uploadIcon, model.Name + "_icon");
                model.Image = savefile(uploadImage, model.Name + "_image");
                int id = model.Create();
                if (id > 0)
                {
                    return RedirectToAction("countries");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        private string savefile(HttpPostedFileBase uploadFile, string name)
        {
            if (uploadFile.ContentLength > 0)
            {
                string[] fileextension = uploadFile.FileName.Split('.');
                string relativePath = "/Content/img/Country/" + Path.GetFileName("County_" + name.Trim() + "." + fileextension[1]);
                string physicalPath = Server.MapPath("~" + relativePath);
                uploadFile.SaveAs(physicalPath);
                return relativePath;
            }
            return "";

        }


        [ActionName("update-country")]
        public ActionResult UpdateCountry(int id)
        {
            CountryViewModel vmCountry = new CountryViewModel();
            vmCountry.Read(id);
            return View(vmCountry);
        }

        [HttpPost]
        [ActionName("update-country")]
        public ActionResult UpdateCountry(HttpPostedFileBase uploadIcon, HttpPostedFileBase uploadImage, CountryViewModel model)
        {
            try
            {
                if (uploadImage != null)
                {
                    model.Image = savefile(uploadImage, model.Name + "_image");
                }
                if (uploadIcon != null)
                {
                    model.Icon = savefile(uploadIcon, model.Name + "_icon");
                }
                bool result = model.Update();
                if (result)
                {
                    return RedirectToAction("countries");
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //[ActionName("upload-country")]
        //public ActionResult uploadCounty(HttpPostedFileBase uploadFile)
        //{
        //    if (uploadFile.ContentLength > 0)
        //    {
        //        string relativePath = "~/Content/img/" + Path.GetFileName(uploadFile.FileName);
        //        string physicalPath = Server.MapPath(relativePath);
        //        uploadFile.SaveAs(physicalPath);
        //        return View((object)relativePath);
        //    }
        //    return View();
        //}
        #endregion
    }
}