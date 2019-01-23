using FileUploader.Models;
using System.Web.Mvc;

namespace FileUploader.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Upload
        public ActionResult Upload(string Message)
        {
            ViewBag.Message = Message;
            return View();
        }

        // POST: Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(UploadViewModel model)
        {
            var result = Uploader.Upload(model.File, UploadPath.IMAGE_FOLDER);

            if (result.Error)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(model);
            }
            else
            {
                return RedirectToAction("Upload", new { Message = "The file was successfully uploaded" });
            }
        }
    }
}