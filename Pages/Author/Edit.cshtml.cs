using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Author Edit Page C# File */

namespace SWE.Pages.Author
{
    public class EditModel : PageModel
    {
        public AuthorInfo authorInfo = new AuthorInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String AuthorID = Request.Query["AuthorID"];

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Author WHERE AuthorID=@AuthorID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@AuthorID", AuthorID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                authorInfo.AuthorID = "" + reader.GetInt32(0);
                                authorInfo.FirstName = reader.GetString(1);
                                authorInfo.MiddleInitial = reader.GetString(2);
                                authorInfo.LastName = reader.GetString(3);
                                authorInfo.Affiliation = reader.GetString(4);
                                authorInfo.Department = reader.GetString(5);
                                authorInfo.Address = reader.GetString(6);
                                authorInfo.City = reader.GetString(7);
                                authorInfo.State = reader.GetString(8);
                                authorInfo.ZipCode = reader.GetString(9);
                                authorInfo.PhoneNumber = reader.GetString(10);
                                authorInfo.EmailAddress = reader.GetString(11);
                                authorInfo.Password = reader.GetString(12);

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
            authorInfo.AuthorID = Request.Form["AuthorID"];
            authorInfo.FirstName = Request.Form["FirstName"];
            authorInfo.MiddleInitial = Request.Form["MiddleInitial"];
            authorInfo.LastName = Request.Form["LastName"];
            authorInfo.Affiliation = Request.Form["Affiliation"];
            authorInfo.Department = Request.Form["Department"];
            authorInfo.Address = Request.Form["Address"];
            authorInfo.City = Request.Form["City"];
            authorInfo.State = Request.Form["State"];
            authorInfo.ZipCode = Request.Form["ZipCode"];
            authorInfo.PhoneNumber = Request.Form["PhoneNumber"];
            authorInfo.EmailAddress = Request.Form["EmailAddress"];
            authorInfo.Password = Request.Form["Password"];

            //insert if statement
            //errorMessage = "All fields required"
            //return;

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Author SET AuthorID=@AuthorID, FirstName=@FirstName, MiddleInitial=@MiddleInitial, LastName=@LastName, Affiliation=@Affiliation, Department=@Department, Address=@Address, City=@City, State=@State, ZipCode=@ZipCode, PhoneNumber=@PhoneNumber, EmailAddress=@EmailAddress, Password=@Password WHERE AuthorID=@AuthorID";     // select client with corresponding ID

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", authorInfo.FirstName);
                        command.Parameters.AddWithValue("@MiddleInitial", authorInfo.MiddleInitial);
                        command.Parameters.AddWithValue("@LastName", authorInfo.LastName);
                        command.Parameters.AddWithValue("@Affiliation", authorInfo.Affiliation);
                        command.Parameters.AddWithValue("@Department", authorInfo.Department);
                        command.Parameters.AddWithValue("@Address", authorInfo.Address);
                        command.Parameters.AddWithValue("@City", authorInfo.City);
                        command.Parameters.AddWithValue("@State", authorInfo.State);
                        command.Parameters.AddWithValue("@ZipCode", authorInfo.ZipCode);
                        command.Parameters.AddWithValue("@PhoneNumber", authorInfo.PhoneNumber);
                        command.Parameters.AddWithValue("@EmailAddress", authorInfo.EmailAddress);
                        command.Parameters.AddWithValue("@Password", authorInfo.Password);
                        command.Parameters.AddWithValue("@AuthorID", authorInfo.AuthorID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Author/Index");
        }
    }
}
