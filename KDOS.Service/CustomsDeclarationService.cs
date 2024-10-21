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
    public interface ICustomsDeclarationService
    {
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> GetCustomDeclarationsByOrder(int id);
        Task<IBusinessResult> Save(CustomsDeclaration customsDeclaration);
        Task<IBusinessResult> DeleteById(int id);
    }
    public class CustomsDeclarationService : ICustomsDeclarationService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomsDeclarationService() => _unitOfWork ??= new UnitOfWork();
        public async Task<IBusinessResult> GetById(int id)
        {
            #region Business Rule
            #endregion
            var customsDeclaration = await _unitOfWork.CustomsDeclarationRepository.GetByIdAsync(id);
            if (customsDeclaration == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customsDeclaration);
        }
        public async Task<IBusinessResult> Save(CustomsDeclaration customsDeclaration)
        {
            try
            {
                #region Business Rule
                #endregion
                int result = -1;
                var item = this.GetById(customsDeclaration.Id);
                if (item.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.CustomsDeclarationRepository.UpdateAsync(customsDeclaration);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, customsDeclaration);
                    else return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
                else
                {
                    result = await _unitOfWork.CustomsDeclarationRepository.CreateAsync(customsDeclaration);
                    if (result > 0)
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, customsDeclaration);
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
                var customsDeclaration = this.GetById(id);
                if (customsDeclaration != null && customsDeclaration.Result.Status == Const.SUCCESS_READ_CODE)
                {
                    result = await _unitOfWork.CustomsDeclarationRepository.RemoveAsync((CustomsDeclaration)customsDeclaration.Result.Data);
                    if (result)
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, result);
                    else
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, customsDeclaration.Result.Data);
                }
                else return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> GetCustomDeclarationsByOrder(int id)
        {
            var customsDeclarationList = await _unitOfWork.CustomsDeclarationRepository.GetCustomDeclarationsByOrder(id);
            if (customsDeclarationList == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            else return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, customsDeclarationList);
        }
    }
}
