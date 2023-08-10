namespace eShop.Services.Identity.API.Models.AccountViewModels;

public class LoginViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}