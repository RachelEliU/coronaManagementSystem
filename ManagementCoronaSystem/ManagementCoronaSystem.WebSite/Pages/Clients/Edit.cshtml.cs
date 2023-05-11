using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace ManagementCoronaSystem.WebSite.Pages.Clients
{
    public class EditModel : PageModel
    {
        public ClientInfor clientInfor =new ClientInfor();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Clients;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clientInfor.id = reader.GetString(0);
                                clientInfor.firstName = reader.GetString(1);
                                clientInfor.lastName = reader.GetString(2);
                                clientInfor.address = reader.GetString(3);
                                clientInfor.phoneNumber = reader.GetString(4);
                                clientInfor.cellPhoneNumber = reader.GetString(5);
                                clientInfor.email = reader.GetString(6);
                                clientInfor.birthDate = reader.GetDateTime(7).ToString();
                                clientInfor.firstShot = reader.GetDateTime(8).ToString();
                                clientInfor.secondShot = reader.GetDateTime(9).ToString();
                                clientInfor.thirdShot = reader.GetDateTime(10).ToString();
                                clientInfor.fourthShot = reader.GetDateTime(11).ToString();
                                clientInfor.vaccine1Manufacturer = reader.GetString(12);
                                clientInfor.vaccine2Manufacturer = reader.GetString(13);
                                clientInfor.vaccine3Manufacturer = reader.GetString(14);
                                clientInfor.vaccine4Manufacturer = reader.GetString(15);
                                clientInfor.positiveDate = reader.GetDateTime(16).ToString();
                                clientInfor.coronaRecovery = reader.GetDateTime(17).ToString();
                                clientInfor.created_at = reader.GetDateTime(18).ToString();


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
        public void OnPost() 
        {
            clientInfor.id = Request.Form["id"];
            //clientInfor.image = Request.File["image"];
            clientInfor.firstName = Request.Form["firstName"];
            clientInfor.lastName = Request.Form["lastName"];
            clientInfor.address = Request.Form["address"];
            clientInfor.phoneNumber = Request.Form["phoneNumber"];
            clientInfor.cellPhoneNumber = Request.Form["cellPhoneNumber"];
            clientInfor.email = Request.Form["email"];
            clientInfor.birthDate = Request.Form["birthDate"];
            clientInfor.firstShot = Request.Form["firstShot"];
            clientInfor.secondShot = Request.Form["secondShot"];
            clientInfor.thirdShot = Request.Form["thirdShot"];
            clientInfor.fourthShot = Request.Form["fourthShot"];
            clientInfor.vaccine1Manufacturer = Request.Form["vaccine1Manufacturer"];
            clientInfor.vaccine2Manufacturer = Request.Form["vaccine2Manufacturer"];
            clientInfor.vaccine3Manufacturer = Request.Form["vaccine3Manufacturer"];
            clientInfor.vaccine4Manufacturer = Request.Form["vaccine4Manufacturer"];
            clientInfor.positiveDate = Request.Form["positiveDate"];
            clientInfor.coronaRecovery = Request.Form["coronaRecovery"];

             if (clientInfor.id.Length != 9)
            {
                errorMessage = "unvaild Id";
                return;
            }

            // check for empty required  
            if (clientInfor.id.Length == 0 || clientInfor.firstName.Length == 0 || clientInfor.lastName.Length == 0 || clientInfor.address.Length == 0 || clientInfor.cellPhoneNumber.Length == 0 || clientInfor.phoneNumber.Length == 0 || clientInfor.email.Length == 0 || clientInfor.birthDate.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }
            if (clientInfor.vaccine1Manufacturer.Length == 0 && clientInfor.firstShot.Length != 0)
            {
                errorMessage = "First shot manufacture is required";
                return;
            }
            if (clientInfor.vaccine2Manufacturer.Length == 0 && clientInfor.secondShot.Length != 0)
            {
                errorMessage = "Second shot manufacture is required";
                return;
            }
            if (clientInfor.vaccine3Manufacturer.Length == 0 && clientInfor.thirdShot.Length != 0)
            {
                errorMessage = "Third shot manufacture is required";
                return;
            }
            if (clientInfor.vaccine4Manufacturer.Length == 0 && clientInfor.fourthShot.Length != 0)
            {
                errorMessage = "Fourth shot manufacture is required";
                return;
            }
            if (DateTime.Parse(clientInfor.firstShot).CompareTo(DateTime.Parse(clientInfor.secondShot)) == 1)
            {

            }


            // Saving the clients in to the database
            try
            {

                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Clients;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO clients " +
                        "(id,firstName,lastName,address,phoneNumber,cellPhoneNumber,email,birthDate,firstShot,secondShot,thirdShot,fourthShot,vaccine1Manufacturer,vaccine2Manufacturer,vaccine3Manufacturer,vaccine4Manufacturer,positiveDate,coronaRecovery) VALUES" +
                        "(@id,@firstName,@lastName,@address,@phoneNumber,@cellPhoneNumber,@email,@birthDate,@firstShot,@secondShot,@thirdShot,@fourthShot,@vaccine1Manufacturer,@vaccine2Manufacturer,@vaccine3Manufacturer,@vaccine4Manufacturer,@positiveDate,@coronaRecovery);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", clientInfor.id);
                        command.Parameters.AddWithValue("@firstName", clientInfor.firstName);
                        command.Parameters.AddWithValue("@lastName", clientInfor.lastName);
                        command.Parameters.AddWithValue("@address", clientInfor.address);
                        command.Parameters.AddWithValue("@phoneNumber", clientInfor.phoneNumber);
                        command.Parameters.AddWithValue("@cellPhoneNumber", clientInfor.cellPhoneNumber);
                        command.Parameters.AddWithValue("@email", clientInfor.email);
                        command.Parameters.AddWithValue("@birthDate", clientInfor.birthDate);
                        command.Parameters.AddWithValue("@firstShot", clientInfor.firstShot);
                        command.Parameters.AddWithValue("@secondShot", clientInfor.secondShot);
                        command.Parameters.AddWithValue("@thirdShot", clientInfor.thirdShot);
                        command.Parameters.AddWithValue("@fourthShot", clientInfor.fourthShot);
                        command.Parameters.AddWithValue("@vaccine1Manufacturer", clientInfor.vaccine1Manufacturer);
                        command.Parameters.AddWithValue("@vaccine2Manufacturer", clientInfor.vaccine2Manufacturer);
                        command.Parameters.AddWithValue("@vaccine3Manufacturer", clientInfor.vaccine3Manufacturer);
                        command.Parameters.AddWithValue("@vaccine4Manufacturer", clientInfor.vaccine4Manufacturer);
                        command.Parameters.AddWithValue("@positiveDate", clientInfor.positiveDate);
                        command.Parameters.AddWithValue("@coronaRecovery", clientInfor.coronaRecovery);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;

            }
            clientInfor.id = "";
            clientInfor.firstName = "";
            clientInfor.lastName = "";
            clientInfor.address = "";
            clientInfor.phoneNumber = "";
            clientInfor.cellPhoneNumber = "";
            clientInfor.email = "";
            clientInfor.birthDate = "";
            clientInfor.firstShot = "";
            clientInfor.secondShot = "";
            clientInfor.thirdShot = "";
            clientInfor.fourthShot = "";
            clientInfor.vaccine1Manufacturer = "";
            clientInfor.vaccine2Manufacturer = "";
            clientInfor.vaccine3Manufacturer = "";
            clientInfor.vaccine4Manufacturer = "";
            clientInfor.positiveDate = "";
            clientInfor.coronaRecovery = "";
            successMessage = "New Client Added Correctly";

            Response.Redirect("/Clients/Index");


        }
        /*  public DateTime ConvertToDate(String date)
          {
              if (date.Length==0)
              {
                  return DateTime.Today;
              }
              DateTime.Parse(date);
          }*/
    }
    
    
}
