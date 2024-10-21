using KDOS.Common;
using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public LoginModel(ICustomerService customerService) => _customerService = customerService;
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var customer = new Customer
            {
                CustomerName = "dang",
                Email = Customer.Email,
                Password = Customer.Password
            };

            var result = await _customerService.GetByUsernameAndPassword(customer);
            if (result.Status != Const.SUCCESS_CREATE_CODE && result.Status != Const.SUCCESS_UPDATE_CODE)
            {
                ModelState.AddModelError(string.Empty, result.Message + "\nLogin failed.");
                return Page();
            }
            return RedirectToPage("/Customers/Index");
        }
    }
}
