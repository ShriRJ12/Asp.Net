using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using System.Text;


namespace CRUD_Operation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this is to show the content from database
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
            //Adapter is fetch data from database
            MySqlDataAdapter da = new MySqlDataAdapter("select * from Weboffline", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        protected void button_Click1(object sender, EventArgs e)
        {
            string Name = Request.Form["txtname"];
            string Password = Request.Form["txtpass"];
            string Address = Request.Form["txtadd"];

            HttpWebRequest request = WebRequest.Create("http://testdomain.ecssofttech.com/PhP/Insert_Web.php?Name=" + Name + "&Password=" + Password + "&Address=" + Address + "") as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();

            WebHeaderCollection header = response.Headers;
            string responseText = null;
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
            if (responseText == "Registration Success")
            {
                Response.Write("<script>alert('Registration Success')</script>");
            }
            else
            {
                Response.Write("<script>alert('Insert not successful')</script>");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        
        
        }
    }
}