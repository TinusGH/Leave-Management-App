using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveManagement
{
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=TINUS\SQLEXPRESS;Initial Catalog=LeaveManagement;Integrated Security=True");
        int i;

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            i = 0;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Employee WHERE username='" + Username.Text + "' AND password='" + Password.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 1)
            {
                Session["User"] = Username.Text;
                Response.Redirect("LeaveRequests.aspx");

            }
            else
            {
                lblmessage.Text = "Invalid username or password entered";
            }
        }
    }
}

