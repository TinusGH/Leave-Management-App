using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace LeaveManagement
{
    public partial class LeaveStatus : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=TINUS\SQLEXPRESS;Initial Catalog=LeaveManagement;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            display_data();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE dbo.Leave SET Status = '" + StatusSelection.Text + "' WHERE id =" + Convert.ToInt32(oldid.Text) + "";
            cmd.ExecuteNonQuery();


            lblmessage.Text = "Updated Successfully!";

            display_data();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM dbo.Leave WHERE id = '" + Convert.ToInt32(oldid.Text) + "'";
            cmd.ExecuteNonQuery();


            lblmessage.Text = "Deleted!";

            display_data();

        }

        public void display_data()
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM dbo.Leave WHERE  Type='" + TypeSelection.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            gv.DataSource = dt;
            gv.DataBind();
        }



        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}