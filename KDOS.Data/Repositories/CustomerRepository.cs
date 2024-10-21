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
    public class CustomerRepository(FA24_SE1702_PRN221_G1_KDOSContext context) : GenericRepository<Customer>
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context = context;

        public async Task<Customer> GetUser(Customer customer)
        {
            _context = new();
            return await _context.Customers.FirstOrDefaultAsync(user => user.Email == customer.Email && user.Password == customer.Password);
        }

    }
}
