using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManagementService
{
    public interface IAccountService
    {
        Account Login(string username, string password);
    }
}
