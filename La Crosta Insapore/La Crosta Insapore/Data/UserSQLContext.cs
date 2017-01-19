using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using La_Crosta_Insapore.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace La_Crosta_Insapore.Data
{
    public class UserSQLContext : IUserContext
    {
        public UserModel Login(string email, string password)
        {
            UserModel user = null;
            string query = @"SELECT Id, Name, Role
                             FROM [User]
                             WHERE Email = @Email AND Password = @Password;";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = email,
                            Role = (UserRole)reader.GetInt32(2)
                        };
                    }
                }
            }
            return user;
        }

        public int Register(UserModel user)
        {
            int id = 0;
            string query = @"INSERT INTO [User]
                             (Name, Email, Password, Role)
                             VALUES(@Name, @Email, @Password, @Role);";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", UserRole.CUSTOMER);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    id = (int)cmd.ExecuteScalar();
                }
            }
            return id;
        }

        public bool Update(UserModel user)
        {
            bool success = false;
            string query = @"UPDATE [User]
                             SET Role = @Role
                             WHERE Id = @Id;";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    success = cmd.ExecuteNonQuery() > 0;
                }
            }
            return success;
        }
    }
}