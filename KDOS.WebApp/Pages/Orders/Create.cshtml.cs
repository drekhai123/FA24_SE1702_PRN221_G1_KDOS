using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KDOS.Data.Data;
using KDOS.Data.Models;

namespace KDOS.WebApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly KDOS.Data.Data.FA24_SE1702_PRN221_G1_KDOSContext _context;

        public CreateModel(KDOS.Data.Data.FA24_SE1702_PRN221_G1_KDOSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "CustomerName");
        ViewData["PriceId"] = new SelectList(_context.PriceLists, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
