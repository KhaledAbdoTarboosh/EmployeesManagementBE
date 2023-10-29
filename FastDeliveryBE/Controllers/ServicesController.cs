using FastDeliveryBE.Application.Departments;
using FastDeliveryBE.DTOs;
using FastDeliveryBE.DTOs.Services;
using FastDeliveryBE.Helpers;
using FastDeliveryBE.Services;
using Microsoft.AspNetCore.Authorization;

namespace FastDeliveryBE.Controllers
{
    [Route("api/Services")]
    [Authorize]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        ServicesService servicesService;
        private readonly ILogger<DepartmentsController> logger;

        public ServicesController(ServicesService servicesService, ILogger<DepartmentsController> logger)
        {
            this.servicesService = servicesService;
            this.logger = logger;
        }


        [HttpGet]
        [Route("GetServices")]
        public async Task<IActionResult> GetServices()
        {
            ActionResponse<List<ServiceInfo>> result = new ActionResponse<List<ServiceInfo>>();

            var data = new List<ServiceInfo>();

            try
            {
                result.IsDone = true;
                data = await servicesService.GetAllServices();
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
    }
}
