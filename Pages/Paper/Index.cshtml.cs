using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Paper Main Page C# File */

namespace SWE.Pages.Paper
{
    public class IndexModel : PageModel
    {
        public List<PaperInfo> ListPapers = new List<PaperInfo>();    /* create a list of PaperInfo objects */
        public void OnGet()     /* fill the list with data from the database */
        {
            try
            {
                String ConnectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";   // connect to the database with connection string

                using (SqlConnection connection = new SqlConnection(ConnectionString))      // create SQL conneciton
                {
                    connection.Open();      // open SQL connection
                    String sql = "SELECT * FROM Paper";    // create query to read Paper table
                    using (SqlCommand command = new SqlCommand(sql, connection))        // create sql command to execute sql query
                    {
                        using (SqlDataReader reader = command.ExecuteReader())      // execute reader
                        {
                            while (reader.Read())           // read data from the table
                            {
                                PaperInfo paperInfo = new PaperInfo();       // create paper info object then save every attribute

                                paperInfo.PaperID = "" + reader.GetInt32(0);
                                paperInfo.AuthorID = "" + reader.GetInt32(0);
                                paperInfo.Active = "" + reader.GetSqlBinary(1);
                                paperInfo.FilenameOriginal = reader.GetString(2);
                                paperInfo.Filename = reader.GetString(3);
                                paperInfo.Title = reader.GetString(4);
                                paperInfo.Certification = reader.GetString(5);
                                paperInfo.NotesToReviewers = reader.GetString(6);

                                ListPapers.Add(paperInfo);        // add object into the list
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());       // in case of errors print to console
            }
        }
    }
    public class PaperInfo         /* will store the data of one paper */
    {
        public String PaperID;
        public String AuthorID;
        public String Active;
        public String FilenameOriginal;
        public String Filename;
        public String Title;
        public String Certification;
        public String NotesToReviewers;
    }
}
