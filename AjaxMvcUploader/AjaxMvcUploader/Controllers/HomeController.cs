using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMvcUploader.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /File/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UploadFile(HttpPostedFileBase file)
        {
            var result = DoSomethingWithFile(file);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private bool DoSomethingWithFile(HttpPostedFileBase file)
        {
            try
            {
                var strFileLocation = "/temp/" + file.FileName;

                file.SaveAs(HttpContext.Server.MapPath(strFileLocation));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
	}
}