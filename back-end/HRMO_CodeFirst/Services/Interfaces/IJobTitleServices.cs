using HRMO_CodeFirst.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public interface IJobTitleServices
{
    Task<JsonResult> ViewJobTitle();
    Task<bool> CreateJobTitle(JobTitleModel model);
    Task<bool> UpdateJobTitle(JobTitleModel model);
    Task<bool> DeleteJobTitle(string macv);
}