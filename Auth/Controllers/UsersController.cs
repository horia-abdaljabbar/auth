using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using Auth.Data;


namespace Auth.Controllers 
{
    public class UsersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index(User user)
        {
            var u = context.users.Where(u=>u.IsActive==false).ToList();
           
            return View(u);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            context.users.Add(u);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var check = context.users.Where(u => u.UserName == user.UserName && u.Password == user.Password);
            if (check.Any())
            {
                return RedirectToAction("Index", "Home");   
            }
            return View(User);
        }

        public IActionResult IsActive(int id)
        {
            var user= context.users.Find(id);
            user.IsActive = true;
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
