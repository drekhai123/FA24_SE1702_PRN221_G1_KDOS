using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KDOS.Data.Repositories;
using KDOS.Service;
using KDOS.Data.Models;

namespace KDOS.WebApp.Pages.FishHealthPage

{
    public class CreateModel : PageModel
    {
        private readonly IFishHealthService _fishHealthService;

        public CreateModel(IFishHealthService fishHealthService)
        {
            _fishHealthService = fishHealthService;
        }

        public async Task<IActionResult> OnGet()
        {
            // Lấy danh sách OrderDetails
            var orderDetailsResult = await _fishHealthService.GetAllOrderDetails();
            if (orderDetailsResult == null || orderDetailsResult.Data == null || !((IEnumerable<OrderDetail>)orderDetailsResult.Data).Any())
            {
                throw new InvalidOperationException("OrderDetails data is missing.");
            }
            var orderDetailsList = (IEnumerable<OrderDetail>)orderDetailsResult.Data;
            var orderDetailsIds = orderDetailsList.Select(od => od.OrderDetailsId).ToList();
            Console.WriteLine("OrderDetails IDs: " + string.Join(", ", orderDetailsIds));

            ViewData["OrderDetailsId"] = new SelectList(orderDetailsList, "OrderDetailsId", "OrderDetailsId");
            var orderIdsResult = await _fishHealthService.GetAllOrderIds();
            if (orderIdsResult == null || orderIdsResult.Data == null || !((IEnumerable<Order>)orderIdsResult.Data).Any())
            {
                throw new InvalidOperationException("OrderIds data is missing.");
            }
            var orderList = (IEnumerable<Order>)orderIdsResult.Data;
            var orderIds = orderList.Select(o => o.Id).ToList();
            Console.WriteLine("Order IDs: " + string.Join(", ", orderIds));

            ViewData["Id"] = new SelectList(orderList, "Id", "Id");

            return Page();
        }
        [BindProperty]
        public FishHealth FishHealth { get; set; } = default!;

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {

                var orderDetailsResult = await _fishHealthService.GetAllOrderDetails();
                if (orderDetailsResult == null || orderDetailsResult.Data == null || !((IEnumerable<OrderDetail>)orderDetailsResult.Data).Any())
                {
                    ViewData["OrderDetailsId"] = new List<SelectListItem>();
                }
                else
                {
                    ViewData["OrderDetailsId"] = new SelectList((IEnumerable<OrderDetail>)orderDetailsResult.Data, "OrderDetailsId", "OrderDetailsId");
                }


                var orderIdsResult = await _fishHealthService.GetAllOrderIds();
                if (orderIdsResult == null || orderIdsResult.Data == null || !((IEnumerable<Order>)orderIdsResult.Data).Any())
                {
                    ViewData["Id"] = new List<SelectListItem>();
                }
                else
                {
                    ViewData["Id"] = new SelectList((IEnumerable<Order>)orderIdsResult.Data, "Id", "Id");
                }


                return Page();
            }

            await _fishHealthService.Save(FishHealth);
            TempData["Message"] = "FishHealth Created!";

            return RedirectToPage("./Index");
        }

    }
}