using KDOS.Data.Data;
using KDOS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Data
{
    public class UnitOfWork
    {
        private FA24_SE1702_PRN221_G1_KDOSContext _context;
        private CustomerRepository _customerRepository;
        private CustomsDeclarationRepository _customsDeclarationRepository;
        private OrderRepository _orderRepository;
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
    }
}
