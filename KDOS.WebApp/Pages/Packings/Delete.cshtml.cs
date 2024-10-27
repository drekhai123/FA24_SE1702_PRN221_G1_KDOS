using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.Pages.Packings
{
    public class DeleteModel : PageModel
    {
        private readonly IPackingService _packingService;

        public DeleteModel(IPackingService packingService)
        {
            _packingService = packingService;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _packingService.DeletePackingAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
