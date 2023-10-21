using FastDeliveryBE.DTOs.Users;
using FastDeliveryBE.Helpers;
using FastDeliveryBE.Services;
using Microsoft.AspNetCore.Authorization;

namespace FastDeliveryBE.Controllers
{
    [Route("api/User")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService UserService;
        private readonly ILogger<DepartmentsController> logger;

        public UserController(UserService UserService
            , ILogger<DepartmentsController> logger)
        {
            this.UserService = UserService;
            this.logger = logger;
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserInfo profile)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await UserService.AddUser(profile);
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
        [Route("GetByUserID")]
        public async Task<IActionResult> GetByUserID(Guid UserID)
        {
            ActionResponse<UserInfo> result = new Helpers.ActionResponse<UserInfo>();
            try
            {

                result.IsDone = true;
                result.Data = await UserService.GetByUserID(UserID);
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
        [Route("ChangeEmployeeDepartment")]
        public async Task<IActionResult> ChangeEmployeeDepartment(Guid userId, int departmentID, int subDepartmentID)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await UserService.ChangeEmployeeDepartment(userId, departmentID, subDepartmentID);
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
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserInfo profile)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await UserService.UpdateUser(profile);
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
        [Route("GetUsersByDepartment")]
        public async Task<IActionResult> GetUsersByDepartment(int? departmentID, int? subDepartmentID)
        {
            ActionResponse<List<UserInfo>> result = new Helpers.ActionResponse<List<UserInfo>>();
            try
            {

                result.IsDone = true;
                result.Data = await UserService.GetUsersByDepartment(departmentID, subDepartmentID);
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
        [Route("SearchUsers")]
        public async Task<IActionResult> SearchUsers(SearchUsersDTO dto)
        {
            ActionResponse<List<UserInfo>> result = new Helpers.ActionResponse<List<UserInfo>>();
            try
            {

                result.IsDone = true;
                result.Data = await UserService.SearchUsers(dto);
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
