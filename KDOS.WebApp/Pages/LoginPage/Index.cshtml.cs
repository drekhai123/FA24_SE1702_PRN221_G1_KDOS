
using KDOS.Common;
using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.WebApp
{
    public class IndexModel : PageModel
    {
       

        private readonly IAccountService _accountService;
        public IndexModel(IAccountService accountService)
        {

            _accountService = accountService;
        }
        [BindProperty]
        public Account account { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var accounts = new Account
            {
                Username = account.Username,
                Password = account.Password
            };

            var result = await _accountService.GetByUsernameAndPassword(accounts);

            if (accounts.Role == "Staff")
            {
                TempData["Message"] = "Login success";
                Console.WriteLine("Login success");
                HttpContext.Session.SetString("Role", accounts.Role);
                return RedirectToPage("/FishHelthPage/Index");
            }
            else
            {
                TempData["Message"] = "You do not have access rights.";
                Console.WriteLine("You do not have access rights.");
                return Page();
            }
        }
    }
}
