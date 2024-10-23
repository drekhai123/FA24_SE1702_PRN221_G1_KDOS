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
    public class DeleteModel : PageModel
    {
        private readonly IFishHelthService _context;

        public DeleteModel(IFishHelthService context)
        {
            _context = context;
        }

        [BindProperty]
        public FishHealth FishHealth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishhealth =  _context.GetFishHelthById(id);

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                _context.DeleteFishHelth(id);
                TempData["Message"] = "FishHelth Deleted!";

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }
    }
}
