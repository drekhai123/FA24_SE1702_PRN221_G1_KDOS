using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.Pages.Packings
{
    public class IndexModel : PageModel
    {
        
        private readonly IPackingService _packingService;

        public IndexModel(IPackingService packingService)
        {
            _packingService = packingService;
        }

        public List<Packing> Packings { get; set; }

        public async Task OnGetAsync()
        {
            Packings = await _packingService.GetAllPackingAsync();
        }
    }
}

