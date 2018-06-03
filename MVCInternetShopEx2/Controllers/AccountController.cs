using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInternetShopEx2
{
    public class AccountController : Controller
    {
        public ActionResult Registration()
        {            
            RegistrUser user = null;
            if (Session["user"] == null)
            {
                ViewBag.userShowHide = "userHide";
            }
            else
            {
                user = (RegistrUser)Session["user"];
                ViewBag.user = user.Name;
            }
            ViewBag.validation = "validationSummaryHide";
            ViewBag.validationLogin = "validationSummaryHide";
            return View();
        }

        public ActionResult Authorization()
        {
            ViewBag.validation = "validationSummaryHide";
            ViewBag.validationLogin = "validationSummaryHide";
            return View();
        }

        public ActionResult WelcomePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrUser regUser)
        {
            if (ModelState.IsValid)
            {
                DAOImplements DAOImpl = new DAOImplements();
                List<RegistrUser> user = DAOImpl.GetAllUser();
                for (int i = 0; i < user.Count; i++)
                {
                    if (regUser.Login.Equals(user[i].Login) || regUser.Email.Equals(user[i].Email))
                    {
                      
                        ViewBag.ErrorMassage = "User with such login or e-mail already exists";
                        ViewBag.validation = "validationSummaryHide";
                        ViewBag.validationLogin = "validationSummaryShow";
                        return View("Registration", regUser);
                    }                  
                }             
                DAOImpl.SaveUser(regUser.Login, regUser.Password, regUser.Email, regUser.Gender, regUser.Year, regUser.Day, regUser.Months, regUser.Name, regUser.Surename);
                return View("WelcomePage");
            }
            ViewBag.validation = "validationSummaryShow";
            ViewBag.validationLogin = "validationSummaryHide";
            return View("Registration", regUser);
        }

        [HttpPost]
        public ActionResult Authorization(AuthorizationUser authorUser)
        {
            if (ModelState.IsValid)
            {
                DAOImplements DAOImpl = new DAOImplements();
                List<RegistrUser> user = DAOImpl.GetAllUser();
                for (int i = 0; i < user.Count; i++)
                {
                    if (authorUser.Login.Equals(user[i].Login) && authorUser.Password.Equals(user[i].Password))
                    {
                        Session["user"] = user[i];
                        return RedirectToAction("Index", "Home");
                    }
                }
                ViewBag.ErrorMassage = "User with such login or does not exist, or password is incorrectly entered";
                ViewBag.validation = "validationSummaryHide";
                ViewBag.validationLogin = "validationSummaryShow";
                return View(authorUser);
            }
            ViewBag.validation = "validationSummaryShow";
            ViewBag.validationLogin = "validationSummaryHide";
            return View(authorUser);
        }
    }
}