using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ManagementCoronaSystem.WebSite.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfor clientInfor=new ClientInfor();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
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

            if (clientInfor.id.Length != 9 )
            {
                errorMessage = "invaild Id";
                return;
            }

            // check for empty required  
            if (clientInfor.id.Length==0 || clientInfor.firstName.Length==0 || clientInfor.lastName.Length==0 || clientInfor.address.Length==0 || clientInfor.cellPhoneNumber.Length==0 || clientInfor.phoneNumber.Length==0 || clientInfor.email.Length==0 || clientInfor.birthDate.Length==0 ) {
                errorMessage = "All fields are required";
                return;
            }

            //checking that if there was a shot put in the maunfaturer is also put in
            if (clientInfor.vaccine1Manufacturer.Length==0 && clientInfor.firstShot.Length!=0)
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
            //making sure all dates are after Corona started 

            
           
            //making sure that shots are put in correctly 
            if (DateTime.Parse(clientInfor.birthDate).CompareTo(DateTime.Parse(clientInfor.firstShot))>0)
            {
                errorMessage = "Invalid date, Birthdate comes before first shot ";
                return;
            }
            if (clientInfor.firstShot.Length == 0 && clientInfor.secondShot.Length != 0)
            {
                errorMessage = "Invalid date, first shot is empty first shot before second shot ";
                return;
            }
            if (DateTime.Parse(clientInfor.firstShot).CompareTo(DateTime.Parse(clientInfor.secondShot))>0)
            {
                errorMessage = "Invalid date, First shot is before second shot ";
                return;
            }
            if(clientInfor.secondShot.Length==0 && clientInfor.thirdShot.Length !=0)
            {
                errorMessage = "Invalid date, second shot is empty second shot before third shot ";
                return;
            }
            if (DateTime.Parse(clientInfor.secondShot).CompareTo(DateTime.Parse(clientInfor.thirdShot)) > 0)
            {
                errorMessage = "Invalid date, Second shot is before Third shot ";
                return;
            }
            if (clientInfor.thirdShot.Length == 0 && clientInfor.fourthShot.Length != 0)
            {
                errorMessage = "Invalid date, third shot is empty third shot before fourth shot ";
                return;
            }
            if (DateTime.Parse(clientInfor.thirdShot).CompareTo(DateTime.Parse(clientInfor.fourthShot)) > 0)
            {
                errorMessage = "Invalid date, Third shot is before fourth  shot ";
                return;
            }

           


            // Saving the clients in to the database
            try
            {

                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Clients;Integrated Security=True";
                using ( SqlConnection connection = new SqlConnection(connectionString))
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
      
    }
}
