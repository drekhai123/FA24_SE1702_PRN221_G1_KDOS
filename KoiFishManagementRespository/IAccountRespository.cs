using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManagementRespository
{
    public interface IAccountRespository
    {
        public Account GetAccount(string username, string password);
    }
}
