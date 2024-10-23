using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KDOS.Common;
using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace KDOS.WebApp.Pages.FishHealthPage
{
    public class IndexModel : PageModel
    {
        private readonly IFishHealthService _fishHealthService;


        public IndexModel(IFishHealthService fishHealthService)
        {
            _fishHealthService = fishHealthService;
        } 
        public IList<FishHealth> FishHealth { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchTemperature { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SearchHealthStatus { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public const int PageSize = 6;
        public async Task OnGetAsync()
        {
            // Fetch all fish health data
            var fishHealthResult = await _fishHealthService.GetAll();
            if (fishHealthResult.Status != Const.SUCCESS_READ_CODE)
            {
                // Handle the case when data is not successfully retrieved
                FishHealth = new List<FishHealth>();
                return;
            }

            // Cast the data to a List<FishHealth> since it may not be IQueryable
            var fishHealthList = fishHealthResult.Data as List<FishHealth>;

            // Apply search filtering based on temperature and health status
            if (!string.IsNullOrEmpty(SearchTemperature) || !string.IsNullOrEmpty(SearchHealthStatus))
            {
                fishHealthList = fishHealthList
                    .Where(fh =>
                        (string.IsNullOrEmpty(SearchTemperature) ||
                         (fh.Temperature.HasValue &&
                          fh.Temperature.ToString().Contains(SearchTemperature))) &&
                        (string.IsNullOrEmpty(SearchHealthStatus) ||
                         fh.HealthStatus.Contains(SearchHealthStatus, StringComparison.OrdinalIgnoreCase))
                    )
                    .ToList(); // Materialize the filtered query into a list
            }

            // Calculate total pages for pagination
            TotalPages = (int)Math.Ceiling(fishHealthList.Count / (double)PageSize);

            // Apply pagination
            FishHealth = fishHealthList
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }

}
