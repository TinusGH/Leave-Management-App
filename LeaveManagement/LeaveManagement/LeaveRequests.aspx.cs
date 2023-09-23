using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveManagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=TINUS\SQLEXPRESS;Initial Catalog=LeaveManagement;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();

            //Name.text = Session["User"];

            display_data();

        }
             
        //public string User { get { return (string)Session["User"]; } }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
        SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO dbo.Leave Values ('" + FromDate.SelectedDate + "','" + ToDate.SelectedDate + "','" + "Pending" + "','" + Name.Text + "', '" + Type.Text + "', '" + Reason.Text + "'); SELECT CAST(scope_identity() AS int);";
            cmd.ExecuteNonQuery();

            FromDate.SelectedDate = DateTime.UtcNow;
            ToDate.SelectedDate = DateTime.UtcNow; ;
            Name.Text = "";
            Type.Text = "";
            Reason.Text = "";

            lblmessage.Text = "Request Created!";

            display_data();
        }
       

        public void display_data()
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM dbo.Leave WHERE Name ='" + Name.Text + "'";
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

        protected void FromDateCustVal_Validate(object source, ServerValidateEventArgs e)
        {
            if (FromDate.SelectedDate == null || FromDate.SelectedDate < DateTime.Now)
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        protected void UntilDateCustVal_Validate(object source, ServerValidateEventArgs e)
        {
            if (ToDate.SelectedDate == null || ToDate.SelectedDate < FromDate.SelectedDate)
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        protected void Name_DataBinding(object sender, EventArgs e)
        {

        }
    }

}