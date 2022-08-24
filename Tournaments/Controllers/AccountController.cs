using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tournaments.DAL;
using Tournaments.Models;
using Tournaments.Common;
using System.Data.Entity.Validation;
using Tournaments.ViewModels;
using System.Data;

namespace Tournaments.Controllers
{
    public class AccountController : Controller
    {

        private RepositoryWrapper repositorywrapper;

        private static AppDbContext DbContext = new AppDbContext();
        public AccountController() : this(new RepositoryWrapper(DbContext)) { }

        public AccountController(RepositoryWrapper _repository) => repositorywrapper = _repository;


        // GET: Account
        public ActionResult Login()
        {
            
            return View();
        }

        public ActionResult Signup()
        {


            return View();
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel _user)
        {
            //_user.ConfirmPassword = _user.Password;

            try
            {

                if (ModelState.IsValid)
                {
                    Password ep = new Password();
                    _user.Password = ep.Encode(_user.Password);
                    Users _U = new Users();
                    _U.Username = _user.Username;
                    _U.Password = _user.Password;

                    bool uE = repositorywrapper.User.UserExist(_U);
                    Users u = repositorywrapper.User.FirstDefault(_U);

                    if (uE)
                    {
                        FormsAuthentication.SetAuthCookie(u.Username, false);
                        return RedirectToAction("Index", "Tournament");
                    }

                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("Username", "The user name or password is incorrect");
                return RedirectToAction("Login", "Account");

            };






            ModelState.AddModelError("Username", "The user name or password is incorrect");
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]


      
        public ActionResult Signup([Bind(Include = "EventID,FirstName,LastName,Username,Email,Password,ConfirmPassword")] Users _user)
        {
            Password ep = new Password();
            _user.Password = ep.Encode(_user.Password);
            _user.ConfirmPassword = ep.Encode(_user.ConfirmPassword);


                    repositorywrapper.User.Create(_user);
                    repositorywrapper.User.Save();

            TempData["SuccessM"] = "Registration successful";
            return RedirectToAction("Login");

            
           
        }

        //[HttpPost]
        //public ActionResult Signout()
        //{
        //    return View();
        //}
    }
}