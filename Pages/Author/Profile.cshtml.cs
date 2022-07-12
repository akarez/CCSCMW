using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Author Profile Page C# File */

namespace SWE.Pages.Author
{
    public class ProfileModel : PageModel
    {
        public List<AuthorInfo> ListAuthors = new List<AuthorInfo>();    /* create a list of AuthorInfo objects */

        public void OnGet()     /* fill the list with data from the database */
        {
            String AuthorID = Request.Query["AuthorID"];        /* declare variable to query the AuthorID*/

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";   /* connect to the database with connection string */

                using (SqlConnection connection = new SqlConnection(connectionString))      /* create SQL conneciton */
                {
                    connection.Open();      // open SQL connection
                    String sql = "SELECT FROM Author WHERE AuthorID=@AuthorID";         /* create query to read author table */
                    using (SqlCommand command = new SqlCommand(sql, connection))        /* create sql command to execute sql query */
                    {
                        using (SqlDataReader reader = command.ExecuteReader())      /* execute sql reader */
                        {
                            while (reader.Read())           /* read data from the table */
                            {
                                AuthorInfo authorInfo = new AuthorInfo();       /* create authorInfo object then save every attribute */

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

                                ListAuthors.Add(authorInfo);        /* add object into the list */
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
        public void OnPost()
        {

        }
    }
}

