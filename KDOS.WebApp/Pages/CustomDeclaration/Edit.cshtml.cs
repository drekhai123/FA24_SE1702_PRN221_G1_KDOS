using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KDOS.Data.Data;
using KDOS.Data.Models;
using KDOS.Service;

namespace KDOS.WebApp.Pages.CustomDeclaration
{
    public class EditModel(IOrderService orderService, ICustomsDeclarationService customsDeclarationService, ICustomerService customerService) : PageModel
    {
        private readonly IOrderService _orderService = orderService;
        private readonly ICustomsDeclarationService _customsDeclarationService = customsDeclarationService;
        private readonly ICustomerService _customerService = customerService;

        [BindProperty]
        public CustomsDeclaration CustomsDeclaration { get; set; } = default!;
        [BindProperty]
        public Order Order { get; set; } = new();
        public Customer Customer { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int id)
        {
            if ((await _customsDeclarationService.GetById(id)).Data is not CustomsDeclaration customDeclaration)
            {
                return NotFound();
            }
            Order.Id = customDeclaration.OrderId;
            CustomsDeclaration = customDeclaration;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if ((await _customsDeclarationService.GetById(id)).Data is not CustomsDeclaration customDeclaration)
            {
                return NotFound();
            }
            CustomsDeclaration.OrderId = customDeclaration.OrderId;
            CustomsDeclaration.Id = id;
            await _customsDeclarationService.Save(CustomsDeclaration);

            

            return RedirectToPage("../Orders/Details", new { id = CustomsDeclaration.OrderId });
        }

        private bool CustomsDeclarationExists(int id)
        {
            return _customsDeclarationService.GetById(id) != null;
        }
    }
}
