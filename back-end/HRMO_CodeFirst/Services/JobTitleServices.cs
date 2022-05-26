using System.Data;
using System.Data.SqlClient;
using HRMO_CodeFirst.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public class JobTitleServices:IJobTitleServices
{
    private readonly ILocationServices _locationServies;


    public JobTitleServices( ILocationServices locationServices)
    {
        _locationServies = locationServices;
    }                                     

    public async Task<JsonResult> ViewJobTitle()
    {
        string query = "SELECT * FROM CHUCVU";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation("");
        
        SqlDataReader myReadder;
        DataTable table = new DataTable();

        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myReadder = myCommand.ExecuteReader();
                table.Load(myReadder);
                myReadder.Close();
                myConn.Close();
            }
            myConn.Close();
        }
        return new JsonResult(table);
    }

    public async Task<bool> CreateJobTitle(JobTitleModel model)
    {
        string query = "INSERT INTO CHUCVU VALUES (@macv,@tencv)";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation("");
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@macv", SqlDbType.VarChar).Value = model.MaCV;
                myCommand.Parameters.Add("@tencv", SqlDbType.VarChar).Value = model.TenCV;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
        if (res == 1) return true;
        return false;
    }

    public async Task<bool> UpdateJobTitle(JobTitleModel model)
    {
        string query = "UPDATE CHUCVU SET macv=@macv,tencv=@tencv WHERE macv=@macv";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation("");
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@macv", SqlDbType.VarChar).Value = model.MaCV;
                myCommand.Parameters.Add("@tencv", SqlDbType.VarChar).Value = model.TenCV;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
        if (res == 1) return true;
        return false;
    }

    public async Task<bool> DeleteJobTitle(string macv)
    {
        string query = "DELETE FROM CHUCVU WHERE macv=@macv";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation("");
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@macv", SqlDbType.VarChar).Value = macv;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
        if (res == 1) return true;
        return false;
    }
}