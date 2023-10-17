using Microsoft.AspNetCore.Mvc;
using REST.Business.Interface;
using REST.Business.ResponseModel;
using REST.Entities;
using REST.Entities.DTOs.User;

namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IList<User> Get()
        {
            return _userService.GetUsersAll();
        }
        [HttpPost]
        [Route("Add")]
        public BaseResponse<User> Add(UserAddRequestDTO userAddRequestDTO)
        {
            return _userService.Add(userAddRequestDTO);
        }
        [HttpPut]
        [Route("Update")]
        public BaseResponse<User> Update(UserAddRequestDTO userAddRequestDTO)
        {
            return _userService.Update(userAddRequestDTO);
        }
        [HttpDelete]
        [Route("Delete/{UserId}")]
        public BaseResponse Delete(int UserId)
        {
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