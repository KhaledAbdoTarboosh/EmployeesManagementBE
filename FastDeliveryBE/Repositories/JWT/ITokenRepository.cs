using Microsoft.AspNetCore.Identity;

namespace FastDeliveryBE.Repositories.JWTTokens
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
