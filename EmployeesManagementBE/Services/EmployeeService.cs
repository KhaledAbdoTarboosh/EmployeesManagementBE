using EmployeesManagementBE.DTOs.Employees;
using EmployeesManagementBE.Helpers;
using EmployeesManagementBE.Repositories.Base;
using FastDeliveryBE.DTOs.Employees;

namespace EmployeesManagementBE.Services
{
    public class EmployeeService
    {

        IBaseRepositoy<Employee> profilesRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IBaseRepositoy<Employee> profilesRepo, IMapper mapper)
        {
            this.profilesRepo = profilesRepo;
            this._mapper = mapper;
        }


        public async Task<EmployeeInfo> GetByEmployeeID(int EmployeeID)
        {
            Employee profile = await profilesRepo.GetByIdAsync(EmployeeID);

            EmployeeInfo employee = this._mapper.Map<EmployeeInfo>(profile);

            //TODO get departmentRatio from department table 
            double departmentRatio = 0.02;


            // in case of employee does not have evaluation yet
            if (employee.EvaluationRate == null)
            {
                employee.EvaluationRate = 5;
            }


            employee.Bounce = BonusGenerator.GetBonus(employee.MonthlySalary, departmentRatio, employee.EvaluationRate.Value);

            return employee;
        }     

        public async Task AddEmployee(EmployeeInfo profile)
        {
            //
            //TODO Add attachments to Image Server and get urls
            //

            Employee employee = this._mapper.Map<Employee>(profile);


            
            await profilesRepo.AddAsync(employee);
        }
       

        public void UpdateEmployee(EmployeeInfo profile)
        {
            Employee Employee = this._mapper.Map<Employee>(profile);

             profilesRepo.Update(Employee);
        }
      

        public async Task<List<EmployeeInfo>> SearchEmployees(SearchEmployeesDTO dto)
        {
            int skip = (dto.PageIndex - 1) * dto.PageSize;


            
            Task<IEnumerable<Employee>> profiles = (Task<IEnumerable<Employee>>)await profilesRepo.FindAllAsync(dto.criteria, dto.PageSize, skip);

            List<EmployeeInfo> Employees = this._mapper.Map<List<EmployeeInfo>>(profiles);

            return Employees;
        }



        public async Task<EmployeeInfo> GetEmployeeByEmail(SearchEmployeesDTO dto)
        {
            Employee profile = (Employee) profilesRepo.Find(dto.criteria);

            EmployeeInfo Employee = this._mapper.Map<EmployeeInfo>(profile);

            return Employee;
        }




    }
}
