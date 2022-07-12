using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

/* Review Edit Page C# File */

namespace SWE.Pages.Review
{
    public class EditModel : PageModel
    {
        public ReviewInfo reviewInfo = new ReviewInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String ReviewID = Request.Query["ReviewID"];

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Review WHERE ReviewID=@ReviewID";    

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ReviewID", ReviewID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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
                            }
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
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

            try
            {
                String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Review SET PaperID=@PaperID, ReviewerID=@ReviewerID, AppropriatenessOfTopic=@AppropriatenessOfTopic, TimelinessOfTopic=@TimelinessOfTopic, SupportiveEvidence=@SupportiveEvidence, TechnicalQuality=@TechnicalQuality, " +
                        "ScopeOfCoverage=@ScopeOfCoverage, CitationOfPreviousWork=@CitationOfPreviousWork, Originality=@Originality, ContentComments=@ContentComments, OrganizationOfPaper=@OrganizationOfPaper, ClarityOfMainMessage=@ClarityOfMainMessage, Mechanics=@Mechanics, " +
                        "WrittenDocumentComments=@WrittenDocumentComments, SuitabilityForPresentation=@SuitabilityForPresentation, PotentialInterestInTopic=@PotentialInterestInTopic, PotentialForOralPresentationComments=@PotentialForOralPresentationComments, " +
                        "OverallRating=@OverallRating, OverallRatingComments=@OverallRatingComments, ComfortLevelTopic=@ComfortLevelTopic, ComfortLevelAcceptability=@ComfortLevelAcceptability, Complete=@Complete";     // select review with corresponding ID

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

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Review/Index");
        }
    }
}
