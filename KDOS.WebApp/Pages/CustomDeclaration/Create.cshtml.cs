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
using KDOS.Data.EnumData.CustomsDeclaration;

namespace KDOS.WebApp.Pages.CustomDeclaration
{
    public class CreateModel(IOrderService orderService, ICustomsDeclarationService customsDeclarationService, ICustomerService customerService) : PageModel
    {
        private readonly IOrderService _orderService = orderService;
        private readonly ICustomsDeclarationService _customsDeclarationService = customsDeclarationService;
        private readonly ICustomerService _customerService = customerService;

        [BindProperty]
        public CustomsDeclaration CustomsDeclaration { get; set; } = new();
        [BindProperty]
        public Order Order { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
        public TransportationMode Transportation { get; set; }
        public ImportPermit ImportPermit { get; set; }
        public Status Status { get; set; }

        //public IActionResult OnGet()
        //{
        //    ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
        //    ViewData["ReceiverCustomerId"] = new SelectList(_context.Customers, "Id", "CustomerName");
        //    ViewData["SenderCustomerId"] = new SelectList(_context.Customers, "Id", "CustomerName");
        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if ((await _orderService.GetById(id)).Data is not Order order)
            {
                return NotFound();
            }
            else
            {
                Order = order;
                Customer = (await _customerService.GetById(order.CustomerId)).Data as Customer;
                CustomsDeclaration.Sender = Customer.CustomerName;
            }
            return Page();
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if ((await _orderService.GetById(id)).Data is not Order order)
            {
                return NotFound();
            }

            CustomsDeclaration.OrderId = Order.Id;
            Customer = (await _customerService.GetById(order.CustomerId)).Data as Customer;
            CustomsDeclaration.SenderCustomerId = Customer.Id;

            await _customsDeclarationService.Save(CustomsDeclaration);

            return RedirectToPage("../Orders/Details", new { id = CustomsDeclaration.OrderId });
        }
    }
}
