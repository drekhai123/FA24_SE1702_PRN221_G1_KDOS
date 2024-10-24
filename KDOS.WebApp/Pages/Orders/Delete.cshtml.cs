using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KDOS.Data.Data;
using KDOS.Data.Models;
using KDOS.Service;

namespace KDOS.WebApp.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderService _orderService;


        public DeleteModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if ((await _orderService.GetById(id)).Data is not Order order)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if ((await _orderService.GetById(id)).Data is Order order)
            {
                Order = order;
                await _orderService.DeleteById(id);
                await _orderService.Save(order);
            }

            return RedirectToPage("./Index");
        }
    }
}
