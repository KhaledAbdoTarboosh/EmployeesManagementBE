using FastDeliveryBE.DTOs;
using FastDeliveryBE.DTOs.Services;
using FastDeliveryBE.Models;
using FastDeliveryBE.Repositories.Departments;
using FastDeliveryBE.Repositories.Services;

namespace FastDeliveryBE.Services
{
    public class ServicesService
    {
        IServices servicesRepo;
        private readonly IMapper _mapper;

        public ServicesService(IServices servicesRepo, IMapper mapper)
        {
            this.servicesRepo = servicesRepo;
            this._mapper = mapper;
        }


        public async Task<List<ServiceInfo>> GetAllServices()
        {

            List<Service> svcs = await servicesRepo.GetAllServices();

            List<ServiceInfo> services = this._mapper.Map<List<ServiceInfo>>(svcs);

            return services;

        }


       






    }
}
