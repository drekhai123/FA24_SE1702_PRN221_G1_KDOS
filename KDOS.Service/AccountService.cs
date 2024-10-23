using KDOS.Common;
using KDOS.Data;
using KDOS.Data.Models;
using KDOS.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Service
{
    public interface IAccountService
    {
      
        Task<IBusinessResult> GetByUsernameAndPassword(Account account);
    }

    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unitOfWork;
        public AccountService() => _unitOfWork ??= new UnitOfWork();



        public async Task<IBusinessResult> GetByUsernameAndPassword(Account account)
        {
            #region Business Rule
            #endregion
            var user = await _unitOfWork.AccountRepository.GetUser(account);
            if (user == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, account);
        }
    }
}
