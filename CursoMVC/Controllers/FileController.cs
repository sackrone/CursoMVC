using CursoMVC.Models.ViewModels;
using System.IO;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Save(FlieViewModel model)
        {
            string RutaSitio = Server.MapPath("~/");
            string PathFile1 = Path.Combine(RutaSitio + "/Files/File_1.png");
            string PathFile2 = Path.Combine(RutaSitio + "/Files/File_2.png");

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            model.Archivo1.SaveAs(PathFile1);
            model.Archivo2.SaveAs(PathFile2);

            @TempData["Message"] = "Se Guardaron los archivos";
            return RedirectToAction("Index");
        }
    }
}