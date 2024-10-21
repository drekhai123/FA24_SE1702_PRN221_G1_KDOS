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
    public interface IOrderService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderService() => _unitOfWork ??= new UnitOfWork();
        public async Task<IBusinessResult> GetAll()
        {
            #region Business Rule

            #endregion
            var orderList = await _unitOfWork.OrderRepository.GetAllAsync(x => x.Customer, x => x.Price); 
            if (orderList == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderList);
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            #region Business Rule
            #endregion
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, order);
        }
    }
}
