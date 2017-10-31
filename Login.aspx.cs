using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Sampleapp2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from UserregData where Username = ' "+ LoginUsername.Text + " ' ";
                SqlCommand cmd = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();

                if(temp == 1)
                {
                    conn.Open();
                    string checkPassword = " select Password from UserregData where Username = ' " + LoginUsername.Text + " ' ";
                    SqlCommand passwordCmd = new SqlCommand(checkPassword, conn);
                    string password = passwordCmd.ExecuteScalar().ToString().Replace(" ","");
                        if(password == LoginPassword.Text)
                        {
                        Session["New"] = LoginUsername.Text;
                        Response.Write("Password is CORRECT ........");
                        }
                        else
                        {
                        Response.Write("Password is INCORRECT.....!!");
                        }

                    conn.Close();
                }
                else
                {
                    Response.Write("Username is not present...!!");
                }
            
            
        }
    }
}