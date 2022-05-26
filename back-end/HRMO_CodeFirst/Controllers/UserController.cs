using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HRMO_CodeFirst.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {

        //private readonly ILocationServices _locationServies;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {

            _userService = userService;
        }


        [HttpGet("GetAll")]
        public  Task<JsonResult> GetAllNhanVien()
        {
            // string query = @"SELECT  NHANVIEN.manv ,NHANVIEN.mapb ,NHANVIEN.macv ,NHANVIEN.hoten ,
            //                            NHANVIEN.ngaysinh ,NHANVIEN.gioitinh ,NHANVIEN.cmnd ,NHANVIEN.diachi ,NHANVIEN.dienthoai ,
            //                            NHANVIEN.hocvan ,NHANVIEN.trangthai ,NHANVIEN.email ,NHANVIEN.sobhxh ,NHANVIEN.sobhyt ,ACCOUNT.username ,
            //                            ACCOUNT.role ,VANPHONG.mavp
            //                             FROM [HRM].[dbo].[NHANVIEN]
            //                             JOIN ACCOUNT ON NHANVIEN.manv = ACCOUNT.manv
            //                             JOIN PHONGBAN ON NHANVIEN.mapb = PHONGBAN.mapb
            //                             JOIN VANPHONG ON PHONGBAN.mavp = VANPHONG.mavp";
            // DataTable table = new DataTable();
            //
            // SqlDataReader myReadder;
            // SqlConnection myConn = new SqlConnection(_locationServies.GetConnectionStringByLocation(""));
            // await myConn.OpenAsync();
            // using (SqlCommand myCommand = new SqlCommand(query, myConn))
            // {
            //     myReadder = myCommand.ExecuteReader();
            //     table.Load(myReadder);
            //     myReadder.Close();
            //     myConn.Close();
            // }
            //
            //
            // return new JsonResult(table);
            return  _userService.GetAllUserAsync();

        }

        [HttpGet("GetByLocation/{location}")]
        public async Task<JsonResult> GetNhanVienByLocation(string location)
        {

            // DataTable table = new DataTable();
            // string query = @"SELECT * FROM NHANVIEN";
            // SqlDataReader myReadder;
            // var SqlDataSource = _locationServies.GetConnectionStringByLocation(location);
            //
            // try
            // {
            //     SqlConnection myConn = new SqlConnection(SqlDataSource);
            //     await myConn.OpenAsync();
            //     SqlCommand myCommand = new SqlCommand(query, myConn);
            //     myReadder = myCommand.ExecuteReader();
            //     table.Load(myReadder);
            //     myReadder.Close();
            //     myConn.Close();
            //
            // }
            // catch (SqlException) { }
            //
            // return new JsonResult(table);
            return await _userService.GetUserByLocationAsync(location);
        }

        // POST Create NHANVIEN
        [HttpPost("CreateAccount")]

        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountModel model)
        {
            var res = await _userService.CreateAccountAsync(model);
            if (res) return Ok("CreateUserSuccess");
            return Problem("CreateFaile");
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model)
        {
            var res = await _userService.CreateUserAsync(model);
            if (res) return Ok("CreateUserSuccess");
            return Problem("CreateFaile");
        }
    }
}