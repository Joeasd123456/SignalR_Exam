namespace AspStudio.Variable
{
    public class GVar
    {
        public string conn = "";
        public string Gate_Weight = "";
        public string conn_PreRegis = "";
        public string conn_Customs = "";
        public string kokkak = "";
        public string user_conn = "";
        public string conn_TollGate = "";
        public string apis_conn = "";


        public GVar()
        {
            var configuation = GetConfiguration();
            conn = configuation.GetSection("ConnectionStrings").GetSection("conn").Value;
            Gate_Weight = configuation.GetSection("ConnectionStrings").GetSection("Gate_Weight").Value;
            conn_PreRegis = configuation.GetSection("ConnectionStrings").GetSection("conn_PreRegis").Value;
            kokkak = configuation.GetSection("ConnectionStrings").GetSection("kokkak").Value;
            conn_Customs = configuation.GetSection("ConnectionStrings").GetSection("conn_Customs").Value;
            user_conn = configuation.GetSection("ConnectionStrings").GetSection("user_conn").Value;
            conn_TollGate = configuation.GetSection("ConnectionStrings").GetSection("conn_TollGate").Value;
            apis_conn = configuation.GetSection("ConnectionStrings").GetSection("apis_conn").Value;
        }

        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        //public string conn = "Server=141.164.103.34,4000;Database=Pre-Alert;user id=admin_prealert;pwd=Password%$#@!2024;Trusted_Connection=False;TrustServerCertificate=True;";
        //public string conn = "Server=10.0.200.192;Database=Pre-Alert;user id=sa;pwd=123456;Trusted_Connection=False;TrustServerCertificate=True;";
        //public string user_conn = "Server=141.164.103.34,4000;Database=Security_DB;user id=admin_prealert;pwd=Password%$#@!2024;Trusted_Connection=False;TrustServerCertificate=True;";
        //public string user_conn = "Server=10.0.200.192;Database=Security_DB;user id=sa;pwd=123456;Trusted_Connection=False;TrustServerCertificate=True;";
        //public string conn_Customs = "Server=10.0.200.192;Database=WMS_Customs;user id=sa;pwd=123456;Trusted_Connection=False;";
        //public string conn_TollGate = "Server=10.0.200.74;Database=db_TollGate;user id=tollgate;pwd=30ll$#@2022;Trusted_Connection=False;";
        //public string conn_PreRegis = "Server=10.0.200.192;Database=Pre-Register;user id=sa;pwd=123456;Trusted_Connection=False;TrustServerCertificate=True;";
        //public string apis_conn = "Server=10.0.200.191;Database=APIS;user id=vlpapis;pwd=Password@2021;Trusted_Connection=False;TrustServerCertificate=True;";     
        //public string Gate_Weight = "Server=10.0.200.192;Database=Gate_Weight;user id=sa; pwd=123456;Trusted_Connection=False;TrustServerCertificate=True;";
        //public string kokkak = "Server=10.0.200.83;Database=Kokak_DB;user id =sa; pwd=123456;Trusted_Connection=False;TrustServerCertificate=True;";

    }
}
