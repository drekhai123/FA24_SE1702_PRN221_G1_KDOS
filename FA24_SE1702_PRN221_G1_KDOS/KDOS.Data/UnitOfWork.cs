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
    }
}
