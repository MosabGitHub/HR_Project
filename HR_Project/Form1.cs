using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HR_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource= await clsUserData.GetAllUsersAsync();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public class clsUserData
        {
            public static string ConnectionString = "Server=.;Database=HR_Database;User Id=sa;Password=123456;";



            public async static Task<DataTable> GetAllUsersAsync()
            {

                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {


                    string query = "select * from Employees_View";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        try
                        {
                            connection.Open();

                            using (SqlDataReader reader = await command.ExecuteReaderAsync())
                            {


                                if (reader.HasRows)

                                {
                                    dt.Load(reader);
                                }

                            }


                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }

                return dt;

            }

            public static DataTable GetAllUsers()
            {

                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {


                    string query = "select * from Employees_View";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        try
                        {
                            connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {


                                if (reader.HasRows)

                                {
                                    dt.Load(reader);
                                }

                            }


                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }

                return dt;

            }


        }

    }
}
