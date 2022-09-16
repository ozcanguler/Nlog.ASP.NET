using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Business;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            // put an item in the log
            logger.Info("Entering the login controller.  Login method");
            //return "Results: Username: "+userModel.Username+" Password: "+userModel.Password;

            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Login");
                }
                SecurityService securityService = new SecurityService();
                Boolean success = securityService.Authenticate(userModel);

                if (success)
                {
                    logger.Info("Exit login controller. Login success!");

                    return View("LoginSuccess", userModel);
                }
                else
                {
                    logger.Info("Exit login controller. Login failure!");
                    return View("LoginFailure");
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return Content("Exception in login" + e.Message);
            }

        }
    }
}