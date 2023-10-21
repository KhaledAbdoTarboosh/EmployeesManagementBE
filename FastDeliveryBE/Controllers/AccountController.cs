using FastDeliveryBE.Helpers;
using FastDeliveryBE.Repositories.JWTTokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FastDeliveryBE.Controllers
{
    [Route("api/Account")]
    [Authorize]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly ITokenRepository tokenRepo;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<AccountController> logger,
        ITokenRepository tokenRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.tokenRepo = tokenRepo;
        }

        

        [HttpPost]
        [Route("AddPassword")]
        public async Task<IActionResult> AddPassword(string userName, string NewPassword)
        {
            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                var user = await userManager.FindByNameAsync(userName);

                var res = await userManager.AddPasswordAsync(user, NewPassword);

                if (res.Succeeded)
                {
                    result.IsDone = true;
                    result.Data = true;
                }
                else
                {
                    result.IsDone = false;
                    result.Data = false;
                }
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("PasswordSet").ToString();
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
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string userName,string CurrentPassword, string NewPassword)
        {  

            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
                var user = await userManager.FindByNameAsync(userName);

                var res = await userManager.ChangePasswordAsync(user,
                    CurrentPassword, NewPassword);

                if (res.Succeeded)
                {
                    result.IsDone = true;
                    result.Data = true;
                }
                else
                {
                    result.IsDone = false;
                    result.Data = false;
                }
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("PasswordSet").ToString();
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
        [Route("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string email, string token, string NewPassword)
        {
            



            ActionResponse<bool> result = new Helpers.ActionResponse<bool>();
            try
            {
             

                var user = await userManager.FindByEmailAsync(email);

                if (user != null)
                {
                    var res = await userManager.ResetPasswordAsync(user, token, NewPassword);


                    if (res.Succeeded)
                    {
                        if (await userManager.IsLockedOutAsync(user))
                        {
                            await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                        }

                        result.IsDone = true;
                        result.Data = true;
                    }
                    else
                    {
                        result.IsDone = false;
                        result.Data = false;
                    }
                    
                }
                    
                result.ResultMessage = ErrorMessages.ResourceManager.GetString("PasswordSet").ToString();
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
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

       

        [AcceptVerbs("Get", "Post")]
        [Route("IsEmailInUse")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string userName,string email  ,string password)
        {

            IdentityUser user = new IdentityUser();
            user.Email = email;
            user.UserName = userName;
            ActionResponse<string> result = new Helpers.ActionResponse<string>();
            try
            {


                

                if (user != null)
                {
                    var res = await userManager.CreateAsync(user, password);


                    if (res.Succeeded)
                    {
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                        var confirmationLink = Url.Action("ConfirmEmail", "Account",
                                                new { userId = user.Id, token = token }, Request.Scheme);

                        result.IsDone = true;
                        result.Data = token;
                    }
                    else
                    {
                        result.IsDone = false;
                        result.Data = "";
                    }

                }

                result.ResultMessage = ErrorMessages.ResourceManager.GetString("UserRegistered").ToString();
                result.ResultID = 200;
                return Ok(result);


            }
            catch (Exception ex)
            {
                result.IsDone = false;
                result.Data = "";
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
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email,string password)
        {
            

            ActionResponse<string> result = new Helpers.ActionResponse<string>();
            try
            {


                var user = await userManager.FindByEmailAsync(email);

                if (user != null)
                {
                    var checkPasswordResult =await userManager.CheckPasswordAsync(user, password);
                    if (!(user.EmailConfirmed && checkPasswordResult))
                    {
                        result.ResultID = 400;
                        result.IsDone = false;
                        result.Data = "";
                        result.ResultMessage = ErrorMessages.ResourceManager.GetString("WrongUserOrPassword").ToString();
                        return BadRequest(result);
                    }

                   //var res= await signInManager.PasswordSignInAsync(user.UserName, password, true, true);


                    //if (res.Succeeded)
                    //{

                    if (checkPasswordResult)
                    {
                        result.IsDone = true;
                        result.Data = tokenRepo.CreateJWTToken(user, new List<string>());
                        result.ResultMessage = ErrorMessages.ResourceManager.GetString("LogedIn").ToString();
                        result.ResultID = 200;
                        return Ok(result);
                    }
                       
                    //}
                    //else
                    //{
                    //    result.IsDone = false;
                    //    result.Data = "";
                    //}         

                }
                return BadRequest(result);



            }
            catch (Exception ex)
            {
                result.IsDone = false;
                result.Data = "";
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