using FastDeliveryBE.DTOs.Users;

namespace FastDeliveryBE.Repositories.Users
{
    public interface IUsers
    {
        Task AddUser(User profile);

        Task ChangeEmployeeDepartment(Guid userId, int departmentID,int subDepartmentID);

        Task<User> GetByUserID(Guid userId);

        Task UpdateUser(User profile);

        Task<List<User>> GetUsersByDepartment(int? departmentID, int? subDepartmentID);

        Task<List<User>> SearchUsers(SearchUsersDTO dto);
    }
}
