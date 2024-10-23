using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using KDOS.Data;
using KDOS.Data.Data;
using KDOS.Data.Models;

namespace FishHealthManagementDAO
{
    public class AccountDAO
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context;
        private static AccountDAO _instance = null;
        public static AccountDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountDAO();
                }
                return _instance;
            }
        }
        private AccountDAO()
        {
            _context = new FA24_SE1702_PRN221_G1_KDOSContext();
        }
        public Account GetAccount(string username, string password)
        {
            return _context.Accounts.SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}

