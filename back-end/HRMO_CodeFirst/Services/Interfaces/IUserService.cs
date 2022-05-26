using HRMO_CodeFirst.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public interface IUserService
{
	Task<JsonResult> GetAllUserAsync();
	Task<JsonResult> GetUserByLocationAsync(string location);
	Task<bool> CreateAccountAsync([FromBody] CreateAccountModel model);

	Task<bool> CreateUserAsync([FromBody] CreateUserModel model);
}