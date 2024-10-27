using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.Pages.Packings
{
    public class DetailsModel : PageModel
    {
        private readonly IPackingService _packingService;

        public DetailsModel(IPackingService packingService)
        {
            _packingService = packingService;
        }

        public Packing Packing { get; set; }

        public async Task OnGetAsync(int id)
        {
            Packing = await _packingService.GetPackingByIdAsync(id);
        }
    }
}
