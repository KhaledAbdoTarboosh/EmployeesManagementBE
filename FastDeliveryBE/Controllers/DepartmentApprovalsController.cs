using Microsoft.AspNetCore.Authorization;
using FastDeliveryBE.DTOs.DepartmentApprovals;
using FastDeliveryBE.Services;
using FastDeliveryBE.Helpers;
using System.Collections;

namespace FastDeliveryBE.Controllers
{
    [Route("api/DepartmentApprovals")]
    [Authorize]
    [ApiController]
    public class DepartmentApprovalsController : ControllerBase
    {
        DepartmentApprovalsService departmentApprovalsService;
        private readonly ILogger<DepartmentsController> logger;

        public DepartmentApprovalsController(DepartmentApprovalsService departmentApprovalsService, ILogger<DepartmentsController> logger)
        {
            this.departmentApprovalsService = departmentApprovalsService;
            this.logger = logger;
        }


        [HttpPost]
        [Route("AddDepartmentApprovalLevel")]
        public async Task<IActionResult> AddDepartmentApprovalLevel(DepartmentsApprovalLevelInfo item)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await departmentApprovalsService.AddDepartmentApprovalLevel(item);
                result.IsDone = true;
                result.Data = true;
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;
                return Ok(result);
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
        }

        [HttpPost]
        [Route("DeleteDepartmentApprovalLevel")]
        public async Task<IActionResult> DeleteDepartmentApprovalLevel(DepartmentsApprovalLevelInfo item)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await departmentApprovalsService.DeleteDepartmentApprovalLevel(item);
                result.IsDone = true;
                result.Data = true;
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;
                return Ok(result);
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
        }

        [HttpPost]
        [Route("UpdateDepartmentApprovalLevel")]
        public async Task<IActionResult> UpdateDepartmentApprovalLevel(DepartmentsApprovalLevelInfo item)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await departmentApprovalsService.UpdateDepartmentApprovalLevel(item);
                result.IsDone = true;
                result.Data = true;
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;
                return Ok(result);
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
        }

        [HttpGet]
        [Route("GetDepartmentManagerAndHisDelegates")]
        public async Task<IActionResult>  GetDepartmentManagerAndHisDelegates(Guid? operationID, int departmentID)
        {
            ActionResponse<ArrayList> result = new Helpers.ActionResponse<ArrayList>();
            try
            {

                result.IsDone = true;
                result.Data = await departmentApprovalsService.GetDepartmentManagerAndHisDelegates(operationID, departmentID);
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;
                return Ok(result);
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
        }

        [HttpGet]
        [Route("GetDepartmentsApprovalLevelsGetAll")]
        public async Task<IActionResult> GetDepartmentsApprovalLevelsGetAll(SearchDeprtmentApprovalDTO dto)
        {
            ActionResponse<List< DepartmentsApprovalLevelInfo>> result =
                new Helpers.ActionResponse<List<DepartmentsApprovalLevelInfo>>();
            try
            {

                result.IsDone = true;
                result.Data = await departmentApprovalsService.GetDepartmentsApprovalLevelsGetAll(dto);
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;
                return Ok(result);
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


        }


    }
}
