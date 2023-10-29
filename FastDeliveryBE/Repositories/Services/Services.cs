namespace FastDeliveryBE.Repositories.Services
{
    public class Services : IServices
    {


        FastDeliveryContext context;
        private readonly ILogger<Services> logger;

        public Services(FastDeliveryContext context, ILogger<Services> logger)
        {
            this.context = context;
            this.logger = logger;
        }
     


        public async Task<List<Service>> GetAllServices()
        {
            return await context.Services.ToListAsync();
        }
    }
}
