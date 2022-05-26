using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeSheetsController : ControllerBase
{
    private readonly ITimeSheetsService _timeSheets;

    public TimeSheetsController(ITimeSheetsService timeSheets )
    {
        _timeSheets = timeSheets;
    }
    // GET
    [HttpGet("GetTimeSheets")]
    public async Task<JsonResult> GetTimeSheets(string? manv)
    {
        return await _timeSheets.ViewTimeSheet(manv);
    }

    [HttpPost("CreateTimeSheet")]
    public async Task<IActionResult> CreateTimeSheet(TimeSheetsModel model)
    {
        var res = await _timeSheets.CreateTimeSheet(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

    [HttpPut("UpdateTimeSheet")]
    public async Task<IActionResult> UpdateTimeSheet(TimeSheetUpdateModel model)
    {
        var res = await _timeSheets.UpdateTimeSheet(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

    [HttpDelete("DeleteTimeSheet")]
    public async Task<IActionResult> DeleteTimeSheet(IdAndLocationModel model)
    {
        var res = await _timeSheets.DeleteTimeSheet(model);
        if (res) return StatusCode(200);
        return StatusCode(400);
    }

}