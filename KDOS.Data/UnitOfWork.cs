using KDOS.Data.Models;
using KDOS.Data.Repository;

namespace KDOS.Data
{
    public class UnitOfWork
    {
        private FA24_SE1702_211_G1_KDOSContext _unitOfWorkContext;
        private AccountRepository _accountRepository;
        public UnitOfWork()
        {
            _unitOfWorkContext = new FA24_SE1702_211_G1_KDOSContext();
        }
        public AccountRepository AccountRepository
        {
            get { return _accountRepository ??= new Repository.AccountRepository(_unitOfWorkContext); }
        }
        // This operator initializes _accountRepository only if it is currently null lazy initialization in a single line. 
    }
}
