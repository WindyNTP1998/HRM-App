using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Data.AccountModels;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public interface IAccountService
{
    Task<JsonResult> GetAllAccountAsync();
    Task<bool> CreateAccountAsync(CreateAccountModel model);
    Task<bool> DeleteAccountAsync(DeleteAccountModel model);
    Task<bool> UpdateAccountAsync(UpdateAccountModel model);
    Task<bool> ResetPasswordAsync(ResetPasswordModel model);
    Task<bool> ChangePasswordAsync(ChangePasswordModel model);
}