using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AAdlBusiness
{
    public class clsUserData
    {
        public static string ConnectionString = "Server=.;Database=HR_Database;User Id=sa;Password=123456;";

      

        public async static Task<DataTable> GetAllUsersAsync()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {


                string query = @"select * from fullUserInfo_view;";

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

        public  static DataTable GetAllUsers()
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

                        using (SqlDataReader reader =  command.ExecuteReader())
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
