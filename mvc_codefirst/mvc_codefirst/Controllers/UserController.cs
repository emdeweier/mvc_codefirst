using mvc_codefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace mvc_codefirst.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext userContext = new ApplicationDbContext();
        // GET : Login
        public ActionResult Login()
        {
            if(Session["username"] != null)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }
        
        // POST: User/Create
        [HttpPost]
        public ActionResult Login(User user)
        {
            var username = userContext.Users.FirstOrDefault(a => a.Username == user.Username);
            if (username != null)
            {
                if (user.Password == username.Password)
                {
                    Session["user"] = user.Username;
                    Session.Add("username", username.Username);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            else
            {
                return RedirectToAction("Login","User");
            }
        }

        // GET: User
        public ActionResult Index(User user)
        {
            if (Session["username"] != null)
            {
                Session["user"] = user.Username;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        // GET: User/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                // TODO: Add insert logic here
                var role = userContext.Roles.FirstOrDefault(b => b.Id == 2);
                user.Role = role;
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt(5));
                userContext.Users.Add(user);
                userContext.SaveChanges();
                NetworkCredential n = new NetworkCredential("itcuad@gmail.com", "itcuad2018");
                MailMessage mm = new MailMessage("itcuad@gmail.com", user.Email);
                mm.Subject = "[Password] " + DateTime.Now.ToString("ddMMyyyyhhmmss");
                mm.Body = "Hi " + user.Username + "\nThis Is Your New Password : " + user.Password;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = n;
                smtp.Send(mm);
                ViewBag.Message = "Password Has Been Sent.Check your email to login";
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        // GET : Logout
        public ActionResult Logout()
        {
            if (Session["username"] != null)
            {
                Session.Remove("user");
                Session.Remove("username");
                return RedirectToAction("Login", "User");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}
