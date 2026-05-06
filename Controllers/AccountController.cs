using Microsoft.AspNetCore.Mvc;
using MedicalSystemApp.Models;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        if (string.IsNullOrEmpty(user.Role) ||
            string.IsNullOrEmpty(user.Email) ||
            string.IsNullOrEmpty(user.Password))
        {
            ViewBag.Error = "All fields are required";
            return View();
        }

        // Fake authentication (for now)
        if (user.Email == "admin@test.com" && user.Password == "1234")
        {
            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Error = "Invalid login details";
        return View();
    }

}