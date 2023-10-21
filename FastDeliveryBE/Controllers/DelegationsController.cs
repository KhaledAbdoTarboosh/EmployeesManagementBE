using FastDeliveryBE.Helpers;
using FastDeliveryBE.DTOs.Delegation;
using FastDeliveryBE.Services;
using Microsoft.AspNetCore.Authorization;

namespace FastDeliveryBE.Controllers
{
    [Route("api/Delegations")]
    [Authorize]
    [ApiController]
    public class DelegationsController : ControllerBase
    {
        DelegationsService delegationService;
        private readonly ILogger<DepartmentsController> logger;

        public DelegationsController(DelegationsService delegationService, ILogger<DepartmentsController> logger)
        {
            this.delegationService = delegationService;
            this.logger = logger;
        }

        [HttpPost]
        [Route("AddDepartmentsApprovalDelegation")]
        public async Task<IActionResult> AddDepartmentsApprovalDelegation(DepartmentsApprovalDelegationInfo item)
        {
            ActionResponse<bool> result =new Helpers.ActionResponse<bool>();
            try
            {
                await delegationService.AddDepartmentsApprovalDelegation(item);
                result.IsDone = true;
                result.Data = true;
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;


            }
            catch (Exception ex)
            {
                result.IsDone = false;
                result.Data = false;

                if (ex is BusinessException)
                {
                    result.ResultID = 400;
                    logger.LogError(ex.Message + " BusinessException : ", ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString(((BusinessException)ex).Message).ToString();
                }
                else
                {
                    result.ResultID = 500;
                    logger.LogError(ex.Message + " Exception : " + ex.ToString(), ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString("OperationFailed").ToString();
                }
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteDepartmentsApprovalDelegation")]
        public async Task<IActionResult> DeleteDepartmentsApprovalDelegation(DepartmentsApprovalDelegationInfo item)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await delegationService.DeleteDepartmentsApprovalDelegation(item);
                result.IsDone = true;
                result.Data = true;
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;


            }
            catch (Exception ex)
            {
                result.IsDone = false;
                result.Data = false;

                if (ex is BusinessException)
                {
                    result.ResultID = 400;
                    logger.LogError(ex.Message + " BusinessException : ", ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString(((BusinessException)ex).Message).ToString();
                }
                else
                {
                    result.ResultID = 500;
                    logger.LogError(ex.Message + " Exception : " + ex.ToString(), ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString("OperationFailed").ToString();
                }
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteUserApprovalDelegation")]
        public async Task<IActionResult> DeleteUserApprovalDelegation(Guid DelegatedUserId)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await delegationService.DeleteUserApprovalDelegation(DelegatedUserId);
                result.IsDone = true;
                result.Data = true;
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;


            }
            catch (Exception ex)
            {
                result.IsDone = false;
                result.Data = false;

                if (ex is BusinessException)
                {
                    result.ResultID = 400;
                    logger.LogError(ex.Message + " BusinessException : ", ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString(((BusinessException)ex).Message).ToString();
                }
                else
                {
                    result.ResultID = 500;
                    logger.LogError(ex.Message + " Exception : " + ex.ToString(), ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString("OperationFailed").ToString();
                }
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("SearchDepartmentsApprovalDelegations")]
        public async Task<IActionResult> SearchDepartmentsApprovalDelegations
           (SearchDepartmentsApprovalDelegationDTO dto)
        {
            ActionResponse<List<DepartmentsApprovalDelegationInfo>> result =
                new Helpers.ActionResponse<List<DepartmentsApprovalDelegationInfo>>();
            try
            {
                result.Data =await delegationService.SearchDepartmentsApprovalDelegations(dto);
                result.IsDone = true;                
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;


            }
            catch (Exception ex)
            {
                result.IsDone = false;
                result.Data = null;

                if (ex is BusinessException)
                {
                    result.ResultID = 400;
                    logger.LogError(ex.Message + " BusinessException : ", ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString(((BusinessException)ex).Message).ToString();
                }
                else
                {
                    result.ResultID = 500;
                    logger.LogError(ex.Message + " Exception : " + ex.ToString(), ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString("OperationFailed").ToString();
                }
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
