using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KDOS.WebApp.Pages.FishHealthPage
{
    public class DetailsModel : PageModel
    {
        private readonly IFishHealthService _fishHealthService;

        public DetailsModel(IFishHealthService fishHealthService)
        {
            _fishHealthService = fishHealthService;
        }

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
    }
}
