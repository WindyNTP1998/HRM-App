using HRMO_CodeFirst.Data;

using HRMO_CodeFirst.Data.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public interface IUserService
{
	Task<JsonResult> GetAllUserAsync();
	Task<JsonResult> GetUserByLocationAsync(string location);


	Task<bool> CreateUserAsync([FromBody] UserModel model);

	Task<bool> DeleteUserAsync([FromBody] DeleteUserModel model);

	Task<bool> UpdateUserAsync([FromBody] UserModel model);

	
}