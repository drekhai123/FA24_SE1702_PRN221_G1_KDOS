using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManagementService
{
    public interface IFishHelthService
    {
        List<FishHealth> GetAllFishesHelth();
        FishHealth GetFishHelthById(int id);
        void AddFishHelth(FishHealth fishHealth);
        void UpdateFishHelth(FishHealth fishHealth);
        void DeleteFishHelth(int id);
        List<OrderDetail> GetAllOrderDetails();
        List<Order> GetAllOrderIds();
    }
}
