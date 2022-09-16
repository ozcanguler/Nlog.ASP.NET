using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services.Data
{
       public class SecurityDAO
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            internal bool FindByUser(UserModel user)
            {

                bool success = false;
                string querystring = "Select * From dbo.Users where username=@Username And password=@Password";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(querystring, connection);

                    command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                    command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            success = true;
                        }
                        else
                        {
                            return success;
                        }
                        reader.Close();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                return success;
            }
        }
    }