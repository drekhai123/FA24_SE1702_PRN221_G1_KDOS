using KDOS.Common;
using KDOS.Data;
using KDOS.Data.Models;
using KDOS.Service.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Service
{

    public interface IFishHealthService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Save(FishHealth fishHealth);
        Task<IBusinessResult> UpdateFishHealthAsync(FishHealth fishHealth);
        Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> GetAllOrderDetails();
        Task<IBusinessResult> GetAllOrderIds();
    } 

    public class FishHealthService : IFishHealthService
    {
        private readonly UnitOfWork _unitOfWork;
        public FishHealthService() => _unitOfWork ??= new UnitOfWork();


        public async Task<IBusinessResult> GetAll()
        {
            #region Business Rule

            #endregion
            var fishhealthlist = await _unitOfWork.FishHealthRepository.GetAllAsync();
            if (fishhealthlist == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, fishhealthlist);
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            #region Business Rule
            #endregion
            var fishHealth = await _unitOfWork.FishHealthRepository.GetByIdAsync(id);
            if (fishHealth == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, fishHealth);
        }


        public async Task<IBusinessResult> Save(FishHealth fishHealth)
        {
            try
            {
                #region Business Rule

                #endregion
                int result = -1;
                var item = await this.GetById(fishHealth.Id);
                if (item.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.FishHealthRepository.UpdateAsync(fishHealth);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, fishHealth);
                    else
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
                else
                {
                    result = await _unitOfWork.FishHealthRepository.CreateAsync(fishHealth);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, fishHealth);
                    else
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }
        public async Task<IBusinessResult> UpdateFishHealthAsync(FishHealth fishHealth)
        {
            try
            {
                #region Business Rule

                // Add any business rules here if needed

                #endregion

                var existingFishHealth = await _unitOfWork.FishHealthRepository.GetByIdAsync(fishHealth.Id);

                if (existingFishHealth != null)
                {
                    // Update the properties of the existing fish health record
                    existingFishHealth.Temperature = fishHealth.Temperature;
                    existingFishHealth.OxygenLevel = fishHealth.OxygenLevel;
                    existingFishHealth.PHLevel = fishHealth.PHLevel;
                    existingFishHealth.AmmoniaLevel = fishHealth.AmmoniaLevel;
                    existingFishHealth.HealthCheckDate = fishHealth.HealthCheckDate;
                    existingFishHealth.HealthStatus = fishHealth.HealthStatus;
                    existingFishHealth.Notes = fishHealth.Notes;

                    // Save changes asynchronously
                    int result = await _unitOfWork.FishHealthRepository.UpdateAsync(existingFishHealth);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, existingFishHealth);
                    else
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG);
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
                var fishHealth = this.GetById(id);
                if (fishHealth != null && fishHealth.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.FishHealthRepository.RemoveAsync((FishHealth)fishHealth.Result.Data);
                    if (result)
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, result);
                    else
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, fishHealth.Result.Data);
                }
                else return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> GetAllOrderDetails()
        {
            #region Business Rule

            #endregion
            var orderDetails = await _unitOfWork.FishHealthRepository.GetAllOrderDetailsAsync();
            if (orderDetails == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderDetails);
        }

        public async Task<IBusinessResult> GetAllOrderIds()
        {
            #region Business Rule

            #endregion
            var orderIds = await _unitOfWork.FishHealthRepository.GetAllOrderIdsAsync();
            if (orderIds == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderIds);
        }

      
    }
}
