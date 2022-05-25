using System.Data;
using HRMO_CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;
using HRMO_CodeFirst.Data;

namespace HRMO_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILocationServices _locationServies;

        public LoginController(IConfiguration configuration, ILocationServices locationServices)
        {
            _configuration = configuration;
            _locationServies = locationServices;
        }

        [HttpPost]
        public async Task<IActionResult> GetLoginAdmin([FromBody] LoginModel loginData)
        {
            string query = "SELECT username, role, manv, imageurl"
                            + " FROM ACCOUNT"
                            + " WHERE  username = @userName AND  password = @passWord";

            DataTable table = new DataTable();

            SqlDataReader myReadder;

            SqlConnection myConn = new SqlConnection(_locationServies.GetConnectionStringByLocation(""));

            await myConn.OpenAsync();

            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = loginData.username;
                myCommand.Parameters.Add("@passWord", SqlDbType.VarChar).Value = loginData.password;

                myReadder = myCommand.ExecuteReader();
                string sqlQuery = query;
                table.Load(myReadder);
                myReadder.Close();
                myConn.Close();
            }

            if (table.Rows.Count > 0)
                return new JsonResult(table);
            return NotFound();
        }
    }
}