using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Mvc.Infrastructure;
using Mvc.Infrastructure.Providers;
using Mvc.Models;
using BLLInterface.Services;
using Mvc.Infrastructure.Mappers;

namespace Mvc.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly ILotService lotService;

        public AccountController(IUserService userService, IRoleService roleService, ILotService lotService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.lotService = lotService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogOnViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (Membership.ValidateUser(viewModel.UserName, viewModel.Password))
                
                {
                    FormsAuthentication.SetAuthCookie(viewModel.UserName, viewModel.RememberMe);
                    if (Request.IsAjaxRequest())
                    {
                        return LoginPartial();
                    }
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                    if (Request.IsAjaxRequest())
                    {
                        return null;
                    }
                }
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            if (Request.IsAjaxRequest())
            {
                return LoginPartial();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (viewModel.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Incorrect input.");
                return View(viewModel);
            }
            
            var anyUser = userService.GetAll().Any(u => u.UserName.Contains(viewModel.UserName));
 

            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View("Registr");
            }

            if (ModelState.IsValid)
            {

                CustomMembershipProvider customMembershipProvider = (CustomMembershipProvider)Membership.Provider;
                var membershipUser = customMembershipProvider.CreateUser(viewModel.UserName, viewModel.Password);



                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.UserName, false);
                    if (Request.IsAjaxRequest())
                    {
                        return LoginPartial();
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                    if (Request.IsAjaxRequest())
                    {
                        throw new ArgumentException();
                    }
                }
            }
            return View(viewModel);
        }


        [AllowAnonymous]
        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] =
                new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Helvetica");

    
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";
            
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

      
            ci.Dispose();
            return null;
        }

        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            ViewBag.Message = "logIn";
            return PartialView("_LoginPartial");
        }

       

        [HttpGet]
        [Authorize]
        public ActionResult Cabinet()
        {
            var user = userService.GetByName(User.Identity.Name).ToVMUser(roleService);
            ViewBag.User = user;
            ViewBag.PurshaseList = lotService.GetAll().Where(l => (user.Id == l.OwnerId));
            if (User.IsInRole("Admin"))
                return View(userService.GetAll().Where(l=>l.UserName != user.UserName).Select(u => u.ToVMUser(roleService)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int UserId)
        {
            if (userService.GetByName(User.Identity.Name).Id != UserId)
            {
                userService.DeleteUser(userService.GetById(UserId));
            }
            var userList = userService.GetAll().Select(u => u.ToVMUser(roleService));
            if (Request.IsAjaxRequest())
            {
                return PartialView("_UsersList", userService.GetAll().Select(u => u.ToVMUser(roleService)));
            }
            
            return RedirectToAction("Cabinet");
        }
    }
}