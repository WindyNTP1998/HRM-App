using System.Data;
using System.Data.SqlClient;
using HRMO_CodeFirst.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public class TimeSheetsService:ITimeSheetsService
{
    private readonly ILocationServices _location;

    public TimeSheetsService(ILocationServices location)
    {
        _location = location;
    }

    public async Task<JsonResult> ViewTimeSheet(string? manv)
    {
        var SqlDataSource = _location.GetConnectionStringByLocation("");
        SqlDataReader myReadder;
        DataTable table = new DataTable();
        string query = "";
        
        //string query = "SELECT * FROM CONG WHERE manv = @manv";
        if (manv == null)
        {
            query = "SELECT * FROM CONG";
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
        }
        else
        {
            query = "SELECT * FROM CONG WHERE manv = @manv";
            using (SqlConnection myConn = new SqlConnection(SqlDataSource))
            {
                await myConn.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
                    myReadder = myCommand.ExecuteReader();
                    table.Load(myReadder);
                    myReadder.Close();
                    myConn.Close();
                }
                myConn.Close();
            }
        }
        
        return new JsonResult(table);
    }

    public async Task<bool> CreateTimeSheet(TimeSheetsModel model)
    {
        string query = "INSERT INTO CONG VALUES (@manv, @giocongchuan, @giocong, @thang, @nam)";
        var SqlDataSource = _location.GetConnectionStringByLocation(model.Location);
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = model.Manv;
                myCommand.Parameters.Add("@giocongchuan", SqlDbType.Int).Value = model.GioCongChuan;
                myCommand.Parameters.Add("@giocong", SqlDbType.Int).Value = model.GioCong;
                myCommand.Parameters.Add("@thang", SqlDbType.Int).Value = model.Thang;
                myCommand.Parameters.Add("@nam", SqlDbType.Int).Value = model.Nam;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
        if (res == 1) return true;
        return false;
    }

    public async Task<bool> DeleteTimeSheet(IdAndLocationModel model)
    {
        string query = "DELETE FROM CONG WHERE macong = @macong";
        var SqlDataSource = _location.GetConnectionStringByLocation(model.Location);
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@macong", SqlDbType.Int).Value = Int32.Parse(model.Id);
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
        if (res == 1) return true;
        return false;
    }

    public async Task<bool> UpdateTimeSheet(TimeSheetUpdateModel model)
    {
        string query = "UPDATE CONG SET giocongchuan = @giocongchuan, giocong=@giocong, thang=@thang, nam=@nam WHERE macong= @macong";
        var SqlDataSource = _location.GetConnectionStringByLocation(model.Location);
        int res = -99;
        using (SqlConnection myConn = new SqlConnection(SqlDataSource))
        {
            await myConn.OpenAsync();
            using (SqlCommand myCommand = new SqlCommand(query, myConn))
            {
                myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = model.Manv;
                myCommand.Parameters.Add("@giocongchuan", SqlDbType.Int).Value = model.GioCongChuan;
                myCommand.Parameters.Add("@giocong", SqlDbType.Int).Value = model.GioCong;
                myCommand.Parameters.Add("@thang", SqlDbType.Int).Value = model.Thang;
                myCommand.Parameters.Add("@nam", SqlDbType.Int).Value = model.Nam;
                myCommand.Parameters.Add("@macong", SqlDbType.Int).Value = model.MaCong;
                res = myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
        if (res == 1) return true;
        return false;
    }
}