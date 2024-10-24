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
        Task<IBusinessResult> Save(Order order);
        Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> GetAllPriceIdAsync();
        Task<IBusinessResult> GetAllCustomerIdAsync();
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

        public async Task<IBusinessResult> Save(Order order)
        {
            try
            {
                #region Business Rule
                #endregion
                int result = -1;
                var item = this.GetById(order.Id);
                if (item.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.OrderRepository.UpdateAsync(order);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, order);
                    else return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
                else
                {
                    result = await _unitOfWork.OrderRepository.CreateAsync(order);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, order);
                    else return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        
        }

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var result = false;
                var order = this.GetById(id);
                if (order != null && order.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.OrderRepository.RemoveAsync((Order)order.Result.Data);
                    if (result)
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, result);
                    else
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, order.Result.Data);
                }
                else return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> GetAllCustomerIdAsync()
        {
            #region Business Rule

            #endregion
            var orderIds = await _unitOfWork.OrderRepository.GetAllCustomerIdAsync();
            if (orderIds == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderIds);
        }

        public async Task<IBusinessResult> GetAllPriceIdAsync()
        {
            #region Business Rule

            #endregion
            var price = await _unitOfWork.OrderRepository.GetAllPriceIdAsync();
            if (price == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, price);
        }
    }
}
