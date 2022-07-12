using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Paper Edit Page C# File */

namespace SWE.Pages.Paper
{
    public class EditModel : PageModel
    {
        public PaperInfo paperInfo = new PaperInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String PaperID = Request.Query["PaperID"];

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Paper WHERE PaperID=@PaperID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PaperID", PaperID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                paperInfo.PaperID = "" + reader.GetInt32(0);
                                paperInfo.AuthorID = "" + reader.GetInt32(1);
                                paperInfo.Active = "" + reader.GetSqlBinary(2);
                                paperInfo.FilenameOriginal = reader.GetString(3);
                                paperInfo.Filename = reader.GetString(4);
                                paperInfo.Title = reader.GetString(5);
                                paperInfo.Certification = reader.GetString(6);
                                paperInfo.NotesToReviewers = reader.GetString(7);
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
            paperInfo.PaperID = Request.Form["PaperID"];
            paperInfo.AuthorID = Request.Form["AuthorID"];
            paperInfo.Active = Request.Form["Active"];
            paperInfo.FilenameOriginal = Request.Form["FilenameOriginal"];
            paperInfo.Filename = Request.Form["Filename"];
            paperInfo.Title = Request.Form["Title"];
            paperInfo.Certification = Request.Form["Certification"];
            paperInfo.NotesToReviewers = Request.Form["NotesToReviewers"];

            //insert if statement
            //errorMessage = "All fields required"
            //return;

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Paper SET PaperID=@PaperID, AuthorID=@AuthorID, Active=@Active, FilenameOriginal=@FilenameOriginal, Filename=@Filename, Title=@Title, Certification=@Certification, NotesToReviewers=@NotesToReviewers";     // select paper with corresponding ID

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PaperID", paperInfo.PaperID);
                        command.Parameters.AddWithValue("@AuthorID", paperInfo.AuthorID);
                        command.Parameters.AddWithValue("@Active", paperInfo.Active);
                        command.Parameters.AddWithValue("@FilenameOriginal", paperInfo.FilenameOriginal);
                        command.Parameters.AddWithValue("@Filename", paperInfo.Filename);
                        command.Parameters.AddWithValue("@Title", paperInfo.Title);
                        command.Parameters.AddWithValue("@Certification", paperInfo.Certification);
                        command.Parameters.AddWithValue("@NotesToReviewers", paperInfo.NotesToReviewers);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Paper/Index");
        }
    }
}