using FastDeliveryBE.DTOs.Delegation;
using FastDeliveryBE.Helpers;
using System.Text.Json;

namespace FastDeliveryBE.Repositories.Delegations
{
    public class DepartmentsApprovalDelegations : IDepartmentsApprovalDelegations
    {

        FastDeliveryContext context;
        private readonly ILogger<DepartmentsApprovalDelegations> logger;

        public DepartmentsApprovalDelegations(FastDeliveryContext context, ILogger<DepartmentsApprovalDelegations> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task AddDepartmentsApprovalDelegation(DepartmentsApprovalDelegation item)
        {

            try
            {
                DepartmentsApprovalDelegation? existingItem = await
                    context.DepartmentsApprovalDelegations.FirstOrDefaultAsync(x =>
                    x.DelegatorDepartmentId == item.DelegatorDepartmentId &&
                    x.DelegatedUserId == item.DelegatedUserId
                    );

                if (existingItem != null)
                {
                    logger.LogError($"Error When Add Department Approval Delegation => Already Exist," +
                        $"input data {JsonSerializer.Serialize(item)}");


                    throw new BusinessException(null, "EF-010", "AddDepartmentsApprovalDelegation-AlreadyExist",
                        this.GetType().Name, nameof(AddDepartmentsApprovalDelegation),
                               new Dictionary<string, object>() { { "DepartmentsApprovalDelegation", item } });
                }

                await context.DepartmentsApprovalDelegations.AddAsync(item);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                logger.LogError($"Error When Add Department Approval Delegation ,input data {JsonSerializer.Serialize(item)} Ex :{ex.ToString()} ");

                throw ex;
            }
        }

        public async Task DeleteDepartmentsApprovalDelegation(DepartmentsApprovalDelegation item)
        {
            try
            {
                DepartmentsApprovalDelegation? existingItem = await
                    context.DepartmentsApprovalDelegations.FirstOrDefaultAsync(x =>
                    x.DelegatorDepartmentId == item.DelegatorDepartmentId &&
                    x.DelegatedUserId == item.DelegatedUserId
                    );

                if (existingItem == null)
                {
                    logger.LogError($"Error When Delete Department Approval Delegation => Not Exist,input data {JsonSerializer.Serialize(item)}");


                    throw new BusinessException(null, "EF-010", "DeleteDepartmentsApprovalDelegation-NotExist",
                        this.GetType().Name, nameof(DeleteDepartmentsApprovalDelegation),
                               new Dictionary<string, object>() { { "DepartmentsApprovalDelegation", item } });
                }

                context.DepartmentsApprovalDelegations.Remove(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Delete Department Approval Delegation ,input data {JsonSerializer.Serialize(item)} Ex :{ex.ToString()} ");

                throw ex;
            }
        }


        public async Task DeleteUserApprovalDelegation(Guid DelegatedUserId)
        {
            try
            {

                List<DepartmentsApprovalDelegation> delegations =
                    await context.DepartmentsApprovalDelegations
                    .Where(x => x.DelegatedUserId == DelegatedUserId)
                    .ToListAsync();

                context.RemoveRange(delegations);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                logger.LogError($"Error When Delete User Approval Delegation ,input data {DelegatedUserId} Ex :{ex.ToString()} ");

                throw ex;
            }

        }

        public async Task<List<DepartmentsApprovalDelegation>> SearchDepartmentsApprovalDelegations
            (SearchDepartmentsApprovalDelegationDTO dto)             
        {
            
            List<DepartmentsApprovalDelegation> delegations =
               await context.DepartmentsApprovalDelegations.Where(x =>
               x.DelegatedUserId == dto.DelegatedUserId &&
               x.DelegatorDepartmentId == dto.delegatorDepartmentID ).ToListAsync();


            return delegations;

        }
      

        public async Task<List<DepartmentsApprovalDelegation>> GetAllDepartmentsApprovalDelegationsByManagerUserIDAndOperationID
            (Guid userId, Guid? operationID)
        {
            User managerEmployeProfile= context.Users.First(x => x.UserId == userId);


            List<DepartmentsApprovalDelegation> delegatedEmployeesList = new List<DepartmentsApprovalDelegation>();
            if (managerEmployeProfile != null)
            {
                IQueryable<DepartmentsApprovalDelegation> delegatedEmployees = context.DepartmentsApprovalDelegations.Where( x=>                  
                (x.DelegatorDepartmentId == managerEmployeProfile.SubDepartmentId || x.DelegatorDepartmentId == managerEmployeProfile.DepartmentId));

                if(delegatedEmployees!=null && delegatedEmployees.Count() >0)
                {
                    delegatedEmployeesList= delegatedEmployees.ToList();
                }
            }

            return delegatedEmployeesList;
        }

    }
}
