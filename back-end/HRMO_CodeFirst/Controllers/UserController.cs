using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Data.UserModels;
using HRMO_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase

{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpGet("GetAll")]
    public async Task<JsonResult> GetAllNhanVien()
    {
        return await _userService.GetAllUserAsync();
    }

  

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] UserModel model)
    {
        var res = await _userService.CreateUserAsync(model);
        if (res) return Ok("CreateUserSuccess");
        return Problem("CreateFaile");
    }
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserModel model)
    {
        var res = await _userService.DeleteUserAsync(model);
        if (res) return Ok("CreateUserSuccess");
        return StatusCode(500);
    }
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UserModel model)
    {
        var res = await _userService.UpdateUserAsync(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }
}