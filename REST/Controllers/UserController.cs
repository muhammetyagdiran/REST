using Microsoft.AspNetCore.Mvc;
using REST.Business.Interface;
using REST.Business.ResponseModel;
using REST.Core.Extensions;
using REST.Entities;
using REST.Entities.DTOs.User;


namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpGet]
        public IList<User> Get()
        {
            _logger.LogInformation("Get method is called");  //Loglama örneði
            return _userService.GetUsersAll();
        }
        [HttpPost]
        [Route("Add")]
        public BaseResponse<User> Add(UserAddRequestDTO userAddRequestDTO)
        {
            _logger.LogInformation("Post method is called");  //Loglama örneði
            userAddRequestDTO.FirstName = userAddRequestDTO.FirstName.FirstCharToUpper();
            userAddRequestDTO.LastName = userAddRequestDTO.LastName.FirstCharToUpper();     //Kendi yazdýðým FirstCharToUpper extension ile ad ve soyadýn baþ harflerini büyüttüm
            return _userService.Add(userAddRequestDTO);
        }
        [HttpPut]
        [Route("Update")]
        public BaseResponse<User> Update(UserAddRequestDTO userAddRequestDTO)
        {
            _logger.LogInformation("Put method is called");  //Loglama örneði
            return _userService.Update(userAddRequestDTO);
        }
        [HttpDelete]
        [Route("Delete/{UserId}")]
        public BaseResponse Delete(int UserId)
        {
            _logger.LogInformation("Delete method is called");  //Loglama örneði
            return _userService.Delete(UserId);
        }
        [HttpPatch]
        [Route("Patch")]
        public BaseResponse Patch(int UserId)
        {
            return null;
        }
    }
}