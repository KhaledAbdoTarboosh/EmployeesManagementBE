using Microsoft.AspNetCore.Identity;

namespace EmployeesManagementBE.Repositories.JWTTokens
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
