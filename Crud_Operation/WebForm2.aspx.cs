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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
            // Adapter is used to fetch data from database
            MySqlDataAdapter da = new MySqlDataAdapter("select * from Studinfo", con);
            DataTable dt = new DataTable();
            // To fill the data from da to dt
            da.Fill(dt);
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

        }

        protected void button_Click(object sender, EventArgs e)
        {
            string Name = Request.Form["txtname"];
            string PRN = Request.Form["txtprn"];
            string College = Request.Form["txtcollege"];

            HttpWebRequest request = WebRequest.Create("http://testdomain.ecssofttech.com/PhP/Studinfo.php?Name=" + Name + "&PRN=" + PRN + "&College=" + College + "") as HttpWebRequest;
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

        protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtnDelete")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());  //To delete which peerticular row 

                //Delete Using ID
                HttpWebRequest request = WebRequest.Create("http://testdomain.ecssofttech.com/PhP/Studdelete.php?ID=" + id + "") as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                WebHeaderCollection header = response.Headers;
                string responseText = null;
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                }
                if (responseText == "Delete Successfull")
                {
                    Response.Write("<script>alert('Delete successful')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Delete not successful')</script>");
                }

                // This is to show the content from database
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                // Adapter is used to fetch data from database
                MySqlDataAdapter da = new MySqlDataAdapter("select * from Studinfo", con);
                DataTable dt = new DataTable();
                // To fill the data from da to dt
                da.Fill(dt);
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }
            //for Update
            if (e.CommandName == "linkbtnEdit")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("Edit_form.aspx?id="+id);

            }
        }
    }
}