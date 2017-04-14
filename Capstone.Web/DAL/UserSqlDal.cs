using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;


namespace Capstone.Web.DAL
{
    public class UserSqlDal : IUserDAL
    {
        private readonly string databaseConnectionString;

        public UserSqlDal(string connectionString)
        {
            databaseConnectionString = connectionString;
        }

        public bool CreateUser(User newUser)
        {
            try
            {
                string sql = $"INSERT INTO users VALUES (@displayname, @password, @email);";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@displayname", newUser.DisplayName);
                    cmd.Parameters.AddWithValue("@password", newUser.Password);
                    cmd.Parameters.AddWithValue("@email", newUser.Email);


                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public bool ChangePassword(string email, string newPassword)
        {
            try
            {
                string sql = $"UPDATE users SET password = '{newPassword}' WHERE email = '{email}'";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public User GetUser(string email)
        {
            User user = null;

            try
            {
                string sql = $"SELECT TOP 1 * FROM users WHERE email = '{email}'";

                using (SqlConnection conn = new SqlConnection(databaseConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        user = new User
                        {
                            DisplayName = Convert.ToString(reader["displayname"]),
                            Password = Convert.ToString(reader["password"]),
                            Email = Convert.ToString(reader["email"])
                        };
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return user;
        }
    }
}