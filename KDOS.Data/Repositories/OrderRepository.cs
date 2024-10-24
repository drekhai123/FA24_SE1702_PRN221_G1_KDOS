using KDOS.Data.Base;
using KDOS.Data.Data;
using KDOS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Data.Repositories
{
    public class OrderRepository(FA24_SE1702_PRN221_G1_KDOSContext context) : GenericRepository<Order>
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context = context;
        public async Task<List<PriceList>> GetAllPriceIdAsync()
        {
            return await _context.PriceLists.ToListAsync();
        }
        public async Task<List<Customer>> GetAllCustomerIdAsync()
        {
            return await _context.Customers.Select(o => new Customer { Id = o.Id }).ToListAsync(); 
        }
    }
}
