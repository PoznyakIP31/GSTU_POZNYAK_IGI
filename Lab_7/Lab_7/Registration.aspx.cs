using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_7
{
    public partial class Registration : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;
        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> db = new Dictionary<string, string>();
            SqlCommand getUsersCredCmd = new SqlCommand("SELECT [Login],[Password] FROM [Users]", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await getUsersCredCmd.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    db.Add(Convert.ToString(sqlReader["Login"]), Convert.ToString(sqlReader["Password"]));
                }
            }
            catch { }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
            if(!db.Keys.Contains(TextBox1.Text))
            {
                SqlCommand regUser = new SqlCommand("INSERT INTO [Users] (Login, Password)VALUES(@Login, @Password)",sqlConnection);
                regUser.Parameters.AddWithValue("Login", TextBox1.Text);
                regUser.Parameters.AddWithValue("Password", TextBox2.Text);
                await regUser.ExecuteNonQueryAsync();
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                string script = "alert('Такой логин уже есть');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
    }
}