using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace KDOS.WebApp.Pages.FishHealthPage
{
    public class EditModel : PageModel
    {
        private readonly IFishHealthService _fishHealthService;

        public EditModel(IFishHealthService fishHealthService)
        {
            _fishHealthService = fishHealthService;
        }

        [BindProperty]
        public FishHealth FishHealth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var fishHealth = (await _fishHealthService.GetById(id)).Data as FishHealth;
            if (fishHealth == null)
            {
                return NotFound();
            }
            FishHealth = fishHealth;
            return Page();
        }

      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _fishHealthService.UpdateFishHealthAsync(FishHealth);

            return RedirectToPage("./Index");
        }
    }
}
