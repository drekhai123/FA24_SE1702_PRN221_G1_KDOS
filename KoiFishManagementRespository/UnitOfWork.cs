using FishHealthManagementDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace KoiFishManagementRespository
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        private IFishHelthRepository _fishHelthRepository;
        private IFishHelthDAO _fishHelthDAO;

        // Constructor để nhận vào DbContext
        public UnitOfWork(TContext context, IFishHelthDAO fishHelthDAO)
        {
            _context = context;
            _fishHelthDAO = fishHelthDAO;   
        }

 
        public IFishHelthRepository fishHelthRepository =>
            _fishHelthRepository ??= new FishHelthRepository(_fishHelthDAO);

        // Commit và CommitAsync
        public int Commit() => _context.SaveChanges();

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        // Dispose context sau khi xong việc
        public void Dispose() => _context.Dispose();
    }

}