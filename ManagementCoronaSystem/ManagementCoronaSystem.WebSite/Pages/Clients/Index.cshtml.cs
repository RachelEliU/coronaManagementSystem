using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection;

namespace ManagementCoronaSystem.WebSite.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfor> listClients = new List<ClientInfor>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Clients;Integrated Security=True";
                using(SqlConnection connection = new SqlConnection(connectionString)) 
                { 
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                ClientInfor clientInfor = new ClientInfor();
                                clientInfor.id = reader.GetString(0);
                                clientInfor.firstName = reader.GetString(1);    
                                clientInfor.lastName = reader.GetString(2);
                                clientInfor.address = reader.GetString(3);
                                clientInfor.phoneNumber = reader.GetString(4);
                                clientInfor.cellPhoneNumber = reader.GetString(5);
                                clientInfor.email = reader.GetString(6);
                                clientInfor.birthDate = reader.GetDateTime(7).ToString().Substring(0,10);
                                clientInfor.firstShot = reader.GetDateTime(8).ToString().Substring(0, 10);
                                clientInfor.secondShot  = reader.GetDateTime(9).ToString().Substring(0, 10);    
                                clientInfor.thirdShot = reader.GetDateTime(10).ToString().Substring(0, 10);
                                clientInfor.fourthShot = reader.GetDateTime(11).ToString().Substring(0, 10);
                                clientInfor.vaccine1Manufacturer = reader.GetString(12);
                                clientInfor.vaccine2Manufacturer = reader.GetString(13);
                                clientInfor.vaccine3Manufacturer = reader.GetString(14);
                                clientInfor.vaccine4Manufacturer= reader.GetString(15);
                                clientInfor.positiveDate = reader.GetDateTime(16).ToString().Substring(0, 10);
                                clientInfor.coronaRecovery = reader.GetDateTime(17).ToString().Substring(0, 10);
                                clientInfor.created_at= reader.GetDateTime(18).ToString();

                                listClients.Add(clientInfor);

                            }
                        }

                    }
                }
            
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.ToString());
            }
        }
    }
    public class ClientInfor
    {
        public string id { get; set; }
        // public ImageFileMachine image  { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string cellPhoneNumber { get; set; }
        public string email { get; set; }
        public string birthDate { get; set; }
        public string firstShot { get; set; }
        public string secondShot { get; set; }
        public string thirdShot { get; set; }
        public string fourthShot { get; set; }
        public string vaccine1Manufacturer { get; set; }
        public string vaccine2Manufacturer { get; set; }
        public string vaccine3Manufacturer { get; set; }
        public string vaccine4Manufacturer { get; set; }
        public string positiveDate { get; set; }
        public string coronaRecovery { get; set; }
        public string created_at { get; set; }
    }
}
