using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KDOS.Data.Data;
using KDOS.Data.Models;
using KDOS.Service;

namespace KDOS.WebApp.Pages.Customers
{
    public class DeleteModel(ICustomerService service) : PageModel
    {
        private readonly ICustomerService _customerService = service;

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if ((await _customerService.GetById(id)).Data is not Customer customer)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if ((await _customerService.GetById(id)).Data is Customer customer)
            {
                Customer = customer;
                await _customerService.DeleteById(id);
                await _customerService.Save(customer);
            }

            return RedirectToPage("./Index");
        }
    }
}
