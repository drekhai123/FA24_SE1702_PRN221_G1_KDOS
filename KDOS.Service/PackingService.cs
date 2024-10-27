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
    public interface IPackingService
    {
        Task<List<Packing>> GetAllPackingAsync();
        Task<Packing> GetPackingByIdAsync(int id);
        Task<IBusinessResult> SavePackingAsync(Packing packing);
        Task<IBusinessResult> DeletePackingAsync(int id);
    }

    public class PackingService : IPackingService
    {
        private readonly UnitOfWork _unitOfWork;

        public PackingService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<List<Packing>> GetAllPackingAsync()
        {
            return await _unitOfWork.PackingRepository.GetAllPackingAsync();
        }

        public async Task<Packing> GetPackingByIdAsync(int id)
        {
            return await _unitOfWork.PackingRepository.GetPackingByIdAsync(id);
        }

        public async Task<IBusinessResult> SavePackingAsync(Packing packing)
        {
            try
            {
                #region Business Rule
                #endregion
                var existingPacking = await _unitOfWork.PackingRepository.GetPackingByIdAsync(packing.Id);

                if (existingPacking == null)
                {
                    await _unitOfWork.PackingRepository.CreateAsync(packing);
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    _unitOfWork.PackingRepository.UpdateAsync(packing);
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            { 
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> DeletePackingAsync(int id)
        {
            #region Business Rule
            #endregion
            var packing = await _unitOfWork.PackingRepository.GetPackingByIdAsync(id);
            if (packing == null)
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

            _unitOfWork.PackingRepository.DeletePacking(packing);
            return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
        }
    }
}
