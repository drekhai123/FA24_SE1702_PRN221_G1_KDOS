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

namespace KDOS.WebApp.Pages.Customers
{
    public class IndexModel(ICustomerService service) : PageModel
    {
        //private readonly KDOS.Data.Data.FA24_SE1702_PRN221_G1_KDOSContext _context;
        private readonly ICustomerService _customerService = service;

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = (await _customerService.GetAll()).Data as IList<Customer>;
        }
    }
}
