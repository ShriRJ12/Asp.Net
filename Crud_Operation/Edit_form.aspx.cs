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
    public partial class Edit_form : System.Web.UI.Page
    {
        public int id;
        public string Servervalue1=String.Empty;
        public string Servervalue2= String.Empty;
        public string Servervalue3 = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            id = Convert.ToInt32(Request.QueryString["ID"].ToString());
            // This is to show the content from database
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
            // Adapter is used to fetch data from database
            MySqlDataAdapter da = new MySqlDataAdapter("select Name,PRN,College from Studinfo where ID='"+id+"'",con);
            DataTable dt = new DataTable();
            // To fill the data from da to dt
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                txtname.Text = dt.Rows[0][0].ToString();
                txtprn.Text = dt.Rows[0][1].ToString();
                txtcollege.Text = dt.Rows[0][2].ToString();

                string Servervalue1 = txtname.Text;
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
            string Name = Request.Form["txtname"];
            string PRN = Request.Form["txtprn"];
            string College = Request.Form["txtcollege"];

            id = Convert.ToInt32(Request.QueryString["ID"].ToString());

            HttpWebRequest request = WebRequest.Create("http://testdomain.ecssofttech.com/PhP/Update_Info.php?Name=" + Name + "&PRN=" + PRN + "&College=" +College + "&ID=" + id + "") as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();

            WebHeaderCollection header = response.Headers;
            string responseText = null;
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
            if (responseText == "Update Successfull")
            {
                Response.Write("<script>alert('Registration Success')</script>");
            }
            else
            {
                Response.Write("<script>alert('Insert not successful')</script>");
            }
            Response.Redirect("WebForm2.aspx");
        }
    }
}