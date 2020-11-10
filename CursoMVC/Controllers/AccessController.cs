using CursoMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (cursomvcEntities db = new cursomvcEntities())
                {
                    IQueryable<user> list = from d in db.user where d.email == user && d.password == password && d.idState == 1 select d;

                    if (list.Count() > 0)
                    {
                        user oUser = list.First();
                        Session["user"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido...");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un erro: " + ex.Message);
            }
        }
    }
}