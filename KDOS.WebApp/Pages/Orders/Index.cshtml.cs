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
using KDOS.Common;
using System.Drawing.Printing;

namespace KDOS.WebApp.Pages.Orders
{
    public class IndexModel(IOrderService service) : PageModel
    {
        private readonly IOrderService _orderService = service;

        public IList<Order> Order { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchShippingMethod { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SearchStatus { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public const int PageSize = 6;
        public async Task OnGetAsync()
        {
            var methodResult = await _orderService.GetAll();
            if (methodResult.Status != Const.SUCCESS_READ_CODE)
            {
                // Handle the case when data is not successfully retrieved
                Order = new List<Order>();
                return;
            }

            // Cast the data to a List<order> since it may not be IQueryable
            var orderList = methodResult.Data as List<Order>;

            // Apply search filtering based on method and  status
            if (!string.IsNullOrEmpty(SearchShippingMethod) || !string.IsNullOrEmpty(SearchStatus))
            {
                orderList = orderList
                    .Where(fh =>
                        (string.IsNullOrEmpty(SearchShippingMethod) ||
                         fh.ShippingMethod.Contains(SearchShippingMethod, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrEmpty(SearchStatus) ||
                         fh.Status.Contains(SearchStatus, StringComparison.OrdinalIgnoreCase))
                    )
                    .ToList(); // Materialize the filtered query into a list
            }

            // Calculate total pages for pagination
            TotalPages = (int)Math.Ceiling(orderList.Count / (double)PageSize);

            // Apply pagination
            Order = orderList
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}
