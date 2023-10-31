using EmployeesManagementBE.DTOs.Employees;
using EmployeesManagementBE.Helpers;
using EmployeesManagementBE.Services;
using FastDeliveryBE.DTOs.Employees;
using Microsoft.AspNetCore.Authorization;

namespace EmployeesManagementBE.Controllers
{
    [Route("api/Employees")]
    [Authorize]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        EmployeeService employeeService;
        private readonly ILogger<EmployeesController> logger;

        public EmployeesController(EmployeeService employeeService
            , ILogger<EmployeesController> logger)
        {
            this.employeeService = employeeService;
            this.logger = logger;
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeInfo profile)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await employeeService.AddEmployee(profile);
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
        [Route("GetByEmployeeID")]
        public async Task<IActionResult> GetByEmployeeID(int EmployeeID)
        {
            ActionResponse<EmployeeInfo> result = new Helpers.ActionResponse<EmployeeInfo>();
            try
            {

                result.IsDone = true;
                result.Data = await employeeService.GetByEmployeeID(EmployeeID);
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


        [HttpPost]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeInfo profile)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                employeeService.UpdateEmployee(profile);
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
        [Route("SearchEmployees")]
        public async Task<IActionResult> SearchEmployees(SearchEmployeesDTO dto)
        {
            ActionResponse<List<EmployeeInfo>> result = new Helpers.ActionResponse<List<EmployeeInfo>>();
            try
            {

                result.IsDone = true;
                result.Data = await employeeService.SearchEmployees(dto);
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
