using EcommerceApp.DBUtil;
using EcommerceApp.Entities;

using System.Data.SqlClient;

namespace EcommerceApp.Repository
{
    public class ProductRepository
    {
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            string query = "SELECT ProductId, Name, CategoryId, Price FROM Products";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            CategoryId = reader.GetInt32(2),
                            Price = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            Product product = null;
            string query = "SELECT ProductId, Name, CategoryId, Price FROM Products WHERE ProductId=@Id";

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
                            product = new Product
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                CategoryId = reader.GetInt32(2),
                                Price = reader.GetDecimal(3)
                            };
                        }
                    }
                }
            }
            return product;
        }

        public void Add(Product product)
        {
            string query = "INSERT INTO Products (Name, CategoryId, Price) VALUES (@Name, @CategoryId, @Price)";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", product.ProductName);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Product product)
        {
            string query = "UPDATE Products SET Name=@Name, CategoryId=@CategoryId, Price=@Price WHERE ProductId=@Id";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", product.ProductName);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Id", product.ProductId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Products WHERE ProductId=@Id";
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
