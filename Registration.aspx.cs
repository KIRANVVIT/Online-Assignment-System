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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            { 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string insert = "insert into UserregData (Username,Email,Password) values (@username,@email,@password)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@username", Usrnm.Text);
            cmd.Parameters.AddWithValue("@email", Mail.Text);
            cmd.Parameters.AddWithValue("@password", Pwd.Text);
            cmd.ExecuteNonQuery();
            Response.Redirect("Manager.aspx");
            conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }

        }

       
    }
}