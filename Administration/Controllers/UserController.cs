using Administration.Models;
using Entities;
using DownloadManager.UserServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;

namespace Administration.Controllers
{
    public class UserController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            UserServiceClient Usc = new UserServiceClient();
            var user = Usc.Login(model.UserName, model.Password);
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                

                var authTicket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                string path = Path.Combine(HttpRuntime.AppDomainAppPath,"MyConfig.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.DocumentElement;
                XmlNode Guid = root.SelectSingleNode("Guid");
                Guid.InnerText = user.UserID.ToString();
                doc.Save(path);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }
        // GET: User
        public ActionResult RegisterUser(RegisterViewModel model)
        {
            UserServiceClient Usc = new UserServiceClient();
            if (ModelState.IsValid)
            {
                var user = new Entities.User { UserName = model.UserName, Password = model.Password, DownloadFolder = "", SharedFolder = "",IsEnabled= true,Roles = "REGULAR"};
                Usc.AddUser(user);

                // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                return RedirectToAction("Index", "Home");

                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        public ActionResult Users()
        {

            UserServiceClient Usc = new UserServiceClient();
            List<Entities.User> userList = new List<Entities.User>();
            List<User> userModel = new List<User>();
            foreach (Entities.User user in Usc.GetAllUsers())
            {
                Entities.User element = new Entities.User();
                element.UserName = user.UserName;
                element.UserID = user.UserID;
                element.Password = user.Password;
                element.IsEnabled = user.IsEnabled;
                element.IsActive = user.IsActive;
                element.DownloadFolder = user.DownloadFolder;
                element.SharedFolder = user.SharedFolder;
                userList.Add(element);
            }
            return View(userList);
        }
        [Authorize(Roles = "ADMIN")]
        public ActionResult DeleteUser(string UserID)
        {
            UserServiceClient Usc = new UserServiceClient();
            Usc.DeleteUser(Guid.Parse(UserID));

            return RedirectToAction("Users", "User");
        }
        [Authorize(Roles = "ADMIN")]
        public ActionResult DisplayUser(Guid UserID)
        {
            UserServiceClient Usc = new UserServiceClient();
            User user = Usc.GetUser(UserID);
            RegisterViewModel displayUserModel = new RegisterViewModel();
            displayUserModel.UserName = user.UserName;
            displayUserModel.UserID = UserID;
            displayUserModel.IsEnabled = user.IsEnabled;
            return View(displayUserModel);
        }
        [Authorize(Roles = "ADMIN")]
        public ActionResult EditUser(RegisterViewModel model)
        {
            UserServiceClient Usc = new UserServiceClient();
            if (ModelState.IsValid)
            {
                var user = new Entities.User {UserID= model.UserID, UserName = model.UserName, Password = model.Password, DownloadFolder = "", SharedFolder = "",IsEnabled = model.IsEnabled };
                Usc.EditUser(user);
                return RedirectToAction("Users", "User");
            }
            return RedirectToAction("DisplayUser", "User",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, "MyConfig.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlNode guid = root.SelectSingleNode("Guid");
            var UserId = guid.InnerText;
            UserServiceClient Usc = new UserServiceClient();
            Usc.Logout(Guid.Parse(UserId));
            return RedirectToAction("Index", "Home");
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //return RedirectToAction("Index", "Home");
        }
    }
}