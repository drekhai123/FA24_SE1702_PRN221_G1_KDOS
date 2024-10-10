using KDOS.Data.Base;
using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Data.Repository
{
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository() { }
        public AccountRepository(FA24_SE1702_211_G1_KDOSContext context) => _context = context;
    }
}
