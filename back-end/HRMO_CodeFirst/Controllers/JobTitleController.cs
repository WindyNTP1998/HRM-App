using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobTitleController : Controller
{
    private readonly IJobTitleServices _jobTitleServices;

    public JobTitleController(IJobTitleServices _job)
    {
        _jobTitleServices = _job;
    }
    // GET
    [HttpGet("GetJobTitle")]
    public async Task<JsonResult> GetJobTitle()
    {
        return await _jobTitleServices.ViewJobTitle();
    }

    [HttpPost("CreateJobTitle")]
    public async Task<IActionResult> CreateJobTitle(JobTitleModel model)
    {
        var res = await _jobTitleServices.CreateJobTitle(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

    [HttpPut("UpdateJobTitle")]
    public async Task<IActionResult> UpdateJobTitle(JobTitleModel model)
    {
        var res = await _jobTitleServices.UpdateJobTitle(model);
        if (res) return StatusCode(200);
        return StatusCode(400);;
    }
    [HttpDelete("DeleteJobTitle/{id}")]
    public async Task<IActionResult> DeleteJobTitle(string id)
    {
        var res = await _jobTitleServices.DeleteJobTitle(id);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }
}