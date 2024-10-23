using KDOS.Data.Data;
using KDOS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishHealthManagementDAO
{
    public class FishHelthDAO : IFishHelthDAO
    {
        private readonly FA24_SE1702_PRN221_G1_KDOSContext _context;

        public FishHelthDAO()
        {
            _context = new FA24_SE1702_PRN221_G1_KDOSContext();
        }


        public List<FishHealth> GetAllFishHealthsWithOrderDetails()
        {
            var result = (from fh in _context.FishHealths
                          join od in _context.OrderDetails on fh.OrderDetailsId equals od.OrderDetailsId
                          select new FishHealth
                          {
                              Id = fh.Id,
                              OrderDetailsId = fh.OrderDetailsId,
                              OrderId = fh.OrderId,
                              Temperature = fh.Temperature,
                              OxygenLevel = fh.OxygenLevel,
                              PHLevel = fh.PHLevel,
                              AmmoniaLevel = fh.AmmoniaLevel,
                              HealthCheckDate = fh.HealthCheckDate,
                              HealthStatus = fh.HealthStatus,
                              Notes = fh.Notes,

                              OrderDetails = new OrderDetail
                              {
                                  Size = od.Size,
                                  Weight = od.Weight,
                                  Quantity = od.Quantity,
                                  CategoryId = od.CategoryId,
                                  CreatedAt = od.CreatedAt
                              }
                          }).ToList();

            return result;
        }

        public FishHealth GetFishHealthById(int id)
        {
            var result = (from fh in _context.FishHealths
                          join od in _context.OrderDetails on fh.OrderDetailsId equals od.OrderDetailsId
                          where fh.Id == id
                          select new FishHealth
                          {
                              Id = fh.Id,
                              OrderDetailsId = fh.OrderDetailsId,
                              OrderId = fh.OrderId,
                              Temperature = fh.Temperature,
                              OxygenLevel = fh.OxygenLevel,
                              PHLevel = fh.PHLevel,
                              AmmoniaLevel = fh.AmmoniaLevel,
                              HealthCheckDate = fh.HealthCheckDate,
                              HealthStatus = fh.HealthStatus,
                              Notes = fh.Notes,

                              OrderDetails = new OrderDetail
                              {
                                  Size = od.Size,
                                  Weight = od.Weight,
                                  Quantity = od.Quantity,
                                  CategoryId = od.CategoryId,
                                  CreatedAt = od.CreatedAt
                              }
                          }).SingleOrDefault();

            return result;
        }

        public void AddFishHealth(FishHealth fishHealth)
        {
            _context.FishHealths.Add(fishHealth);
            _context.SaveChanges();
        }

        public void UpdateFishHealth(FishHealth fishHealth)
        {
            var existingFishHealth = _context.FishHealths.SingleOrDefault(b => b.Id == fishHealth.Id);
            if (existingFishHealth != null)
            {
                existingFishHealth.Temperature = fishHealth.Temperature;
                existingFishHealth.OxygenLevel = fishHealth.OxygenLevel;
                existingFishHealth.PHLevel = fishHealth.PHLevel;
                existingFishHealth.AmmoniaLevel = fishHealth.AmmoniaLevel;
                existingFishHealth.HealthCheckDate = fishHealth.HealthCheckDate;
                existingFishHealth.HealthStatus = fishHealth.HealthStatus;
                existingFishHealth.Notes = fishHealth.Notes;
                _context.SaveChanges();
            }
        }

        public void DeleteFishHealth(int id)
        {
            var fishHealthToDelete = _context.FishHealths.SingleOrDefault(b => b.Id == id); ;
            if (fishHealthToDelete != null)
            {
                //var orderDetailToDelete = _context.OrderDetails
                //    .SingleOrDefault(od => od.OrderDetailsId == fishHealthToDelete.OrderDetailsId);
                _context.FishHealths.Remove(fishHealthToDelete);

                //if (orderDetailToDelete != null)
                //{
                //    _context.OrderDetails.Remove(orderDetailToDelete);
                //}
                _context.SaveChanges();
            }
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return (from od in _context.OrderDetails
                    select new OrderDetail
                    {
                        OrderDetailsId = od.OrderDetailsId,
                        OrderId = od.OrderId,
                        CategoryId = od.CategoryId,
                        Size = od.Size,
                        Weight = od.Weight,
                        HealthStatus = od.HealthStatus,
                        CreatedAt = od.CreatedAt,
                        Quantity = od.Quantity
                    }).ToList();
        }
        public List<Order> GetAllOrderIds()
        {
            return (from ode in _context.Orders
                    select new Order
                    {
                        Id = ode.Id
                    }).ToList();
        }
    }
}
