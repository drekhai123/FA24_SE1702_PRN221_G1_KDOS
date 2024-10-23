using KoiFishManagementRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Data.Models;

namespace KoiFishManagementService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRespository _accountRepository;

        public AccountService(IAccountRespository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account Login(string username, string password)
        {
            
            var account = _accountRepository.GetAccount(username, password);

            if (account == null)
            {
                throw new Exception("Invalid username or password!");
            }

            return account;
        }



    }
}
