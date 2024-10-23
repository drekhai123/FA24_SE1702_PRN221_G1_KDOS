using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishHealthManagementDAO
{
    public interface IFishHelthDAO
    {
        List<FishHealth> GetAllFishHealthsWithOrderDetails();
        FishHealth GetFishHealthById(int id);
        void AddFishHealth(FishHealth fishHealth);
        void UpdateFishHealth(FishHealth fishHealth);
        void DeleteFishHealth(int id);
        List<OrderDetail> GetAllOrderDetails();
        List<Order> GetAllOrderIds();
    }
}
