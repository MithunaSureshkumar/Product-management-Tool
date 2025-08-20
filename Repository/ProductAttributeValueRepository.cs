using EcommerceApp.DBUtil;
using EcommerceApp.Entities;

using System.Data.SqlClient;

namespace EcommerceApp.Repository
{
    public class ProductAttributeValueRepository
    {


        public List<ProductAttributeValue> GetAll()
        {
            var values = new List<ProductAttributeValue>();
            string query = "SELECT ValueId, ProductAttributeId, Value FROM ProductAttributeValues";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        values.Add(new ProductAttributeValue
                        {
                            ProductId = reader.GetInt32(0),
                            AttributeId = reader.GetInt32(1),
                            AttributeValue = reader.GetString(2)
                        });
                    }
                }
            }
            return values;
        }

        public ProductAttributeValue GetById(int id)
        {
            ProductAttributeValue value = null;
            string query = "SELECT ValueId, ProductAttributeId, Value FROM ProductAttributeValues WHERE ValueId=@Id";

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
                            value = new ProductAttributeValue
                            {
                                ProductId = reader.GetInt32(0),
                                AttributeId = reader.GetInt32(1),
                                AttributeValue = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return value;
        }

        public void Add(ProductAttributeValue value)
        {
            string query = "INSERT INTO ProductAttributeValues (ProductAttributeId, Value) VALUES (@ProductAttributeId, @Value)";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductAttributeId", value.AttributeId);
                    cmd.Parameters.AddWithValue("@Value", value.AttributeValue);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(ProductAttributeValue value)
        {
            string query = "UPDATE ProductAttributeValues SET ProductAttributeId=@ProductAttributeId, Value=@Value WHERE ValueId=@Id";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductAttributeId", value.AttributeId);
                    cmd.Parameters.AddWithValue("@Value", value.AttributeValue);
                    cmd.Parameters.AddWithValue("@Id", value.ProductId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM ProductAttributeValues WHERE ValueId=@Id";
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
