namespace HRMO_CodeFirst.Data
{
    public class CreateUserModel
    {
        public string Manv { get; set; }
        public string Mapb { get; set; }
        public string Macv { get; set; }
        public int role {get; set;}
        public string hoTen { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; } = "Orient@123";
        public string imageurl { get; set; }
        public int Trangthai { get; set; }
        public string Email { get; set; }
    }
}
