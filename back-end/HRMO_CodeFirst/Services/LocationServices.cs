namespace HRMO_CodeFirst.Services
{
    public class LocationServices : ILocationServices
    {
        private readonly IConfiguration _configuration;

        public LocationServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionStringByLocation(string location)
        {
            var sqlDataSource = "";
            if (location == "HCM") sqlDataSource = "Data Source=DESKTOP-RFS50QE\\CLIENT01;Initial Catalog=HRM;Integrated Security=True; User Id=sa; password=Van280898";
            else if (location == "DN") sqlDataSource = "Data Source=DESKTOP-RFS50QE\\CLIENT02;Initial Catalog=HRM;Integrated Security=True; User Id=sa; password=Van280898";
            else sqlDataSource = "Data Source=DESKTOP-RFS50QE\\SERVER;Initial Catalog=HRM;Integrated Security=True; User Id=sa; password=Van280898";

            //else sqlDataSource = "Data Source=HD-PHONGNT\\SERVER;Initial Catalog=HRM;Integrated Security=True; User Id=sa; password=Van280898";
            return sqlDataSource;
        }
    }
}
