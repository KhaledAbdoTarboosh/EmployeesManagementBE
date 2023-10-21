using FastDeliveryBE.DTOs.DepartmentApprovals;
using FastDeliveryBE.Models;
using FastDeliveryBE.Helpers;
using FastDeliveryBE.Repositories.Departments;
using System.Collections;
using System.Text.Json;

namespace FastDeliveryBE.Repositories.Approvals
{
    public class DepartmentApprovals : IDepartmentApprovals
    {

        FastDeliveryContext context;
        private readonly ILogger<DepartmentApprovals> logger;

        public DepartmentApprovals(FastDeliveryContext context, ILogger<DepartmentApprovals> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public async Task AddDepartmentApprovalLevel(DepartmentsApprovalLevel item)
        {
            try
            {
                DepartmentsApprovalLevel? existingDepartmentApproval =
                   await context.DepartmentsApprovalLevels.FirstOrDefaultAsync
                   (x =>
                   x.DepartmentId == item.DepartmentId &&
                   x.LevelOfApproval == item.LevelOfApproval 
                   );


                if (existingDepartmentApproval != null)
                {
                    logger.LogError($"Error When Add Department Approval Level =>" +
                        $" Already Exist,input data {JsonSerializer.Serialize(item)}");


                    throw new BusinessException(null, "EF-010", "AddDepartmentsApprovalLevel-AlreadyExist",
                        this.GetType().Name, nameof(AddDepartmentApprovalLevel),
                               new Dictionary<string, object>() { { "DepartmentsApprovalLevel", item } });


                }

                int ID = await context.DepartmentsApprovalLevels.MaxAsync(x => x.Id) + 1;
                item.Id = ID;

                context.DepartmentsApprovalLevels.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Add Department Approval Level ,input data {JsonSerializer.Serialize(item)} Ex :{ex.ToString()} ");

                throw ex;
            }
        }

        public async Task DeleteDepartmentApprovalLevel(DepartmentsApprovalLevel item)
        {
            try
            {
                var oldEntity =await context.DepartmentsApprovalLevels
                    .FirstOrDefaultAsync(t => t.DepartmentId == item.DepartmentId
                    && t.ForManager == item.ForManager && t.LevelOfApproval == item.LevelOfApproval);
               

                if (oldEntity == null)
                {
                    logger.LogError($"Error When Delete DepartmentApprovalLevel =>" +
                        $" Not Exist,input data :{JsonSerializer.Serialize(item)}");


                    throw new BusinessException(null, "EF-010", "DeleteDepartmentApprovalLevel-NotExist",
                        this.GetType().Name, nameof(DeleteDepartmentApprovalLevel), null);


                }

                context.DepartmentsApprovalLevels.Remove(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Delete Department Approval Level ,input data {JsonSerializer.Serialize(item)} , Ex :{ex.ToString()} ");

                throw ex;
            }
        }

        public async Task<ArrayList> GetDepartmentManagerAndHisDelegates(Guid? operationID, int departmentID)
        {
            ArrayList list = new ArrayList
            {
               context.Departments.First(x => x.DepartmentId == departmentID).ManagerUserId
            };

            list.AddRange(
                context.DepartmentsApprovalDelegations
                .Where(x => x.DelegatorDepartmentId == departmentID)
                .Select(x => x.DelegatedUserId).ToList()
            );

            ArrayList list2 = new ArrayList();

            list2.AddRange(context.Users.Where
                (x => list.Contains(x.UserId)).Select(y => y.UserId).ToList());

            return list2;
        }

        public async Task<List<DepartmentsApprovalLevel>> GetDepartmentsApprovalLevelsGetAll(SearchDeprtmentApprovalDTO dto)
        {
            return await context.DepartmentsApprovalLevels
                .Where(x =>              
                (dto.departmentID == null || x.DepartmentId == dto.departmentID) &&
                (dto.managerDepartmentID == null || x.ManagerDepartmentId == dto.managerDepartmentID) &&
                (dto.approvalLevel == null || x.LevelOfApproval == dto.approvalLevel) &&
                (dto.forManager == null || x.ForManager == dto.forManager)
                ).ToListAsync();
        }

        public async Task UpdateDepartmentApprovalLevel(DepartmentsApprovalLevel item)
        {
            try
            {
                context.Set<DepartmentsApprovalLevel>().Remove(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error When Update Department Approval Level " +
                    $",input data {JsonSerializer.Serialize(item)} Ex :{ex.ToString()} ");

                throw ex;
            }
        }
    }
}
