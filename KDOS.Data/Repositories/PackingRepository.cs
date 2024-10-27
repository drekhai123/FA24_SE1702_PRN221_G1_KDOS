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
    public class PackingRepository : GenericRepository<Packing>
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context;

        public PackingRepository(FA24_SE1702_PRN221_G1_KDOSContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Packing>> GetAllPackingAsync()
        {
            return await _context.Packings.ToListAsync();
        }

        public async Task<Packing> GetPackingByIdAsync(int id)
        {
            return await _context.Packings
                .Include(p => p.Order)
                .Include(p => p.Packer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveAsync(Packing packing)
        {
            if (packing.Id == 0)
            {
                await _context.Packings.AddAsync(packing);
            }
            else
            {
                _context.Packings.Update(packing);
            }
            await _context.SaveChangesAsync();
        }

        public void DeletePacking(Packing packing)
        {
            _context.Packings.Remove(packing);
        }
    }
}
