using KDOS.Data.Data;
using KDOS.Data.Repositories;

namespace KDOS.Data
{
    public class UnitOfWork
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context;
        private CustomerRepository _customerRepository;
        private CustomsDeclarationRepository _customsDeclarationRepository;
        private OrderRepository _orderRepository;
        private FishHealthRepository _fishHealthRepository; 
        private AccountRepository _accountRepository; 

        public UnitOfWork()
        {
            _context ??= new FA24_SE1702_PRN221_G1_KDOSContext();
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ??= new CustomerRepository(_context);
            }
        }

        public CustomsDeclarationRepository CustomsDeclarationRepository
        {
            get
            {
                return _customsDeclarationRepository ??= new CustomsDeclarationRepository(_context);
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??= new OrderRepository(_context);
            }
        }

        public FishHealthRepository FishHealthRepository
        {
            get
            {
                return _fishHealthRepository ??= new FishHealthRepository(_context);
            }
        }
        public AccountRepository AccountRepository
        {
            get
            {
                return _accountRepository ??= new AccountRepository(_context);
            }
        }
    }
}
