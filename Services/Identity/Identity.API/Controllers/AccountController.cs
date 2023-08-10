using eShop.Services.Identity.API.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Services.Identity.API.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        return Redirect("~/");
    }
}
