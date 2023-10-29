using FastDeliveryBE.DTOs.Users;
using FastDeliveryBE.Helpers;
using System.Text.Json;

namespace FastDeliveryBE.Repositories.Users
{
    public class Users : IUsers
    {
        FastDeliveryContext context;
        private readonly ILogger<Users> logger;

        public Users(FastDeliveryContext context, ILogger<Users> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task AddUser(User profile)
        {
            try
            {
                User? existingUser =
                   await context.Users.FirstOrDefaultAsync
                   (x =>
                   x.UserId == profile.UserId);


                if (existingUser != null)
                {
                    logger.LogError($"Error When Add Department => Already Exist,input data {JsonSerializer.Serialize(profile)}");


                    throw new BusinessException(null, "EF-010", "AddUser-AlreadyExist",
                        this.GetType().Name, nameof(AddUser),
                               new Dictionary<string, object>() { { "profile", profile } });


                }


                context.Users.Add(profile);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Add Employee Profile ,input data " +
                    $"{JsonSerializer.Serialize(profile)} Ex :{ex.ToString()} ");

                throw ex;
            }
        }


        public async Task ChangeEmployeeDepartment(Guid userId, int departmentID, int subDepartmentID)
        {
            try
            {
                User? User = await context.Users.FirstOrDefaultAsync(x => x.UserId == userId);

                if (User == null)
                {
                    logger.LogError($"Error When Change Employee Department =>" +
                        $" Not Exist,input data :userId :{userId} ," +
                        $" departmentID : {departmentID} , subDepartmentID: {subDepartmentID}");


                    throw new BusinessException(null, "EF-010", "ChangeEmployeeDepartment-NotExist",
                        this.GetType().Name, nameof(ChangeEmployeeDepartment),
                               new Dictionary<string, object>() { { "departmentID", departmentID }, { "userId", userId } });

                }

                var newEntity = User;
                newEntity.SubDepartmentId = subDepartmentID;
                newEntity.DepartmentId = departmentID;

                context.Entry(User).CurrentValues.SetValues(newEntity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Change Employee Department ,input data " +
                    $" userId : {userId} , departmentID : {departmentID}, Ex :{ex.ToString()} ");

                throw ex;
            }

        }


        public async Task<User?> GetByUserID(Guid userId)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<User?> GetByUserName(string username)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }


        public async Task UpdateUser(User user)
        {
            try
            {
                User oldEntity =await context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);

                if (oldEntity == null)
                {
                    logger.LogError($"Error When Update Employee Profile =>" +
                        $" Not Exist,input data :user :{user}");


                    throw new BusinessException(null, "EF-010", "UpdateUser-NotExist",
                        this.GetType().Name, nameof(UpdateUser),
                               new Dictionary<string, object>() { { "profile", user } });

                }

                context.Entry(oldEntity).CurrentValues.SetValues(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Update Employee Profile ,input data : {user}, Ex :{ex.ToString()} ");

                throw ex;
            }
        }

        public async Task<List<User>> GetUsersByDepartment(int? departmentID, int? subDepartmentID)
        {
            return await context.Users
                  .Where(x =>
                  (subDepartmentID == null || x.SubDepartmentId == subDepartmentID) &&
                  (departmentID == null || x.DepartmentId == departmentID)).ToListAsync();
        }

        public async Task<List<User>> SearchUsers(SearchUsersDTO dto)
        {

            return await context.Users
                  .Where(x =>
                  (dto.UserID==null || x.UserId == dto.UserID) &&
                  (dto.SubDepartmentID == null || x.SubDepartmentId == dto.SubDepartmentID) &&
                  (dto.DepartmentID == null || x.DepartmentId == dto.DepartmentID))
                  .Skip(dto.PageSize * (dto.PageIndex - 1)).Take(dto.PageSize).ToListAsync();
        }

    }
}
