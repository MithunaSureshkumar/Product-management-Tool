using EcommerceApp.DBUtil;
using EcommerceApp.Entities;
using System.Data.SqlClient;

namespace EcommerceApp.Repository
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            var categories = new List<Category>();
            string query = "SELECT CategoryId, Name FROM Categories";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = reader.GetInt32(0),
                            CategoryName = reader.GetString(1)
                        });
                    }
                }
            }
            return categories;
        }

        public Category GetById(int id)
        {
            Category category = null;
            string query = "SELECT CategoryId, Name FROM Categories WHERE CategoryId = @Id";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = new Category
                            {
                                CategoryId = reader.GetInt32(0),
                                CategoryName = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return category;
        }

        public void Add(Category category)
        {
            string query = "INSERT INTO Categories (Name) VALUES (@Name)";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", category.CategoryName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Category category)
        {
            string query = "UPDATE Categories SET Name=@Name WHERE CategoryId=@Id";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", category.CategoryName);
                    cmd.Parameters.AddWithValue("@Id", category.CategoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Categories WHERE CategoryId=@Id";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


        
