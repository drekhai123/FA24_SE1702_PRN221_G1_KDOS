using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FishHealthManagementDAO;

namespace KoiFishManagementRespository
{
    public class FishHelthRepository : IFishHelthRepository
    {
        private readonly IFishHelthDAO _dao;

        public FishHelthRepository(IFishHelthDAO dao)
        {
            _dao = dao;
        }

        public List<FishHealth> GetAllFishes() => _dao.GetAllFishHealthsWithOrderDetails();
        public FishHealth GetKoiFishById(int id) => _dao.GetFishHealthById(id);
        public void AddKoiFish(FishHealth fishHealth) => _dao.AddFishHealth(fishHealth);
        public void UpdateKoiFish(FishHealth fishHealth) => _dao.UpdateFishHealth(fishHealth);
        public void DeleteKoiFish(int id) => _dao.DeleteFishHealth(id);
        public List<OrderDetail> GetAllOrderDetails() => _dao.GetAllOrderDetails();
        public List<Order> GetAllOrderIds() => _dao.GetAllOrderIds();
    }
}
