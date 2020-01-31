using mvc_codefirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Login(User user)
        {
            var username = await userContext.Users.FirstOrDefaultAsync(a => a.Username == user.Username);
            if (username != null)
            {
                if (user.Password == username.Password || BCrypt.Net.BCrypt.Verify(user.Password, username.Password))
                {
                    Session["user"] = user.Username;
                    Session.Add("username", username.Username);
                    //var role = userContext.Roles.Include(r => r.Name);
                    //Session["rl"] = role;
                    //Session.Add("role", role);
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
        public async Task<ActionResult> Index(User user)
        {
            if (Session["username"] != null)
            {
                var list = await userContext.Users.ToListAsync();
                Session["user"] = user.Username;
                //Session["rl"] = user.Role.Name;
                return View(list);
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
        public async Task<ActionResult> Register(User user)
        {
            try
            {
                // TODO: Add insert logic here
                var role = await userContext.Roles.FirstOrDefaultAsync(b => b.Id == 2);
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt(5));
                userContext.Users.Add(user);
                var result = await userContext.SaveChangesAsync();
                if(result > 0)
                {
                    NetworkCredential n = new NetworkCredential("itcuad@gmail.com", "itcuad2018");
                    MailMessage mm = new MailMessage("itcuad@gmail.com", user.Email);
                    mm.Subject = "[Password] " + DateTime.Now.ToString("ddMMyyyyhhmmss");
                    mm.Body = "Hi " + user.Username + " Thank You for Registering on Our Application. \nThis Is Your New Password : " + user.Password;

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
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Detail(string username)
        {
            var profile = await userContext.Users.FindAsync(username);
            return View(profile);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(string username)
        {
            var edit = await userContext.Users.FindAsync(username);
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string username, User user)
        {
            try
            {
                // TODO: Add update logic here
                var edit = await userContext.Users.FindAsync(username);
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt(5));
                edit.Name = user.Name;
                edit.Email = user.Email;
                edit.Password = user.Password;
                userContext.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                await userContext.SaveChangesAsync();
                return RedirectToAction("Index");
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
