using KoiFishManagementService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_KoiFishManagement.Pages.LoginPage
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        private readonly IAccountService _accountService;
        public IndexModel(IAccountService accountService)
        {

            _accountService = accountService;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var account = _accountService.Login(username, password);
                if (account != null)
                {

                    if (account.Role == "Staff")
                    {
                        TempData["Message"] = "Login success";
                        Console.WriteLine("Login success");
                        HttpContext.Session.SetString("Role", account.Role);
                        return RedirectToPage("/FishHelthPage/Index");
                    }
                    else
                    {
                        TempData["Message"] = "You do not have access rights.";
                        Console.WriteLine("You do not have access rights.");
                        return Page();
                    }
                }
                else
                {
                    throw new InvalidOperationException("No valid account found. Unable to set RoleID in session.");
                }
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return Page();
            }
        }
    }
}
