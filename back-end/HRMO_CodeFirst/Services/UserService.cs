using System.Data;
using System.Data.SqlClient;
using HRMO_CodeFirst.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRMO_CodeFirst.Services;

public class UserService : IUserService
{

	private readonly ILocationServices _locationServies;

	public UserService( ILocationServices locationServices)
	{
		_locationServies = locationServices;
	}


	public async Task<JsonResult> GetAllUserAsync()
	{
		string query = @"SELECT  NHANVIEN.manv ,NHANVIEN.mapb ,NHANVIEN.macv ,NHANVIEN.hoten ,
                                       NHANVIEN.ngaysinh ,NHANVIEN.gioitinh ,NHANVIEN.cmnd ,NHANVIEN.diachi ,NHANVIEN.dienthoai ,
                                       NHANVIEN.hocvan ,NHANVIEN.trangthai ,NHANVIEN.email ,NHANVIEN.sobhxh ,NHANVIEN.sobhyt ,ACCOUNT.username ,
                                       ACCOUNT.role ,VANPHONG.mavp 
                                        FROM NHANVIEN
                                        JOIN ACCOUNT ON NHANVIEN.manv = ACCOUNT.manv 
                                        JOIN PHONGBAN ON NHANVIEN.mapb = PHONGBAN.mapb 
                                        JOIN VANPHONG ON PHONGBAN.mavp = VANPHONG.mavp";
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
	public async Task<JsonResult> GetUserByLocationAsync(string location)
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

	public async Task<bool> CreateUserAsync([FromBody] CreateUserModel createUserModel)
	{
		string query = "INSERT INTO NHANVIEN VALUES (@manv,@mapb,@macv,@hoten,@ngaysinh,@gioitinh,@cmnd,@diachi,@dienthoai,@hocvan,@trangthai,@email,@sobhxh,@sobhyt)";
		var SqlDataSource = _locationServies.GetConnectionStringByLocation("");

		int res = -99;

		using (SqlConnection myConn = new SqlConnection(SqlDataSource))
		{
		    await myConn.OpenAsync();
		    using (SqlCommand myCommand = new SqlCommand(query, myConn))
		    {
		        myCommand.Parameters.Add("@manv", SqlDbType.VarChar).Value = createUserModel.Manv;
		        myCommand.Parameters.Add("@mapb", SqlDbType.VarChar).Value = createUserModel.Mapb;
		        myCommand.Parameters.Add("@macv", SqlDbType.VarChar).Value = createUserModel.Macv;
		        myCommand.Parameters.Add("@hoten", SqlDbType.VarChar).Value = createUserModel.Hoten;
		        myCommand.Parameters.Add("@ngaysinh", SqlDbType.VarChar).Value = createUserModel.Ngaysinh;
		        myCommand.Parameters.Add("@gioitinh", SqlDbType.Int).Value = createUserModel.Gioitinh;
		        myCommand.Parameters.Add("@cmnd", SqlDbType.VarChar).Value = createUserModel.Cmnd;
		        myCommand.Parameters.Add("@diachi", SqlDbType.VarChar).Value = createUserModel.Diachi;
		        myCommand.Parameters.Add("@dienthoai", SqlDbType.VarChar).Value = createUserModel.Dienthoai;
		        myCommand.Parameters.Add("@hocvan", SqlDbType.VarChar).Value = createUserModel.Hocvan;
		        myCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = createUserModel.Email;
		        myCommand.Parameters.Add("@trangthai", SqlDbType.Int).Value = createUserModel.Trangthai;
		        myCommand.Parameters.Add("@sobhxh", SqlDbType.VarChar).Value = createUserModel.Sobhxh;
		        myCommand.Parameters.Add("@sobhyt", SqlDbType.VarChar).Value = createUserModel.Sobhyt;

		        res = myCommand.ExecuteNonQuery();
		    };
		    myConn.Close();
		};

		if (res == 0) return false;
		else return true;
	}
}