using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication23
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"];

            if (id != "")
            {

                SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lucky\source\repos\WebApplication23\WebApplication23\App_Data\Database2.mdf;Integrated Security=True");
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from sku_live where fkid = '" + id + "' and type = 'parent'";

                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    product.Text = Convert.ToString(sqlDataReader["product"]);
                }
                sqlDataReader.Close();

                SqlDataSource sqlDataSource = new SqlDataSource();
                sqlDataSource.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucky\\source\\repos\\WebApplication23\\WebApplication23\\App_Data\\Database2.mdf;Integrated Security=True";
                sqlDataSource.SelectCommand = "select * from sku_live where fkid = '" + id + "' and type = 'child'";

                varients.DataSource = sqlDataSource;
                varients.DataBind();
            }

            //SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lucky\source\repos\WebApplication23\WebApplication23\App_Data\Database2.mdf;Integrated Security=True");

            //cnn.Open();

            //SqlCommand cmd = cnn.CreateCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into Table_0 values('" + product.Text + "')";
            //cmd.ExecuteNonQuery();

            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into Table_1(fkid,Product) values(2,'" + product.Text + "')";
            //cmd.ExecuteNonQuery();

            //Response.Write("Done");
            //cnn.Close();

        }

        protected void vairent(object sender, CommandEventArgs e)
        {


            string id = Request.QueryString["id"];
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lucky\source\repos\WebApplication23\WebApplication23\App_Data\Database2.mdf;Integrated Security=True");

            cnn.Open();

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into sku_live values('" + id + "','" + product.Text + "','child')";
            cmd.ExecuteNonQuery();

          

            
            cnn.Close();




        }

        protected void tab0tab1(object sender, CommandEventArgs e)
        {

            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lucky\source\repos\WebApplication23\WebApplication23\App_Data\Database2.mdf;Integrated Security=True");

            cnn.Open();

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into sku values('"+product.Text+"')";
            cmd.ExecuteNonQuery();

            cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select TOP 1 id from sku order by id DESC";
            int id = 0;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read()) {
                 id = Convert.ToInt32(sqlDataReader["id"]);
            }

            sqlDataReader.Close();
               
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into sku_live values('" + id + "','" + product.Text + "','parent')";
            cmd.ExecuteNonQuery();

            Response.Write("Done");
            cnn.Close();

          


        }
    }
}