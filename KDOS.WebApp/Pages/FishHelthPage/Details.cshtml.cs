using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KDOS.Data.Models;
using KoiFishManagementService;

namespace PRN221_KoiFishManagement.Pages.FishHelthPage
{
    public class DetailsModel : PageModel
    {
        private readonly IFishHelthService _context;

        public DetailsModel(IFishHelthService context)
        {
            _context = context;
        }

        public FishHealth FishHealth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishhealth = _context.GetFishHelthById(id.Value);
            if (fishhealth == null)
            {
                return NotFound();
            }
            else
            {
                FishHealth = fishhealth;
            }
            return Page();
        }
    }
}
