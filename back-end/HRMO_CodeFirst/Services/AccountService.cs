using System.Data;
using System.Data.SqlClient;
using HRMO_CodeFirst.Data;
using HRMO_CodeFirst.Data.AccountModels;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public class AccountService:IAccountService
{

    private readonly ILocationServices _locationServies;

    public AccountService( ILocationServices locationServices)
    {
        _locationServies = locationServices;
    }

    public async Task<JsonResult> GetAllAccountAsync()
    {
        string query = "SELECT * FROM ACCOUNT WHERE role != 0";
        var sqlDataSource = _locationServies.GetConnectionStringByLocation("");
        DataTable table = new DataTable();
        SqlDataReader myReadder;
        try
        {
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                await myConn.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReadder = myCommand.ExecuteReader();
                    table.Load(myReadder);
                    myReadder.Close();
                    myConn.Close();
                }
            }
        }
        catch (SqlException) { }
        return new JsonResult(table);
    }

    public async Task<bool> CreateAccountAsync(CreateAccountModel model)
    {
        string query = "INSERT INTO ACCOUNT VALUES (@username,'Orient@123',@manv,@role,@imgurl)";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation("");
        int res = -99;

        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = model.Manv;
                myCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = model.Username;
                myCommand.Parameters.Add("@role", SqlDbType.Int).Value = model.role;
                myCommand.Parameters.Add("@imgurl", SqlDbType.VarChar).Value = model.imgURL;

                res = myCommand.ExecuteNonQuery();
                myConn.Close();
            } ;
        } ;
        if (res == 0) return false;
        else return true;
    }

    public async Task<bool> DeleteAccountAsync(DeleteAccountModel model)
    {
        string query = "DELETE FROM ACCOUNT WHERE manv = @manv";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation(model.Location);
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = model.Manv;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }

        if (res == 1) return true;
        return false;
    }

    public async Task<bool> UpdateAccountAsync(UpdateAccountModel model)
    {
        string query = "UPDATE ACCOUNT SET username = @username, role =@role, imageurl = @imageurl WHERE manv = @manv";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation(model.Location);
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = model.Manv;
                myCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = model.Username;
                myCommand.Parameters.Add("@role", SqlDbType.Int).Value = model.Role;
                myCommand.Parameters.Add("@imageurl", SqlDbType.VarChar).Value = model.ImgUrl;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }

        if (res == 1) return true;
        return false;
    }

    public  async Task<bool> ResetPasswordAsync(ResetPasswordModel model)
    {
        string query = "UPDATE ACCOUNT SET password = 'Orient@123' WHERE manv = @manv";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation(model.Location);
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = model.Manv;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }

        if (res == 1) return true;
        return false;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordModel model)
    {
        string query = "UPDATE ACCOUNT SET password = @password WHERE manv = @manv";
        var SqlDataSource = _locationServies.GetConnectionStringByLocation(model.Location);
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = model.Manv;
                myCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = model.password;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
        if (res == 1) return true;
        return false;
    }
}