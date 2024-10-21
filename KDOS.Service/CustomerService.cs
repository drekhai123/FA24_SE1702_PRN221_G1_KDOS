using KDOS.Common;
using KDOS.Data;
using KDOS.Data.Models;
using KDOS.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Service
{
    public interface ICustomerService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Save(Customer customer);
        Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> GetByUsernameAndPassword(Customer customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerService() => _unitOfWork ??= new UnitOfWork();
        public async Task<IBusinessResult> GetAll()
        {
            #region Business Rule

            #endregion
            var customerList = await _unitOfWork.CustomerRepository.GetAllAsync();
            if (customerList == null) 
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customerList);
        }
        public async Task<IBusinessResult> GetById(int id)
        {
            #region Business Rule
            #endregion
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer == null) 
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE,Const.SUCCESS_READ_MSG, customer);
        }
        public async Task<IBusinessResult> Save(Customer customer)
        {
            try
            {
                #region Business Rule
                #endregion
                int result = -1;
                var item = this.GetById(customer.Id);
                if (item.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.CustomerRepository.UpdateAsync(customer);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, customer);
                    else return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
                else
                {
                    result = await _unitOfWork.CustomerRepository.CreateAsync(customer);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, customer);
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
                var customer = this.GetById(id);
                if(customer != null && customer.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.CustomerRepository.RemoveAsync((Customer)customer.Result.Data);
                    if (result)
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, result);
                    else
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, customer.Result.Data);
                }else return new BusinessResult(Const.WARNING_NO_DATA_CODE,Const.WARNING_NO_DATA_MSG);
                
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> GetByUsernameAndPassword(Customer user)
        {
            #region Business Rule
            #endregion
            var customer = await _unitOfWork.CustomerRepository.GetUser(user);
            if (customer == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customer);
        }
    }
}
