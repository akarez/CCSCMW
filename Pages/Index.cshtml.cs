using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace SWE.Pages
{
    public class IndexModel : PageModel
    {
        public UserInfo user = new UserInfo();
        public String em;
        public String message = "";
        protected String pass;
        public String connectionString = "Data Source=LAPTOP-HABJI64G;Initial Catalog=CPMS;Integrated Security=True";

        public void OnGet()
        {

        }
        public void OnPost()
        {
            try
            {
                em = Request.Form["email"];
                pass = Request.Form["password"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String authorQuery = "SELECT AuthorID FROM Author WHERE EmailAddress= '" + em + "' AND Password= '" + pass + "'";
                    string reviewerQuery = "SELECT ReviewerID, Active FROM Reviewer WHERE EmailAddress= '" + em + "' AND Password= '" + pass + "'";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlAdapter.SelectCommand = new SqlCommand(authorQuery, connection);
                    DataTable dt = new DataTable();

                    sqlAdapter.Fill(dt);
                    // Check if author
                    if (dt.Rows.Count > 0)
                    {
                        user.id = dt.Rows[0][0].ToString();
                        user.email = em;
                        Response.Redirect("/Home/Home");
                    }
                    // Check if reviewer
                    else if (dt.Rows.Count == 0)
                    {
                        dt.Clear();
                        sqlAdapter.SelectCommand = new SqlCommand(reviewerQuery, connection);
                        sqlAdapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            if (dt.Rows[0][2].ToString() == "False")
                            {
                                message = "Account is not active Please contact Admin";
                                return;
                            }
                            else
                            {
                                user.id = dt.Rows[0][0].ToString();
                                user.email = em;
                                Response.Redirect("/Reviews/review");
                            }
                        }
                        else
                        {
                            message = "Invalid Credentials";

                        }
                    }


                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}

public class UserInfo
{
    public string id;
    public string email;
}