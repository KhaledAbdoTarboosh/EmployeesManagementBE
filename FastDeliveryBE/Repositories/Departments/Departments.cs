using FastDeliveryBE.DTOs;
using FastDeliveryBE.Helpers;
using System.Text.Json;

namespace FastDeliveryBE.Repositories.Departments
{
    public class Departments : IDepartments
    {
        FastDeliveryContext context;
        private readonly ILogger<Departments> logger;

        public Departments(FastDeliveryContext context, ILogger<Departments> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<Department?> GetDepartmentByID(int departmentID)
        {
            return await context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentID);
        }


        public async Task AddDepartment(Department department)
        {
            try
            {
                Department? existingDepartment =
                    await context.Departments.FirstOrDefaultAsync
                    (x => 
                    x.ParentDepartmentId == department.ParentDepartmentId &&
                    x.DepartmentName == department.DepartmentName);


                if (existingDepartment != null)
                {
                    logger.LogError($"Error When Add Department => Already Exist,input data {JsonSerializer.Serialize(department)}");


                    throw new BusinessException(null, "EF-010", "AddDepartment-AlreadyExist",
                        this.GetType().Name, nameof(AddDepartment),
                               new Dictionary<string, object>() { { "department", department } });


                }

                int depID =await context.Departments.MaxAsync(x => x.DepartmentId) + 1;
                department.DepartmentId = depID;
                await context.Departments.AddAsync(department);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Add Department ,input data {JsonSerializer.Serialize(department)} Ex :{ex.ToString()} ");

                throw ex;
            }

        }


        /// <summary>
        /// GetDepartmentsTree
        /// </summary>
        /// <param name="result"></param>
        /// <param name="parentDepartmentID"></param>
        /// <returns></returns>
        public async Task<List<Department>> GetDepartmentsTree(List<Department> result, int parentDepartmentID)
        {

            List<Department> parents = new List<Department>();
            if (result == null || result.Count == 0)
            {
                result = new List<Department>
                {
                    await context.Departments.FirstAsync(x => x.DepartmentId == parentDepartmentID)
                };

            }

            parents.AddRange(context.Departments.Where(x => x.ParentDepartmentId == parentDepartmentID));
            result.AddRange(context.Departments.Where(x => x.ParentDepartmentId == parentDepartmentID));

            for (int i = 0; i < parents.Count; i++)
            {
                await GetDepartmentsTree(result, parents[i].DepartmentId);
            }

            return result;
        }

        public async Task<List<Department>> GetDepartmentParents(List<Department> result, int DepartmentID)
        {
            List<Department> parents = new List<Department>();
            if (result == null || result.Count == 0)
            {
                result = new List<Department>
                {
                    await context.Departments.FirstAsync(x => x.DepartmentId == DepartmentID)
                };
            }

            Department? parentDepartment =
                await context.Departments.FirstOrDefaultAsync(x =>
                x.DepartmentId == result[result.Count - 1].ParentDepartmentId);


            if (parentDepartment != null)
            {
                result.Add(parentDepartment);
                return await GetDepartmentParents(result, parentDepartment.DepartmentId);
            }
            return result;
        }


        public async Task<List<DepartmentEmployeesCountInfo>> GetChildDepartmentEmployeesCount(int DepartmentID)
        {
            IEnumerable<DepartmentEmployeesCountInfo> departments = new List<DepartmentEmployeesCountInfo>();

            departments = (from dp in context.Departments
                           join ep in context.Users
                         on dp.DepartmentId equals ep.SubDepartmentId
                           where dp.IsMain!=null && dp.IsMain
                           group ep by new { dp.DepartmentId, dp.DepartmentName } into g
                           select new DepartmentEmployeesCountInfo
                           {
                               DepartmentId = g.Key.DepartmentId,
                               DepartmentName = g.Key.DepartmentName,
                               EmployeesCount = g.Count()
                           }).AsQueryable();


            List<DepartmentEmployeesCountInfo> departments1 = new List<DepartmentEmployeesCountInfo>();
            departments1 = departments.Cast<DepartmentEmployeesCountInfo>().ToList();
            return departments1;

        }


        public async Task<List<Department>> GetDepartmentsByIds(List<int> depIDs)
        {

            List<Department> depts =await context.Departments
                       .AsNoTracking()
                       .Where(ep => depIDs.Contains(ep.DepartmentId))
                       .ToListAsync();

            return depts;
        }



        public async Task<List<DepartmentManagerInfo>> GetDepartmentsManagrsUserIDsByDepartmentsIDs(List<int> depIDs)
        {
            IEnumerable<DepartmentManagerInfo> departmentsManagers;
            departmentsManagers = (from dp in context.Departments
                                   join ep in context.Users
                                 on dp.ManagerUserId equals ep.UserId
                                   where dp.IsActive && depIDs.Contains(dp.DepartmentId)
                                   select new DepartmentManagerInfo
                                   {
                                       DepartmentId = dp.DepartmentId,
                                       DepartmentName = dp.DepartmentName,
                                       ManagerUserID = ep.UserId,
                                       ManagerName = ep.UserName
                                   });


            List<DepartmentManagerInfo> departmentsManagersList = new List<DepartmentManagerInfo>();
            departmentsManagersList = departmentsManagers.Cast<DepartmentManagerInfo>().ToList();

            return departmentsManagersList;


        }



        public async Task<List<Department>> GetDepartmentsByManagerUserID(Guid managerUserID)
        {
            List<Department> departments;

            User? managerUser = await
                context.Users.FirstOrDefaultAsync(ep => ep.UserId == managerUserID);

            if (managerUser == null)
            {
                return new List<Department>();
            }

            departments = context.Departments.Where(dep => dep.ManagerUserId == managerUser.UserId).ToList();

            return departments;
        }

        public async Task UpdateDepartment(Department department)
        {
            try
            {
                context.Set<Department>().Remove(department);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Update Department ,input data {JsonSerializer.Serialize(department)} Ex :{ex.ToString()} ");

                throw ex;
            }

        }
        public async Task DeleteDepartment(int departmentID)
        {
            try
            {
                var oldEntity =await context.Departments
                       .FirstOrDefaultAsync(t => t.DepartmentId == departmentID);
                var newEntity = oldEntity;

                if (oldEntity == null)
                {
                    logger.LogError($"Error When Delete Department => Not Exist,input data :departmentID :{departmentID}");


                    throw new BusinessException(null, "EF-010", "DeleteDepartment-NotExist",
                        this.GetType().Name, nameof(DeleteDepartment),
                               new Dictionary<string, object>() { { "departmentID", departmentID } });


                }
                
                newEntity.IsActive = false;
                context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Delete Department ,input data departmentID :{departmentID} , Ex :{ex.ToString()} ");

                throw ex;
            }
        }


        public async Task<List<Department>> GetOSDepartments()
        {
            return await context.Departments.Where(x => x.IsMain).ToListAsync();
        }

        public async Task<List<Department>> GetDepartmentsByTypeIds(List<int> depTypesIds)
        {
            return await context.Departments.Include(d => d.DepartmentType)
                .Where(x => depTypesIds.Contains(x.DepartmentTypeId) && x.IsActive)
                .OrderBy(d => d.DepartmentName).ToListAsync();
        }

        public async Task<DepartmentsType> GetDepartmentType(int departmentID)
        {
            Department? dep = await context.Departments.Include(d => d.DepartmentType)
                .FirstOrDefaultAsync(x => x.DepartmentId == departmentID);

            if (dep == null) return null;
            return dep.DepartmentType;

        }

        public async Task SetDepartmentManager(int departmentID, Guid userID)
        {
            try
            {
                User? managerUser =
                    await context.Users.FirstOrDefaultAsync(x => x.UserId == userID);

                if (managerUser == null)
                {
                    logger.LogError($"Error When Set Department Manager => Employee Not Exist,input data :departmentID :{departmentID} , userID : {userID}");


                    throw new BusinessException(null, "EF-010", "SetDepartmentManager-EmployeeNotExist",
                        this.GetType().Name, nameof(SetDepartmentManager),
                               new Dictionary<string, object>() { { "departmentID", departmentID } });

                }

                if (managerUser != null)
                {
                    var oldEntity = context.Departments
                               .FirstOrDefault(t => t.DepartmentId == departmentID);
                    var newEntity = oldEntity;


                    if (oldEntity == null)
                    {
                        logger.LogError($"Error When Set Department Manager => Department Not Exist,input data :departmentID :{departmentID} , userID : {userID}");


                        throw new BusinessException(null, "EF-010", "SetDepartmentManager-DepartmentNotExist",
                            this.GetType().Name, nameof(SetDepartmentManager),
                                   new Dictionary<string, object>() { { "departmentID", departmentID } });


                    }


                    newEntity.ManagerUserId = managerUser.UserId;
                    context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Set Department Manager ,input data departmentID :{departmentID} ,userID :{userID} Ex :{ex.ToString()} ");

                throw ex;
            }

        }

    }
}
