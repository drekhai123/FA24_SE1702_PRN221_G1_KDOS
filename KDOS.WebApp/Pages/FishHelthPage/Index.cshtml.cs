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
    public class IndexModel : PageModel
    {
        private readonly IFishHelthService _context;

        public IndexModel(IFishHelthService context)
        {
            _context = context;
        }

        public IList<FishHealth> FishHealth { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchTemperature { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SearchHealthStatus { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1; 

        public int TotalPages { get; set; }

        public const int PageSize = 3; 

        public async Task OnGetAsync()
        {
                var fishHealthQuery = _context.GetAllFishesHelth().AsQueryable();

                // Lọc theo tiêu chí tìm kiếm
                if (!string.IsNullOrEmpty(SearchTemperature) || !string.IsNullOrEmpty(SearchHealthStatus))
                {
                    fishHealthQuery = fishHealthQuery
                        .Where(fh =>
                            (string.IsNullOrEmpty(SearchTemperature) ||
                             (fh.Temperature.HasValue &&
                              fh.Temperature.ToString().Contains(SearchTemperature))) &&
                            (string.IsNullOrEmpty(SearchHealthStatus) ||
                             fh.HealthStatus.Contains(SearchHealthStatus, StringComparison.OrdinalIgnoreCase))
                        );
                }
                TotalPages = (int)Math.Ceiling(fishHealthQuery.Count() / (double)PageSize);

                // Phân trang
                FishHealth = fishHealthQuery.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            }
        } 
    
}
