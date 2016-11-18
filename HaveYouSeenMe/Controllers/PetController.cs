using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaveYouSeenMe;
using HaveYouSeenMe.Models.Business;
using HaveYouSeenMe.Models;
using System.IO;

namespace HaveYouSeenMe.Controllers
{
    public class PetController : Controller
    {

        private IRepository _repository;

        // GET: Pet
        public ActionResult Index()  //create view here
        {
            return View();
        }

        public ActionResult GetPhoto()
        {
            var name = (string)RouteData.Values["id"];
            ViewBag.Photo = string.Format("/Content/Uploads/thumbnail_{0}.jpg", name);

            return PartialView();
        }




        //public ActionResult Display()
        //{
        //    var name = (string)RouteData.Values["id"];  //value of id in default route
        //    var model = PetManagement.GetByName(name);  //this is a business model, will manage all pet transactions here

        //    if (model == null)
        //    {
        //        return RedirectToAction("NotFound");
        //    }
        //    return View(model);
        //}

        public FileResult DownloadPetPicture()  //allow user to download picture of animal in db
        {
            var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";  //path to picture
            var contentType = "image/jpg";
            var fileName = name + ".jpg";  //comment this line to display image rather than allow download
            return File(picture, contentType, fileName); //remove fileName when display image only, not download
        }

        public ActionResult PictureUpload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model)
        {
            if (model.PictureFile.ContentType != "image/jpeg" && model.PictureFile.ContentType != "image/png")
            {
                return View();
            }

           



            if (model.PictureFile.ContentLength > 0)  //looks for length of content file.  If not < 0, there is no content
            {
                var fileName = Path.GetFileName(model.PictureFile.FileName);
                var filePath = Server.MapPath("/Content/Uploads");
                string savedFileName = Path.Combine(filePath, fileName);
                model.PictureFile.SaveAs(savedFileName);
                var pm = new PetManagement();
                pm.CreateThumbnail(fileName, filePath, 100, 100, true);

                ViewBag.UploadResult = "Sucess";
                
            }
            return View(model);
        }

        public ActionResult NotFound()
        {
            return View(); //create view here
        }

        public ActionResult NotFoundError()
        {
            return HttpNotFound("Nothing here...");
        }

        public HttpStatusCodeResult CustomError()
        {
            return new HttpStatusCodeResult(500, "Custom Error");
        }

        public ActionResult DisplayHttpNotFound()
        {
            var name = (string)RouteData.Values["id"];
            var pm = new PetManagement(_repository);
            var model = pm.GetByName(name);

            if (model == null)
            {
                return HttpNotFound("Pet not found...");
            }
            return View(model);
        }
    }
}