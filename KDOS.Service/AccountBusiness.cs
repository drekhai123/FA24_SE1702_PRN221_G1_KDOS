using KDOS.Common;
using KDOS.Data;
using KDOS.Data.Models;
using KDOS.Service.Base;
using System.Threading.Tasks;

namespace KDOS.Service
{
    public interface IAccountBusiness
    {
        Task<BusinessResult> GetAll();
        Task<BusinessResult> GetById(int id);
        Task<BusinessResult> Save(Account account);
        Task<BusinessResult> Delete(int id);    
    }

    public class AccountBusiness : IAccountBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        // Constructor with dependency injection for UnitOfWork
        public AccountBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BusinessResult> Delete(int id)
        {
            try
            {
                var result = false;
                var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
                if(account != null && account.Result.)

            }catch(Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<BusinessResult> GetAll()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, accounts);
        }

        public async Task<BusinessResult> GetById(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Account());
            }

            return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, account);
        }

        public async Task<BusinessResult> Save(Account account)
        {
            if (account == null)
            {
                return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, null);
            }

            await _unitOfWork.AccountRepository.SaveAsync(account);
            await _unitOfWork.SaveAsync();

            return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, account);
        }

       
    }
}