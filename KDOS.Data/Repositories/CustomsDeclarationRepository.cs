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
    public class CustomsDeclarationRepository(FA24_SE1702_PRN221_G1_KDOSContext context) : GenericRepository<CustomsDeclaration>
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context = context;

        public async Task<List<CustomsDeclaration>> GetCustomDeclarationsByOrder(int id)
        {
            _context = new();
            return await _context.Set<CustomsDeclaration>()
                .Where( item => item.OrderId == id)
                .Include(x => x.SenderCustomer)
                .Include(x => x.ReceiverCustomer)
                .ToListAsync();
        }
    }
}
