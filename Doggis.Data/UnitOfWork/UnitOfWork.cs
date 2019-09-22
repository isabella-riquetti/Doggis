using Doggis.Data.Models;
using Doggis.Data.Repository;
using System;

namespace Doggis.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DoggisContext _context = new DoggisContext();

        public UnitOfWork()
        {
            Client = new ClientRepository(_context);
            Order = new OrderRepository(_context);
            OrderItem = new OrderItemRepository(_context);
            Pet = new PetRepository(_context);
            Product = new ProductRepository(_context);
            Promotion = new PromotionRepository(_context);
            Service = new ServiceRepository(_context);
            ServicePriceHistory = new ServicePriceHistoryRepository(_context);
            ServiceSchedule = new ServiceScheduleRepository(_context);
            User = new UserRepository(_context);
            UserAvaliation = new UserAvaliationRepository(_context);
            VeterinaryAllowedSpecies = new VeterinaryAllowedSpeciesRepository(_context);
        }

        public IClientRepository Client { get; set; }
        public IOrderRepository Order { get; set; }
        public IOrderItemRepository OrderItem { get; set; }
        public IPetRepository Pet { get; set; }
        public IProductRepository Product { get; set; }
        public IPromotionRepository Promotion { get; set; }
        public IServiceRepository Service { get; set; }
        public IServicePriceHistoryRepository ServicePriceHistory { get; set; }
        public IServiceScheduleRepository ServiceSchedule { get; set; }
        public IUserRepository User { get; set; }
        public IUserAvaliationRepository UserAvaliation { get; set; }
        public IVeterinaryAllowedSpeciesRepository VeterinaryAllowedSpecies { get; set; }

        private bool _disposed;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }

        private void Clear(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Clear(false);
        }
    }
}

