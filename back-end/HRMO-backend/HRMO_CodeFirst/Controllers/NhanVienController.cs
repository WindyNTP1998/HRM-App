using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HRMO_CodeFirst.Controllers

{
    [Route("api/user/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase

    {
        private readonly IConfiguration _configuration;
        private readonly ILocationServices _locationServies;

        public NhanVienController(IConfiguration configuration, ILocationServices locationServices)
        {
            _configuration = configuration;
            _locationServies = locationServices;
        }


        [HttpGet("GetAll")]
        public async Task<JsonResult> GetAllNhanVien()
        {
            string query = @"SELECT * FROM NHANVIEN";
            DataTable table = new DataTable();

            SqlDataReader myReadder;
            SqlConnection myConn = new SqlConnection(_locationServies.GetConnectionStringByLocation(""));
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myReadder = myCommand.ExecuteReader();
                table.Load(myReadder);
                myReadder.Close();
                myConn.Close();
            }


            return new JsonResult(table);

        }

        [HttpGet("GetByLocation/{location}")]
        public async Task<JsonResult> GetNhanVienByLocation(string location)
        {

            DataTable table = new DataTable();
            string query = @"SELECT * FROM NHANVIEN";
            SqlDataReader myReadder;
            var SqlDataSource = _locationServies.GetConnectionStringByLocation(location);

            try
            {
                SqlConnection myConn = new SqlConnection(SqlDataSource);
                await myConn.OpenAsync();
                SqlCommand myCommand = new SqlCommand(query, myConn);
                myReadder = myCommand.ExecuteReader();
                table.Load(myReadder);
                myReadder.Close();
                myConn.Close();

            }
            catch (SqlException) { }

            return new JsonResult(table);
        }

        // POST Create NHANVIEN
        [HttpPost("CreateNhanVien")]

        public async Task<bool> CreateNhanVien([FromBody] CreateUserModel createUserModel)
        {
            string query = "INSERT INTO NHANVIEN (manv,mapb,macv,hoten,email,trangthai)"
                            + "VALUES (@manv,@mapb,@macv,@hoten,@email,@trangthai)"
                            + "INSERT INTO ACCOUNT VALUES"
                            + "(@userName,@passWord,@manv,@role,@imageurl)";
            var SqlDataSource = _locationServies.GetConnectionStringByLocation("");
            int res = 0;


            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                await myConn.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = createUserModel.Manv;
                    myCommand.Parameters.Add("@mapb", SqlDbType.VarChar).Value = createUserModel.Mapb;
                    myCommand.Parameters.Add("@macv", SqlDbType.VarChar).Value = createUserModel.Macv;
                    myCommand.Parameters.Add("@hoten", SqlDbType.VarChar).Value = createUserModel.hoTen;
                    myCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = createUserModel.Email;
                    myCommand.Parameters.Add("@trangthai", SqlDbType.Int).Value = createUserModel.Trangthai;
                    myCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = createUserModel.userName;
                    myCommand.Parameters.Add("@passWord", SqlDbType.VarChar).Value = createUserModel.passWord;
                    myCommand.Parameters.Add("@role", SqlDbType.Int).Value = createUserModel.role;
                    myCommand.Parameters.Add("@imageurl", SqlDbType.VarChar).Value = createUserModel.imageurl;

                    res = myCommand.ExecuteNonQuery();
                };

            };

            if (res == 0) return false;
            else return true;
        }
    }
}
