using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Review Add Page C# File */

// TODO: add password confirmation

namespace SWE.Pages.Review
{
    public class AddModel : PageModel
    {
        public ReviewInfo reviewInfo = new ReviewInfo();    // create a new reviewInfo object to add
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()        // fill the database with input table
        {
            reviewInfo.PaperID = Request.Form["PaperID"];
            reviewInfo.ReviewerID = Request.Form["ReviewerID"];
            reviewInfo.AppropriatenessOfTopic = Request.Form["AppropriatenessOfTopic"];
            reviewInfo.TimelinessOfTopic = Request.Form["TimelinessOfTopic"];
            reviewInfo.SupportiveEvidence = Request.Form["SupportiveEvidence"];
            reviewInfo.TechnicalQuality = Request.Form["TechnicalQuality"];
            reviewInfo.ScopeOfCoverage = Request.Form["ScopeOfCoverage"];
            reviewInfo.CitationOfPreviousWork = Request.Form["CitationOfPreviousWork"];
            reviewInfo.Originality = Request.Form["Originality"];
            reviewInfo.ContentComments = Request.Form["ContentComments"];
            reviewInfo.OrganizationOfPaper = Request.Form["OrganizationOfPaper"];
            reviewInfo.ClarityOfMainMessage = Request.Form["ClarityOfMainMessage"];
            reviewInfo.Mechanics = Request.Form["Mechanics"];
            reviewInfo.WrittenDocumentComments = Request.Form["WrittenDocumentComments"];
            reviewInfo.SuitabilityForPresentation = Request.Form["SuitabilityForPresentation"];
            reviewInfo.PotentialInterestInTopic = Request.Form["PotentialInterestInTopic"];
            reviewInfo.PotentialForOralPresentationComments = Request.Form["PotentialForOralPresentationComments"];
            reviewInfo.OverallRating = Request.Form["OverallRating"];
            reviewInfo.OverallRatingComments = Request.Form["OverallRatingComments"];
            reviewInfo.ComfortLevelTopic = Request.Form["ComfortLevelTopic"];
            reviewInfo.ComfortLevelAcceptability = Request.Form["ComfortLevelAcceptability"];
            reviewInfo.Complete = Request.Form["Complete"];

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
                    String sql = "INSERT INTO Review (PaperID, ReviewerID, AppropriatenessOfTopic, TimelinessOfTopic, SupportiveEvidence, TechnicalQuality, " +
                        "ScopeOfCoverage, CitationOfPreviousWork, Originality, ContentComments, OrganizationOfPaper, ClarityOfMainMessage, Mechanics, " +
                        "WrittenDocumentComments, SuitabilityForPresentation, PotentialInterestInTopic, PotentialForOralPresentationComments, " +
                        "OverallRating, OverallRatingComments, ComfortLevelTopic, ComfortLevelAcceptability, Complete) " +
                        "VALUES (@PaperID, @ReviewerID, @AppropriatenessOfTopic, @TimelinessOfTopic, @SupportiveEvidence, @TechnicalQuality, " +
                        "@ScopeOfCoverage, @CitationOfPreviousWork, @Originality, @ContentComments, @OrganizationOfPaper, @ClarityOfMainMessage, @Mechanics, " +
                        "@WrittenDocumentComments, @SuitabilityForPresentation, @PotentialInterestInTopic, @PotentialForOralPresentationComments, " +
                        "@OverallRating, @OverallRatingComments, @ComfortLevelTopic, @ComfortLevelAcceptability, @Complete);";

                    // execute query and replace parameters with input data
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        if (String.IsNullOrEmpty(reviewInfo.PaperID))
                        {
                            command.Parameters.AddWithValue("@PaperID", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@PaperID", reviewInfo.PaperID);

                        if (String.IsNullOrEmpty(reviewInfo.ReviewerID))
                        {
                            command.Parameters.AddWithValue("@ReviewerID", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ReviewerID", reviewInfo.ReviewerID);

                        if (String.IsNullOrEmpty(reviewInfo.AppropriatenessOfTopic))
                        {
                            command.Parameters.AddWithValue("@AppropriatenessOfTopic", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@AppropriatenessOfTopic", reviewInfo.AppropriatenessOfTopic);

                        if (String.IsNullOrEmpty(reviewInfo.TimelinessOfTopic))
                        {
                            command.Parameters.AddWithValue("@TimelinessOfTopic", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@TimelinessOfTopic", reviewInfo.TimelinessOfTopic);

                        if (String.IsNullOrEmpty(reviewInfo.SupportiveEvidence))
                        {
                            command.Parameters.AddWithValue("@SupportiveEvidence", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@SupportiveEvidence", reviewInfo.SupportiveEvidence);

                        if (String.IsNullOrEmpty(reviewInfo.TechnicalQuality))
                        {
                            command.Parameters.AddWithValue("@TechnicalQuality", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@TechnicalQuality", reviewInfo.TechnicalQuality);

                        if (String.IsNullOrEmpty(reviewInfo.ScopeOfCoverage))
                        {
                            command.Parameters.AddWithValue("@ScopeOfCoverage", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ScopeOfCoverage", reviewInfo.ScopeOfCoverage);

                        if (String.IsNullOrEmpty(reviewInfo.CitationOfPreviousWork))
                        {
                            command.Parameters.AddWithValue("@CitationOfPreviousWork", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@CitationOfPreviousWork", reviewInfo.CitationOfPreviousWork);

                        if (String.IsNullOrEmpty(reviewInfo.Originality))
                        {
                            command.Parameters.AddWithValue("@Originality", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Originality", reviewInfo.Originality);

                        if (String.IsNullOrEmpty(reviewInfo.ContentComments))
                        {
                            command.Parameters.AddWithValue("@ContentComments", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ContentComments", reviewInfo.ContentComments);

                        if (String.IsNullOrEmpty(reviewInfo.OrganizationOfPaper))
                        {
                            command.Parameters.AddWithValue("@OrganizationOfPaper", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@OrganizationOfPaper", reviewInfo.OrganizationOfPaper);

                        if (String.IsNullOrEmpty(reviewInfo.ClarityOfMainMessage))
                        {
                            command.Parameters.AddWithValue("@ClarityOfMainMessage", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ClarityOfMainMessage", reviewInfo.ClarityOfMainMessage);

                        if (String.IsNullOrEmpty(reviewInfo.Mechanics))
                        {
                            command.Parameters.AddWithValue("@Mechanics", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Mechanics", reviewInfo.Mechanics);

                        if (String.IsNullOrEmpty(reviewInfo.WrittenDocumentComments))
                        {
                            command.Parameters.AddWithValue("@WrittenDocumentComments", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@WrittenDocumentComments", reviewInfo.WrittenDocumentComments);

                        if (String.IsNullOrEmpty(reviewInfo.SuitabilityForPresentation))
                        {
                            command.Parameters.AddWithValue("@SuitabilityForPresentation", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@SuitabilityForPresentation", reviewInfo.SuitabilityForPresentation);

                        if (String.IsNullOrEmpty(reviewInfo.PotentialInterestInTopic))
                        {
                            command.Parameters.AddWithValue("@PotentialInterestInTopic", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@PotentialInterestInTopic", reviewInfo.PotentialInterestInTopic);

                        if (String.IsNullOrEmpty(reviewInfo.PotentialForOralPresentationComments))
                        {
                            command.Parameters.AddWithValue("@PotentialForOralPresentationComments", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@PotentialForOralPresentationComments", reviewInfo.PotentialForOralPresentationComments);

                        if (String.IsNullOrEmpty(reviewInfo.OverallRating))
                        {
                            command.Parameters.AddWithValue("@OverallRating", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@OverallRating", reviewInfo.OverallRating);

                        if (String.IsNullOrEmpty(reviewInfo.OverallRatingComments))
                        {
                            command.Parameters.AddWithValue("@OverallRatingComments", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@OverallRatingComments", reviewInfo.OverallRatingComments);

                        if (String.IsNullOrEmpty(reviewInfo.ComfortLevelTopic))
                        {
                            command.Parameters.AddWithValue("@ComfortLevelTopic", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ComfortLevelTopic", reviewInfo.ComfortLevelTopic);

                        if (String.IsNullOrEmpty(reviewInfo.ComfortLevelAcceptability))
                        {
                            command.Parameters.AddWithValue("@ComfortLevelAcceptability", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@ComfortLevelAcceptability", reviewInfo.ComfortLevelAcceptability);

                        if (String.IsNullOrEmpty(reviewInfo.Complete))
                        {
                            command.Parameters.AddWithValue("@Complete", DBNull.Value);
                        }
                        else
                            command.Parameters.AddWithValue("@Complete", reviewInfo.Complete);

                        command.ExecuteNonQuery();      // execute query
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            // clear current object fields
            reviewInfo.PaperID = "";
            reviewInfo.ReviewerID = "";
            reviewInfo.AppropriatenessOfTopic = "";
            reviewInfo.TimelinessOfTopic = "";
            reviewInfo.SupportiveEvidence = "";
            reviewInfo.TechnicalQuality = "";
            reviewInfo.ScopeOfCoverage = "";
            reviewInfo.CitationOfPreviousWork = "";
            reviewInfo.Originality = "";
            reviewInfo.ContentComments = "";
            reviewInfo.OrganizationOfPaper = "";
            reviewInfo.ClarityOfMainMessage = "";
            reviewInfo.Mechanics = "";
            reviewInfo.WrittenDocumentComments = "";
            reviewInfo.SuitabilityForPresentation = "";
            reviewInfo.PotentialInterestInTopic = "";
            reviewInfo.PotentialForOralPresentationComments = "";
            reviewInfo.OverallRating = "";
            reviewInfo.OverallRatingComments = "";
            reviewInfo.ComfortLevelTopic = "";
            reviewInfo.ComfortLevelAcceptability = "";
            reviewInfo.Complete = "";

            successMessage = "Submission successful!";
            Response.Redirect("/Review/Index");
        }
    }
}