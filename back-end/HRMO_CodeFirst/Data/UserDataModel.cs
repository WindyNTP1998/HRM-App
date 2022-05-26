namespace HRMO_CodeFirst.Data;

public class UserDataModel
{

	public string Manv { get; set; }
	public string Mapb { get; set; } = null!;
	public string Macv { get; set; } = null!;
	public string Hoten { get; set; } = null!;
	public DateTime? Ngaysinh { get; set; }
	public int? Gioitinh { get; set; }
	public string? Cmnd { get; set; }
	public string? Diachi { get; set; }
	public string? Dienthoai { get; set; }
	public string? Hocvan { get; set; }
	public int Trangthai { get; set; }
	public string Email { get; set; } = null!;
	public string? Sobhxh { get; set; }
	public string? Sobhyt { get; set; }
}