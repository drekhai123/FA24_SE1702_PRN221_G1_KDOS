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
using KDOS.Data.EnumData.CustomsDeclaration;
using KDOS.Data.EnumData;

namespace KDOS.WebApp.Pages.Orders
{
    public class DetailsModel(IOrderService orderService, ICustomsDeclarationService customsDeclarationService) : PageModel
    {
        private readonly IOrderService _orderService = orderService;
        private readonly ICustomsDeclarationService _customsDeclarationService = customsDeclarationService;

        public Order Order { get; set; } = default!;
        public IList<CustomsDeclaration> CustomsDeclaration { get; set; } = default!;
        public TransportationMode Transportation { get;}
        public ImportPermit ImportPermit { get;}
        public Status Status { get;}

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if ((await _orderService.GetById(id)).Data is not Order order)
            {
                return NotFound();
            }
            else
            {
                Order = order;
                CustomsDeclaration = (await _customsDeclarationService.GetCustomDeclarationsByOrder(Order.Id)).Data as IList<CustomsDeclaration>;
            }
            return Page();
        }
    }
}
