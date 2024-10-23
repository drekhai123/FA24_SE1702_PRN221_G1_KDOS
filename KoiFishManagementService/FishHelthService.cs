using KDOS.Data.Models;
using KoiFishManagementRespository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFishManagementService
{
    public class FishHelthService : IFishHelthService 
    {
        private readonly IUnitOfWork _unitOfWork;

       
        public FishHelthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public List<FishHealth> GetAllFishesHelth()
        {
            return _unitOfWork.fishHelthRepository.GetAllFishes();
        }

        
        public FishHealth GetFishHelthById(int id)
        {
            return _unitOfWork.fishHelthRepository.GetKoiFishById(id);
        }

        
        public void AddFishHelth(FishHealth fishHealth )
        {
            _unitOfWork.fishHelthRepository.AddKoiFish(fishHealth);
            _unitOfWork.Commit();
        }

       
        public void UpdateFishHelth(FishHealth fishHealth)
        {
            _unitOfWork.fishHelthRepository.UpdateKoiFish(fishHealth);
            _unitOfWork.Commit();
        }

       
        public void DeleteFishHelth(int id)
        {
            _unitOfWork.fishHelthRepository.DeleteKoiFish(id);
            _unitOfWork.Commit();
        }
        public List<OrderDetail> GetAllOrderDetails() 
        {
            return _unitOfWork.fishHelthRepository.GetAllOrderDetails();
         
        }
        public List<Order> GetAllOrderIds()
        {
            return _unitOfWork.fishHelthRepository.GetAllOrderIds();
        }


    }
}
