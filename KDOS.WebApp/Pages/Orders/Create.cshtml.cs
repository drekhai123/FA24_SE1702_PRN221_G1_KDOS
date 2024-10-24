using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KDOS.Data.Data;
using KDOS.Data.Models;
using KDOS.Service;
using KDOS.Data.EnumData.Order;

namespace KDOS.WebApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        

        public CreateModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var price = await _orderService.GetAllPriceIdAsync();
            if (price == null || price.Data == null || !((IEnumerable<PriceList>)price.Data).Any())
            {
                throw new InvalidOperationException("PriceId data is missing.");
            }
            var priceList = (IEnumerable<PriceList>)price.Data;
            var priceIds = priceList.Select(od => od.Id).ToList();
            Console.WriteLine("OrderDetails IDs: " + string.Join(", ", priceIds));
            ViewData["PriceId"] = new SelectList(priceList, "Id", "Id");

            var customeridresult = await _orderService.GetAllCustomerIdAsync();
            if (customeridresult == null || customeridresult.Data == null || !((IEnumerable<Customer>)customeridresult.Data).Any())
            {
                throw new InvalidOperationException("CustomerId data is missing.");
            }
            var customerList = (IEnumerable<Customer>)customeridresult.Data;
            var customerIds = customerList.Select(o => o.Id).ToList();
            Console.WriteLine("Order IDs: " + string.Join(", ", customerIds));

            ViewData["Id"] = new SelectList(customerList, "Id", "Id");

            return Page();
        }
        [BindProperty]
        public Order Order { get; set; } = default!;
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {

                var priceResult = await _orderService.GetAllPriceIdAsync();
                if (priceResult == null || priceResult.Data == null || !((IEnumerable<PriceList>)priceResult.Data).Any())
                {
                    ViewData["PriceId"] = new List<SelectListItem>();
                }
                else
                {
                    ViewData["PriceId"] = new SelectList((IEnumerable<PriceList>)priceResult.Data, "Id", "Id");
                }


                var customerIdsResult = await _orderService.GetAllCustomerIdAsync();
                if (customerIdsResult == null || customerIdsResult.Data == null || !((IEnumerable<Customer>)customerIdsResult.Data).Any())
                {
                    ViewData["Id"] = new List<SelectListItem>();
                }
                else
                {
                    ViewData["Id"] = new SelectList((IEnumerable<Customer>)customerIdsResult.Data, "Id", "Id");
                }


                return Page();
            }

            await _orderService.Save(Order);
            TempData["Message"] = "Order Created!";

            return RedirectToPage("./Index");
        }
    }
}
