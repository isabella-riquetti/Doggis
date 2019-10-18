using Doggis.Data.Repository;

namespace Doggis.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; set; }
        IOrderRepository Order { get; set; }
        IOrderItemRepository OrderItem { get; set; }
        IPetRepository Pet { get; set; }
        IProductRepository Product { get; set; }
        IPromotionRepository Promotion { get; set; }
        IServiceRepository Service { get; set; }
        IServicePriceHistoryRepository ServicePriceHistory { get; set; }
        IServiceScheduleRepository ServiceSchedule { get; set; }
        IUserRepository User { get; set; }
        IUserAvaliationRepository UserAvaliation { get; set; }

        void Commit();
    }
}
