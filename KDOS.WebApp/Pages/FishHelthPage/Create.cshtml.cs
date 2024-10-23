using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishManagementService;
using KDOS.Data.Models;

namespace PRN221_KoiFishManagement.Pages.FishHelthPage
{
    public class CreateModel : PageModel
    {
        private readonly IFishHelthService _context;

        public CreateModel(IFishHelthService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var orderDetails = _context.GetAllOrderDetails();
            if (orderDetails == null || !orderDetails.Any())
            {
                throw new InvalidOperationException("OrderDetails data is missing.");
            }
            ViewData["OrderDetailsId"] = new SelectList(orderDetails, "OrderDetailsId", "OrderDetailsId");

            var orderIds = _context.GetAllOrderIds();
            if (orderIds == null || !orderIds.Any())
            {
                throw new InvalidOperationException("OrderIds data is missing.");
            }
            ViewData["Id"] = new SelectList(orderIds, "Id", "Id");

            return Page();
        }

        [BindProperty]
        public FishHealth FishHealth { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var orderDetails = _context.GetAllOrderDetails();
                if (orderDetails == null || !orderDetails.Any())
                {
                    ViewData["OrderDetailsId"] = new List<SelectListItem>();
                }
                else
                {
                    ViewData["OrderDetailsId"] = new SelectList(orderDetails, "OrderDetailsId", "OrderDetailsId");
                }

                var orderIds = _context.GetAllOrderIds();
                if (orderIds == null || !orderIds.Any())
                {
                    ViewData["Id"] = new List<SelectListItem>();
                }
                else
                {
                    ViewData["Id"] = new SelectList(orderIds, "Id", "Id");
                }

                return Page();
            }

            _context.AddFishHelth(FishHealth);
            TempData["Message"] = "FishHelth Created!";
            return RedirectToPage("./Index");
        }
    }
}