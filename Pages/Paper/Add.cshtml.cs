using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Paper Add Page C# File */


// add if input validation but first figure out the input error

namespace SWE.Pages.Paper
{
    public class AddModel : PageModel
    {
        public PaperInfo paperInfo = new PaperInfo();    // create a new paperInfo object to add
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()        // fill the database with input table
        {
            paperInfo.AuthorID = Request.Form["AuthorID"];
            paperInfo.Active = Request.Form["Active"];
            paperInfo.FilenameOriginal = Request.Form["FilenameOriginal"];
            paperInfo.Filename = Request.Form["Filename"];
            paperInfo.Title = Request.Form["Title"];
            paperInfo.Certification = Request.Form["Certification"];
            paperInfo.NotesToReviewers = Request.Form["NotesToReviewers"];

            // add if validation for empty boxes

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True"; // connection string
                // create SQL conneciton
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();      // open connection
                    //  create query to insert values
                    String sql = "INSERT INTO Paper (AuthorID, Active, FilenameOriginal, Filename, Title, Certification, NotesToReviewers) VALUES (@AuthorID, @Active, @FilenameOriginal, @Filename, @Title, @Certification, @NotesToReviewers);";
                    // execute query and replace parameters with input data
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        if (String.IsNullOrEmpty(paperInfo.AuthorID))
                        {
                            command.Parameters.AddWithValue("@AuthorID", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@AuthorID", paperInfo.AuthorID);

                        if (String.IsNullOrEmpty(paperInfo.Active))
                        {
                            command.Parameters.AddWithValue("@Active", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Active", paperInfo.Active);

                        if (String.IsNullOrEmpty(paperInfo.FilenameOriginal))
                        {
                            command.Parameters.AddWithValue("@FilenameOriginal", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@FilenameOriginal", paperInfo.FilenameOriginal);

                        if (String.IsNullOrEmpty(paperInfo.Filename))
                        {
                            command.Parameters.AddWithValue("@Filename", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Filename", paperInfo.Filename);

                        if (String.IsNullOrEmpty(paperInfo.Title))
                        {
                            command.Parameters.AddWithValue("@Title", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Title", paperInfo.Title);

                        if (String.IsNullOrEmpty(paperInfo.Certification))
                        {
                            command.Parameters.AddWithValue("@Certification", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Certification", paperInfo.Certification);

                        if (String.IsNullOrEmpty(paperInfo.NotesToReviewers))
                        {
                            command.Parameters.AddWithValue("@NotesToReviewers", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@NotesToReviewers", paperInfo.NotesToReviewers);

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

            paperInfo.AuthorID = "";
            paperInfo.Active = "";
            paperInfo.FilenameOriginal = "";
            paperInfo.Filename = "";
            paperInfo.Title = "";
            paperInfo.Certification = "";
            paperInfo.NotesToReviewers = "";

            successMessage = "Submission successful!";
            Response.Redirect("/Paper/Index");
        }
    }
}