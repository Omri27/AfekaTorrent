using Administration.Models;
using Entities;
using FreeFile.DownloadManager.UserServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Administration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult RegisterUser(RegisterViewModel model)
        {
            UserServiceClient Usc = new UserServiceClient();
            if (ModelState.IsValid)
            {
                var user = new Entities.User { UserName = model.UserName, Password = model.Password , DownloadFolder="",SharedFolder="" };
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
                userList.Add(element);
            }

            return View(userList);
        }

        public ActionResult DeleteUser(string UserID)
        {
            UserServiceClient Usc = new UserServiceClient();
            Usc.DeleteUser(Guid.Parse(UserID));

            return RedirectToAction("Users", "User");
        }
        public ActionResult DisplayUser(Guid UserID)
        {
            UserServiceClient Usc = new UserServiceClient();
            return View(Usc.GetUser(UserID));
        }

        public ActionResult EditUser(Entities.User user)
        {
            return RedirectToAction("Users", "User");
        }
    }
}