using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Author Add Page C# File */

// TODO: add password confirmation

namespace SWE.Pages.Author
{
    public class AddModel : PageModel
    {
        public AuthorInfo authorInfo = new AuthorInfo();    // create a new authorInfo object to add
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()        // fill the database with input table
        {
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
            // add if validation for empty boxes
            // ERROR: PHONE AND EMAIL SAVED AS NULL
            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True"; // connection string
                // create SQL conneciton
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();      // open connection
                    //  create query to insert values
                    String sql = "INSERT INTO Author (FirstName, MiddleInitial, LastName, Affiliation, Department, Address, City, State, ZipCode, PhoneNumber, EmailAddress, Password) VALUES (@FirstName, @MiddleInitial, @LastName, @Affiliation, @Department, @Address, @City, @State, @ZipCode, @PhoneNumber, @EmailAddress, @Password);";
                    // execute query and replace parameters with input data
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        if (String.IsNullOrEmpty(authorInfo.FirstName))
                        {
                            command.Parameters.AddWithValue("@FirstName", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@FirstName", authorInfo.FirstName);

                        if (String.IsNullOrEmpty(authorInfo.MiddleInitial))
                        {
                            command.Parameters.AddWithValue("@MiddleInitial", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@MiddleInitial", authorInfo.MiddleInitial);

                        if (String.IsNullOrEmpty(authorInfo.LastName))
                        {
                            command.Parameters.AddWithValue("@LastName", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@LastName", authorInfo.LastName);

                        if (String.IsNullOrEmpty(authorInfo.Affiliation))
                        {
                            command.Parameters.AddWithValue("@Affiliation", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Affiliation", authorInfo.Affiliation);

                        if (String.IsNullOrEmpty(authorInfo.Department))
                        {
                            command.Parameters.AddWithValue("@Department", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Department", authorInfo.Department);

                        if (String.IsNullOrEmpty(authorInfo.Address))
                        {
                            command.Parameters.AddWithValue("@Address", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Address", authorInfo.Address);

                        if (String.IsNullOrEmpty(authorInfo.City))
                        {
                            command.Parameters.AddWithValue("@City", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@City", authorInfo.City);

                        if (String.IsNullOrEmpty(authorInfo.State))
                        {
                            command.Parameters.AddWithValue("@State", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@State", authorInfo.State);

                        if (String.IsNullOrEmpty(authorInfo.ZipCode))
                        {
                            command.Parameters.AddWithValue("@ZipCode", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ZipCode", authorInfo.ZipCode);

                        if (String.IsNullOrEmpty(authorInfo.PhoneNumber))
                        {
                            command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@PhoneNumber", authorInfo.PhoneNumber);

                        if (String.IsNullOrEmpty(authorInfo.EmailAddress))
                        {
                            command.Parameters.AddWithValue("@EmailAddress", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@EmailAddress", authorInfo.EmailAddress);

                        if (String.IsNullOrEmpty(authorInfo.Password))
                        {
                            command.Parameters.AddWithValue("@Password", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Password", authorInfo.Password);

                        command.ExecuteNonQuery();      // execute query
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            // clear current object fields
            authorInfo.FirstName = "";
            authorInfo.MiddleInitial = "";
            authorInfo.LastName = "";
            authorInfo.Affiliation = "";
            authorInfo.Department = "";
            authorInfo.Address = "";
            authorInfo.City = "";
            authorInfo.State = "";
            authorInfo.ZipCode = "";
            authorInfo.PhoneNumber = "";
            authorInfo.EmailAddress = "";
            authorInfo.Password = "";

            successMessage = "Submission successful!";
            Response.Redirect("/Author/Index");
        }
    }
}