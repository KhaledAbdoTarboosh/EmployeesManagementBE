using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FastDeliveryBE.Models.Identity
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
