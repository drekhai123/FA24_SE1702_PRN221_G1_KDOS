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
    public class AccountRepository(FA24_SE1702_PRN221_G1_KDOSContext context) : GenericRepository<Account>
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context = context;

        public async Task<Account> GetUser(Account account)
        {
            _context = new();
            return await _context.Accounts.FirstOrDefaultAsync(user => user.Username == account.Username && user.Password == user.Password);
        }
    }
}
