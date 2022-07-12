using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Reviewer Add Page C# File */

// TODO: add password confirmation
// add if input validation but first figure out the input error

namespace SWE.Pages.Reviewer
{
    public class AddModel : PageModel
    {
        public ReviewerInfo reviewerInfo = new ReviewerInfo();    // create a new reviewerInfo object to add
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()        // fill the database with input table
        {
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
                    String sql = "INSERT INTO Reviewer (Active, FirstName, MiddleInitial, LastName, Affiliation, Department, Address, City, State, ZipCode, PhoneNumber, EmailAddress, Password) VALUES (@Active, @FirstName, @MiddleInitial, @LastName, @Affiliation, @Department, @Address, @City, @State, @ZipCode, @PhoneNumber, @EmailAddress, @Password);";
                    // execute query and replace parameters with input data
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        if (String.IsNullOrEmpty(reviewerInfo.Active))
                        {
                            command.Parameters.AddWithValue("@Active", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Active", reviewerInfo.Active);

                        if (String.IsNullOrEmpty(reviewerInfo.FirstName))
                        {
                            command.Parameters.AddWithValue("@FirstName", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@FirstName", reviewerInfo.FirstName);

                        if (String.IsNullOrEmpty(reviewerInfo.MiddleInitial))
                        {
                            command.Parameters.AddWithValue("@MiddleInitial", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@MiddleInitial", reviewerInfo.MiddleInitial);

                        if (String.IsNullOrEmpty(reviewerInfo.LastName))
                        {
                            command.Parameters.AddWithValue("@LastName", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@LastName", reviewerInfo.LastName);

                        if (String.IsNullOrEmpty(reviewerInfo.Affiliation))
                        {
                            command.Parameters.AddWithValue("@Affiliation", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Affiliation", reviewerInfo.Affiliation);

                        if (String.IsNullOrEmpty(reviewerInfo.Department))
                        {
                            command.Parameters.AddWithValue("@Department", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Department", reviewerInfo.Department);

                        if (String.IsNullOrEmpty(reviewerInfo.Address))
                        {
                            command.Parameters.AddWithValue("@Address", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Address", reviewerInfo.Address);

                        if (String.IsNullOrEmpty(reviewerInfo.City))
                        {
                            command.Parameters.AddWithValue("@City", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@City", reviewerInfo.City);

                        if (String.IsNullOrEmpty(reviewerInfo.State))
                        {
                            command.Parameters.AddWithValue("@State", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@State", reviewerInfo.State);

                        if (String.IsNullOrEmpty(reviewerInfo.ZipCode))
                        {
                            command.Parameters.AddWithValue("@ZipCode", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ZipCode", reviewerInfo.ZipCode);

                        if (String.IsNullOrEmpty(reviewerInfo.PhoneNumber))
                        {
                            command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@PhoneNumber", reviewerInfo.PhoneNumber);

                        if (String.IsNullOrEmpty(reviewerInfo.EmailAddress))
                        {
                            command.Parameters.AddWithValue("@EmailAddress", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@EmailAddress", reviewerInfo.EmailAddress);

                        if (String.IsNullOrEmpty(reviewerInfo.Password))
                        {
                            command.Parameters.AddWithValue("@Password", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Password", reviewerInfo.Password);

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

            reviewerInfo.Active = "";
            reviewerInfo.FirstName = "";
            reviewerInfo.MiddleInitial = "";
            reviewerInfo.LastName = "";
            reviewerInfo.Affiliation = "";
            reviewerInfo.Department = "";
            reviewerInfo.Address = "";
            reviewerInfo.City = "";
            reviewerInfo.State = "";
            reviewerInfo.ZipCode = "";
            reviewerInfo.PhoneNumber = "";
            reviewerInfo.EmailAddress = "";
            reviewerInfo.Password = "";

            successMessage = "Submission successful!";
            Response.Redirect("/Reviewer/Index");
        }
    }
}