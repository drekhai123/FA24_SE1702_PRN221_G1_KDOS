using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KDOS.Data.Models;
using KDOS.Service;

namespace KDOS.WebApp.Pages.FishHealthPage
{
    public class DeleteModel : PageModel
    {
        private readonly IFishHealthService _fishHealthService;

        public DeleteModel(IFishHealthService fishHealthService)
        {
            _fishHealthService = fishHealthService;
        }

        [BindProperty]
        public FishHealth FishHealth { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if ((await _fishHealthService.GetById(id)).Data is not FishHealth fishHealth)
            {
                return NotFound();
            }
            else
            {
                FishHealth = fishHealth;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if ((await _fishHealthService.GetById(id)).Data is FishHealth fishHealth)
            {
                FishHealth = fishHealth;
                await _fishHealthService.DeleteById(id);
                await _fishHealthService.Save(fishHealth);
            }

            return RedirectToPage("./Index");
        }
    }
}
