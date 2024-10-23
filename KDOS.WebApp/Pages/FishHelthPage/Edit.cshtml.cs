using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KDOS.Data.Models;
using KoiFishManagementService;

namespace PRN221_KoiFishManagement.Pages.FishHelthPage
{
    public class EditModel : PageModel
    {
        private readonly IFishHelthService _context;

        public EditModel(IFishHelthService context)
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

            var fishhealth =   _context.GetFishHelthById(id);
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           

            try
            {
                 _context.UpdateFishHelth(FishHealth);
                TempData["Message"] = "FishHelth Updated!";
                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FishHealthExists(FishHealth.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FishHealthExists(int id)
        {
            return _context.GetFishHelthById(id) == null ;
        }
    }
}
