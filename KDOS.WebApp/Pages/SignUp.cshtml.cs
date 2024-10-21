using KDOS.Common;
using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public SignUpModel(ICustomerService customerService) => _customerService = customerService;
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var customer = new Customer
            {
                CustomerName = Customer.CustomerName,
                Email = Customer.Email,
                Password = Customer.Password
            };

            var result = await _customerService.Save(customer);
            if (result.Status != Const.SUCCESS_CREATE_CODE && result.Status != Const.SUCCESS_UPDATE_CODE)
            {
                ModelState.AddModelError(string.Empty, result.Message + "\nUser already exists.");
                return Page(); // Reload the page with an error
            }
            return RedirectToPage("Login");
        }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
