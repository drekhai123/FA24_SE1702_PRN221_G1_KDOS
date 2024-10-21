using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KDOS.Data.Data;
using KDOS.Data.Models;

namespace KDOS.WebApp.Pages.CustomDeclaration
{
    public class DetailsModel : PageModel
    {
        private readonly KDOS.Data.Data.FA24_SE1702_PRN221_G1_KDOSContext _context;

        public DetailsModel(KDOS.Data.Data.FA24_SE1702_PRN221_G1_KDOSContext context)
        {
            _context = context;
        }

        public CustomsDeclaration CustomsDeclaration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customsdeclaration = await _context.CustomsDeclarations.FirstOrDefaultAsync(m => m.Id == id);
            if (customsdeclaration == null)
            {
                return NotFound();
            }
            else
            {
                CustomsDeclaration = customsdeclaration;
            }
            return Page();
        }
    }
}
