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
    public class IndexModel(IOrderService service) : PageModel
    {
        private readonly IOrderService _orderService = service;

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = (await _orderService.GetAll()).Data as IList<Order>;
        }
    }
}
