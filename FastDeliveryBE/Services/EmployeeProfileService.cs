using FastDeliveryBE.DTOs.Users;
using FastDeliveryBE.Repositories.Users;

namespace FastDeliveryBE.Services
{
    public class UserService
    {

        IUsers profilesRepo;
        private readonly IMapper _mapper;

        public UserService(IUsers profilesRepo, IMapper mapper)
        {
            this.profilesRepo = profilesRepo;
            this._mapper = mapper;
        }

    

        public async Task<UserInfo> GetByUserID(Guid UserID)
        {
            User profile = await profilesRepo.GetByUserID(UserID);

            UserInfo User = this._mapper.Map<UserInfo>(profile);

            return User;
        }

        public async Task AddUser(UserInfo profile)
        {
            User User = this._mapper.Map<User>(profile);

            await profilesRepo.AddUser(User);
        }

        public async Task ChangeEmployeeDepartment(Guid userId, int departmentID, int subDepartmentID)
        {
            await profilesRepo.ChangeEmployeeDepartment(userId, departmentID, subDepartmentID);
        }

        public async Task UpdateUser(UserInfo profile)
        {
            User User = this._mapper.Map<User>(profile);

            await profilesRepo.UpdateUser(User);
        }

        public async Task<List<UserInfo>> GetUsersByDepartment(int? departmentID, int? subDepartmentID)
        {

            List<User> profiles = await profilesRepo.GetUsersByDepartment(departmentID, subDepartmentID);

            List<UserInfo> Users = this._mapper.Map<List<UserInfo>>(profiles);

            return Users;
        }

        public async Task<List<UserInfo>> SearchUsers(SearchUsersDTO dto)
        {

            List<User> profiles = await profilesRepo.SearchUsers(dto);

            List<UserInfo> Users = this._mapper.Map<List<UserInfo>>(profiles);

            return Users;
        }


    }
}
