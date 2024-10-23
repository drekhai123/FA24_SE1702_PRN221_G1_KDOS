using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManagementRespository
{
    public interface IFishHelthRepository
    {
        List<FishHealth> GetAllFishes();
        FishHealth GetKoiFishById(int id);
        void AddKoiFish(FishHealth fishHealth);
        void UpdateKoiFish(FishHealth fishHealth);
        void DeleteKoiFish(int id);
        List<OrderDetail> GetAllOrderDetails();
        List<Order> GetAllOrderIds();
    }
}
