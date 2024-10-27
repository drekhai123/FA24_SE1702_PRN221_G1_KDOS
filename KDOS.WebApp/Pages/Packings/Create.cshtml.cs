using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.Pages.Packings
{
    public class CreateModel : PageModel
    {
        private readonly IPackingService _packingService;

        public CreateModel(IPackingService packingService)
        {
            _packingService = packingService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Packing Packing { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _packingService.SavePackingAsync(Packing);
            return RedirectToPage("./Index");
        }
    }
}
