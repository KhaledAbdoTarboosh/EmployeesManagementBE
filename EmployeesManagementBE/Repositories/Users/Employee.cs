//using EmployeesManagementBE.Helpers;
//using EmployeesManagementBE.Repositories.Users;
//using FastDeliveryBE.DTOs.Employees;
//using System.Text.Json;

//namespace EmployeesManagementBE.Repositories.Employees
//{
//    public class Employee : IEmployee
//    {
//        EmployeesManagementContext context;
//        private readonly ILogger<Employee> logger;

//        public Employee(EmployeesManagementContext context, ILogger<Employee> logger)
//        {
//            this.context = context;
//            this.logger = logger;
//        }

//        public async Task AddEmployee(Employee employee)
//        {
//            try
//            {
//                Employee? existingEmployee =
//                   await context.Employees.FirstOrDefaultAsync
//                   (x =>
//                   x.EmployeeId == profile.EmployeeId);


//                if (existingEmployee != null)
//                {
//                    logger.LogError($"Error When Add Department => Already Exist,input data {JsonSerializer.Serialize(profile)}");


//                    throw new BusinessException(null, "EF-010", "AddEmployee-AlreadyExist",
//                        this.GetType().Name, nameof(AddEmployee),
//                               new Dictionary<string, object>() { { "profile", profile } });


//                }


//                context.Employees.Add(profile);
//                context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                logger.LogError($"Error When Add Employee Profile ,input data " +
//                    $"{JsonSerializer.Serialize(profile)} Ex :{ex.ToString()} ");

//                throw ex;
//            }
//        }  


//        public async Task<Employee?> GetByEmployeeID(Guid EmployeeId)
//        {
//            return await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
//        }     


//        public async Task UpdateEmployee(Models.Employee employee)
//        {
//            try
//            {
//                Employee oldEntity = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == Employee.EmployeeId);

//                if (oldEntity == null)
//                {
//                    logger.LogError($"Error When Update Employee Profile =>" +
//                        $" Not Exist,input data :Employee :{Employee}");


//                    throw new BusinessException(null, "EF-010", "UpdateEmployee-NotExist",
//                        this.GetType().Name, nameof(UpdateEmployee),
//                               new Dictionary<string, object>() { { "profile", Employee } });

//                }

//                context.Entry(oldEntity).CurrentValues.SetValues(Employee);
//                context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                logger.LogError($"Error When Update Employee Profile ,input data : {Employee}, Ex :{ex.ToString()} ");

//                throw ex;
//            }
//        }
        

//        public async Task<List<Employee>> SearchEmployees(SearchEmployeesDTO dto)
//        {

//            return await context.Employees
//                  .Where(x =>
//                  (dto.ID == null || x.ID == dto.ID) &&                 
//                  (dto.DepartmentID == null || x.Department.de == dto.DepartmentID))
//                  .Skip(dto.PageSize * (dto.PageIndex - 1)).Take(dto.PageSize).ToListAsync();
//        }

//    }
//}
