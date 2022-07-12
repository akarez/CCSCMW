using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Review Main Page C# File */

namespace SWE.Pages.Review
{
    public class IndexModel : PageModel
    {
        public List<ReviewInfo> ListReviews = new List<ReviewInfo>();    /* create a list of ReviewInfo objects */
        public void OnGet()     /* fill the list with data from the database */
        {
            try
            {
                String ConnectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";   // connect to the database with connection string

                using (SqlConnection connection = new SqlConnection(ConnectionString))      // create SQL conneciton
                {
                    connection.Open();      // open SQL connection
                    String sql = "SELECT * FROM Review";    // create query to read author table
                    using (SqlCommand command = new SqlCommand(sql, connection))        // create sql command to execute sql query
                    {
                        using (SqlDataReader reader = command.ExecuteReader())      // execute reader
                        {
                            while (reader.Read())           // read data from the table
                            {
                                ReviewInfo reviewInfo = new ReviewInfo();       // create reviewInfo object then save every attribute

                                reviewInfo.ReviewID = "" + reader.GetInt32(0);
                                reviewInfo.PaperID = "" + reader.GetInt32(1);
                                reviewInfo.ReviewerID = "" + reader.GetInt32(2);
                                reviewInfo.AppropriatenessOfTopic = "" + reader.GetDecimal(3);
                                reviewInfo.TimelinessOfTopic = "" + reader.GetDecimal(4);
                                reviewInfo.SupportiveEvidence = "" + reader.GetDecimal(5);
                                reviewInfo.TechnicalQuality = "" + reader.GetDecimal(6);
                                reviewInfo.ScopeOfCoverage = "" + reader.GetDecimal(7);
                                reviewInfo.CitationOfPreviousWork = "" + reader.GetDecimal(8);
                                reviewInfo.Originality = "" + reader.GetDecimal(9);
                                reviewInfo.ContentComments = reader.GetString(10);
                                reviewInfo.OrganizationOfPaper = "" + reader.GetDecimal(11);
                                reviewInfo.ClarityOfMainMessage = "" + reader.GetDecimal(13);
                                reviewInfo.Mechanics = "" + reader.GetDecimal(14);
                                reviewInfo.WrittenDocumentComments = reader.GetString(15);
                                reviewInfo.SuitabilityForPresentation = "" + reader.GetDecimal(16);
                                reviewInfo.PotentialInterestInTopic = "" + reader.GetDecimal(17);
                                reviewInfo.PotentialForOralPresentationComments = reader.GetString(18);
                                reviewInfo.OverallRating = "" + reader.GetDecimal(19);
                                reviewInfo.OverallRatingComments = reader.GetString(20);
                                reviewInfo.ComfortLevelTopic = "" + reader.GetDecimal(21);
                                reviewInfo.ComfortLevelAcceptability = "" + reader.GetDecimal(22);
                                reviewInfo.Complete = "" + reader.GetSqlBinary(23);

                                ListReviews.Add(reviewInfo);        // add object inot the list
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
    public class ReviewInfo         /* will store the data of one review */
    {
        public String ReviewID;
        public String PaperID;
        public String ReviewerID;
        public String AppropriatenessOfTopic;
        public String TimelinessOfTopic;
        public String SupportiveEvidence;
        public String TechnicalQuality;
        public String ScopeOfCoverage;
        public String CitationOfPreviousWork;
        public String Originality;
        public String ContentComments;
        public String OrganizationOfPaper;
        public String ClarityOfMainMessage;
        public String Mechanics;
        public String WrittenDocumentComments;
        public String SuitabilityForPresentation;
        public String PotentialInterestInTopic;
        public String PotentialForOralPresentationComments;
        public String OverallRating;
        public String OverallRatingComments;
        public String ComfortLevelTopic;
        public String ComfortLevelAcceptability;
        public String Complete;
    }
}