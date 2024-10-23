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
    public class FishHealthRepository : GenericRepository<FishHealth>
    {
        private readonly FA24_SE1702_PRN221_G1_KDOSContext _context;

        public FishHealthRepository(FA24_SE1702_PRN221_G1_KDOSContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<FishHealth>> GetAllFishesAsync()
        {
            return await GetAllAsync(f => f.OrderDetails); 
        }

        public async Task<FishHealth> GetFishHealthByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<int> AddFishHealthAsync(FishHealth fishHealth)
        {
            await CreateAsync(fishHealth);
            return await SaveAsync();
        }

        public async Task<int> UpdateFishHealthAsync(FishHealth fishHealth)
        {
            await UpdateAsync(fishHealth);
            return await SaveAsync();
        }

        public async Task<bool> DeleteFishHealthAsync(int id)
        {
            var fishHealth = await GetByIdAsync(id);
            if (fishHealth != null)
            {
                await RemoveAsync(fishHealth);
                return true;
            }
            return false;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<List<Order>> GetAllOrderIdsAsync()
        {
            return await _context.Orders.Select(o => new Order { Id = o.Id }).ToListAsync(); // Fetching only Order IDs
        }
    }
}
