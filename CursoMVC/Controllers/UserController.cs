using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (cursomvcEntities db = new cursomvcEntities())
            {
                lst = (from d in db.user
                       where d.idState == 1
                       orderby d.id
                       select new UserTableViewModel
                       {
                           Email = d.email,
                           Id = d.id,
                           Edad = d.edad
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (cursomvcEntities db = new cursomvcEntities())
            {
                user oUser = new user
                {
                    idState = 1,
                    email = model.Email,
                    edad = model.Edad,
                    password = model.Password
                };

                db.user.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();
            using (cursomvcEntities db = new cursomvcEntities())
            {
                user oUser = db.user.Find(Id);
                model.Edad = (int)oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (cursomvcEntities db = new cursomvcEntities())
            {
                user oUser = db.user.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;

                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (cursomvcEntities db = new cursomvcEntities())
            {
                var oUser = db.user.Find(Id);
                oUser.idState = 2; //Eliminar

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}