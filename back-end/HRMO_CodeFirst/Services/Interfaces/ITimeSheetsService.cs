using HRMO_CodeFirst.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public interface ITimeSheetsService
{
    Task<JsonResult> ViewTimeSheet(string? id = "");
    Task<bool> CreateTimeSheet(TimeSheetsModel model);
    Task<bool> DeleteTimeSheet(IdAndLocationModel model);
    Task<bool> UpdateTimeSheet(TimeSheetUpdateModel model);
}