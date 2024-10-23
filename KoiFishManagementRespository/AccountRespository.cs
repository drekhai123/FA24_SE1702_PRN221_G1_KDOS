using KDOS.Data.Data;
using FishHealthManagementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Data.Models;

namespace KoiFishManagementRespository
{
    public class AccountRespository : IAccountRespository
    {
        public Account GetAccount(string username, string password)
        {
            return AccountDAO.Instance.GetAccount(username, password);
        }
    }
}
