using MVCCrudDemo.Models.DBContext;
using MVCCrudDemo.Models.ViewModel;
using MVCCrudDemo.Repository.Interface;
using MVCCrudDemo.Repository.Interface.LoginInterface;
using MVCCrudDemo.SessionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ThemeIntegration.Controllers
{
    public class LoginController : Controller
    {
        IRegisterInterface _registerContext;
        public LoginController(IRegisterInterface registerContext)
        {
            _registerContext = registerContext;
        }

        /// <summary>
        /// Login to home page after check validation else keep on login page and show error message
        /// </summary>

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include ="Email , Password")] RegisterModel login)
        {
            try
            {
                if (_registerContext.LoginUser(login))
                {
                    
                    SessionCustomHelper.UserEmail = login.Email;

                   

                    TempData["success"] = "Login successfully ";
                    return RedirectToAction("DashBoard","DashBoard");
                    ModelState.Clear();
                }
                else
                {
                    TempData["error"] = "Login Failed !";
                    return RedirectToAction("Login","Login");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// register new record also show toast notification when new user added and redirect to Login page
        /// </summary>

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            try
            {
                if (ModelState.IsValid && register != null)
                {
                    RegisterMaster result = _registerContext.RegisterStudent(register);

                    //if not null then it redirect to login else it will give error
                    if(result != null)
                    {
                        

                        TempData["success"] = "Register successfully ";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Email id already exist");
                    }
                }
                    
                return View(register);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Log out from dashboard and redirect to Login page - session  will end
        /// </summary>

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}