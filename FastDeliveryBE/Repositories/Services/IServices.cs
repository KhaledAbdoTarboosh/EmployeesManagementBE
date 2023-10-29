namespace FastDeliveryBE.Repositories.Services
{
    public interface IServices
    {
        public Task<List<Service>> GetAllServices();
    }
}
