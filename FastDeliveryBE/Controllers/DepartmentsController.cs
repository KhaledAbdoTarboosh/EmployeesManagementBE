using Microsoft.AspNetCore.Authorization;
using FastDeliveryBE.DTOs;
using FastDeliveryBE.Application.Departments;
using FastDeliveryBE.Helpers;



namespace FastDeliveryBE.Controllers
{
    [Route("api/Departments")]
    //[Authorize]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        DepartmentsService departmentService;
        private readonly ILogger<DepartmentsController> logger;

        public DepartmentsController(DepartmentsService departmentService, ILogger<DepartmentsController> logger)
        {
            this.departmentService = departmentService;
            this.logger = logger;


        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentInfo department)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await departmentService.AddDepartment(department);
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
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(DepartmentInfo department)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await departmentService.UpdateDepartment(department);

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

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int departmentID)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                await departmentService.DeleteDepartment(departmentID);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [Route("GetDepartmentByID")]       
        public async Task<IActionResult> GetDepartmentByID(int id)
        {
            ActionResponse<DepartmentInfo> result = new Helpers.ActionResponse<DepartmentInfo>();
            try
            {

                var claims = HttpContext.User.Claims;

                result.IsDone = true;
                result.Data =await departmentService.GetDepartmentByID(id);
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
                result.ResultID = 200;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsDone = false;
                result.Data = new DepartmentInfo();
                if (ex is BusinessException)
                {
                    result.ResultID = 400;
                    logger.LogError(ex.Message + " BusinessException : ", ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString(((BusinessException)ex).Message);
                }
                else
                {
                    result.ResultID = 500;
                    logger.LogError(ex.Message + " Exception : " + ex.ToString(), ex);
                    result.ResultMessage = ErrorMessages.ResourceManager.GetString("OperationFailed");
                }
                return BadRequest(result);
            }

        }


        [HttpGet]
        [Route("GetDepartmentsTree")]
        public async Task<IActionResult> GetDepartmentsTree(int parentDepartmentID)
        {
            ActionResponse<List<DepartmentInfo>> result = new ActionResponse<List<DepartmentInfo>>();
            List<Department> departments = new List<Department>();
            var data = new List<DepartmentInfo>();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetDepartmentsTree(departments, parentDepartmentID);
                result.Data = data;
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
        [Route("GetDepartmentParents")]
        public async Task<IActionResult> GetDepartmentParents(int departmentID)
        {
            ActionResponse<List<DepartmentInfo>> result = new ActionResponse<List<DepartmentInfo>>();
            List<Department> departments = new List<Department>();
            var data = new List<DepartmentInfo>();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetDepartmentParents(departments, departmentID);
                result.Data = data;
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
        [Route("GetChildDepartmentEmployeesCount")]
        public async Task<IActionResult> GetChildDepartmentEmployeesCount(int departmentID)
        {
            ActionResponse<List<DepartmentEmployeesCountInfo>> result =
                new ActionResponse<List<DepartmentEmployeesCountInfo>>();

            var data = new List<DepartmentEmployeesCountInfo>();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetChildDepartmentEmployeesCount(departmentID);
                result.Data = data;
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
        [Route("GetDepartmentsByIds")]
        public async Task<IActionResult> GetDepartmentsByIds(List<int> depIDs)
        {
            ActionResponse<List<DepartmentInfo>> result = new ActionResponse<List<DepartmentInfo>>();
            List<Department> departments = new List<Department>();
            var data = new List<DepartmentInfo>();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetDepartmentsByIds(depIDs);
                result.Data = data;
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
        [Route("GetDepartmentsManagrsUserIDsByDepartmentsIDs")]
        public async Task<IActionResult> GetDepartmentsManagrsUserIDsByDepartmentsIDs(List<int> depIDs)
        {
            ActionResponse<List<DepartmentManagerInfo>> result = new ActionResponse<List<DepartmentManagerInfo>>();
            var data = new List<DepartmentManagerInfo>();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetDepartmentsManagrsUserIDsByDepartmentsIDs(depIDs);
                result.Data = data;
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
        [Route("GetOSDepartments")]
        public async Task<IActionResult> GetOSDepartments()
        {
            ActionResponse<List<DepartmentInfo>> result = new ActionResponse<List<DepartmentInfo>>();

            var data = new List<DepartmentInfo>();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetOSDepartments();
                result.Data = data;                
                result.ResultMessage =  ErrorMessages.ResourceManager.GetString("DataSelected").ToString();
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
        [Route("GetDepartmentsByTypeIds")]
        public async Task<IActionResult> GetDepartmentsByTypeIds(List<int> depTypesIds)
        {
            ActionResponse<List<DepartmentInfo>> result = new ActionResponse<List<DepartmentInfo>>();
            var data = new List<DepartmentInfo>();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetDepartmentsByTypeIds(depTypesIds);
                result.Data = data;
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
        [Route("GetDepartmentType")]
        public async Task<IActionResult> GetDepartmentType(int departmentID)
        {
            ActionResponse<DepartmentTypeInfo> result = new ActionResponse<DepartmentTypeInfo>();
            var data = new DepartmentTypeInfo();

            try
            {
                result.IsDone = true;
                data = await departmentService.GetDepartmentType(departmentID);
                result.Data = data;
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


        [HttpDelete]
        [Route("SetDepartmentManager")]
        public IActionResult SetDepartmentManager(int departmentID, Guid userID)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                departmentService.SetDepartmentManager(departmentID, userID);
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

    }
}
