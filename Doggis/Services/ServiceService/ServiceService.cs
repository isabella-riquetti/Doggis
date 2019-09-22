using Doggis.Data.Models;
using Doggis.Data.UnitOfWork;
using System.Collections.Generic;

namespace Doggis.Services.ServiceService
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> Get()
        {
            return _unitOfWork.Product.Get();
        }
    }
}