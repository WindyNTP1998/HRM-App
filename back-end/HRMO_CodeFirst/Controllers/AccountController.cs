using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Data.AccountModels;
using HRMO_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller
{

    private readonly IAccountService _accountService;
    public AccountController(IAccountService service)
    {
        _accountService = service;
    }
    // GET
    [HttpGet("GetAllAccount")]
    public async Task<JsonResult> GetAccount()
    {
        return await _accountService.GetAllAccountAsync();
    }

    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreateAccount([FromBody]CreateAccountModel model)
    {
        var res = await _accountService.CreateAccountAsync(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

    [HttpDelete("DeleteAccout")]
    public async Task<IActionResult> DeleteAccount([FromBody] DeleteAccountModel model)
    {
        var res = await _accountService.DeleteAccountAsync(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

    [HttpPut("UpdateAccount")]
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountModel model)
    {
        var res = await _accountService.UpdateAccountAsync(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

    [HttpPut("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
    {
        var res = await _accountService.ResetPasswordAsync(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
    {
        var res = await _accountService.ChangePasswordAsync(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }
}