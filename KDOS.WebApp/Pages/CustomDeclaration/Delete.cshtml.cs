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

namespace KDOS.WebApp.Pages.CustomDeclaration
{
    public class DeleteModel (ICustomsDeclarationService customsDeclarationService) : PageModel
    {
        private readonly ICustomsDeclarationService _customsDeclarationService = customsDeclarationService;
                
        [BindProperty]
        public CustomsDeclaration CustomsDeclaration { get; set; } = default!;
        [BindProperty]
        public Order Order { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if ((await _customsDeclarationService.GetById(id)).Data is not CustomsDeclaration customsDeclaration)
            {
                return NotFound();
            }
            else
            {
                Order.Id = customsDeclaration.OrderId;
                CustomsDeclaration = customsDeclaration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if ((await _customsDeclarationService.GetById(id)).Data is CustomsDeclaration customsDeclaration)
            {
                CustomsDeclaration = customsDeclaration;
                await _customsDeclarationService.DeleteById(id);
                await _customsDeclarationService.Save(customsDeclaration);
            }

            return RedirectToPage("../Orders/Details", new { id = CustomsDeclaration.OrderId });
        }
    }
}
