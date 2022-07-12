using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Reviewer Profile Page C# File */

namespace SWE.Pages.Reviewer
{
    public class ProfileModel : PageModel
    {
        public List<ReviewerInfo> ListReviewers = new List<ReviewerInfo>();    /* create a list of ReviewerInfo objects */
        public void OnGet()     /* fill the list with data from the database */
        {
            String ReviewerID = Request.Query["ReviewerID"];        /* declare variable to query the ReviewerID*/
            try
            {
                String ConnectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";   /* connect to the database with connection string */

                using (SqlConnection connection = new SqlConnection(ConnectionString))      /* create SQL conneciton */
                {
                    connection.Open();      /* open SQL connection */
                    String sql = "SELECT FROM Reviewer WHERE ReviewerID=@ReviewerID";     /* create query to read Reviewer table */
                    using (SqlCommand command = new SqlCommand(sql, connection))        /* create sql command to execute sql query */
                    {
                        using (SqlDataReader reader = command.ExecuteReader())      /* execute reader */
                        {
                            while (reader.Read())           /* read data from the table */
                            {
                                ReviewerInfo reviewerInfo = new ReviewerInfo();       /* create Reviewerinfo object then save every attribute */

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

                                ListReviewers.Add(reviewerInfo);        /* add object into the list */
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());       /* in case of errors print to console */
            }
        }
    }
}
