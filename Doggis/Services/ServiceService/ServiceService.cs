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

        public IEnumerable<Service> Get()
        {
            return _unitOfWork.Service.Get();
        }
    }
}