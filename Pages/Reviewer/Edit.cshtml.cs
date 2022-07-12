using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Reviewer Edit Page C# File */

namespace SWE.Pages.Reviewer
{
    public class EditModel : PageModel
    {
        public ReviewerInfo reviewerInfo = new ReviewerInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String ReviewerID = Request.Query["ReviewerID"];

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Reviewer WHERE ReviewerID=@ReviewerID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ReviewerID", ReviewerID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                reviewerInfo.ReviewerID = "" + reader.GetInt32(0);
                                reviewerInfo.Active = "" + reader.GetSqlBinary(1);
                                reviewerInfo.FirstName = reader.GetString(2);
                                reviewerInfo.MiddleInitial = reader.GetString(3);
                                reviewerInfo.LastName = reader.GetString(4);
                                reviewerInfo.Affiliation = reader.GetString(5);
                                reviewerInfo.Department = reader.GetString(6);
                                reviewerInfo.Address = reader.GetString(7);
                                reviewerInfo.City = reader.GetString(8);
                                reviewerInfo.State = reader.GetString(9);
                                reviewerInfo.ZipCode = reader.GetString(10);
                                reviewerInfo.PhoneNumber = reader.GetString(11);
                                reviewerInfo.EmailAddress = reader.GetString(12);
                                reviewerInfo.Password = reader.GetString(13);

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            reviewerInfo.ReviewerID = Request.Form["ReviewerID"];
            reviewerInfo.Active = Request.Form["Active"];
            reviewerInfo.FirstName = Request.Form["FirstName"];
            reviewerInfo.MiddleInitial = Request.Form["MiddleInitial"];
            reviewerInfo.LastName = Request.Form["LastName"];
            reviewerInfo.Affiliation = Request.Form["Affiliation"];
            reviewerInfo.Department = Request.Form["Department"];
            reviewerInfo.Address = Request.Form["Address"];
            reviewerInfo.City = Request.Form["City"];
            reviewerInfo.State = Request.Form["State"];
            reviewerInfo.ZipCode = Request.Form["ZipCode"];
            reviewerInfo.PhoneNumber = Request.Form["PhoneNumber"];
            reviewerInfo.EmailAddress = Request.Form["EmailAddress"];
            reviewerInfo.Password = Request.Form["Password"];

            //insert if statement
            //errorMessage = "All fields required"
            //return;

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Reviewer SET ReviewerID=@ReviewerID, Active=@Active, FirstName=@FirstName, MiddleInitial=@MiddleInitial, LastName=@LastName, Affiliation=@Affiliation, Department=@Department, Address=@Address, City=@City, State=@State, ZipCode=@ZipCode, PhoneNumber=@PhoneNumber, EmailAddress=@EmailAddress, Password=@Password WHERE ReviewerID=@ReviewerID";     // select client with corresponding ID

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Active", reviewerInfo.Active);
                        command.Parameters.AddWithValue("@FirstName", reviewerInfo.FirstName);
                        command.Parameters.AddWithValue("@MiddleInitial", reviewerInfo.MiddleInitial);
                        command.Parameters.AddWithValue("@LastName", reviewerInfo.LastName);
                        command.Parameters.AddWithValue("@Affiliation", reviewerInfo.Affiliation);
                        command.Parameters.AddWithValue("@Department", reviewerInfo.Department);
                        command.Parameters.AddWithValue("@Address", reviewerInfo.Address);
                        command.Parameters.AddWithValue("@City", reviewerInfo.City);
                        command.Parameters.AddWithValue("@State", reviewerInfo.State);
                        command.Parameters.AddWithValue("@ZipCode", reviewerInfo.ZipCode);
                        command.Parameters.AddWithValue("@PhoneNumber", reviewerInfo.PhoneNumber);
                        command.Parameters.AddWithValue("@EmailAddress", reviewerInfo.EmailAddress);
                        command.Parameters.AddWithValue("@Password", reviewerInfo.Password);
                        command.Parameters.AddWithValue("@ReviewerID", reviewerInfo.ReviewerID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Reviewer/Index");
        }
    }
}