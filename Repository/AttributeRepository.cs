using EcommerceApp.DBUtil;
using EcommerceApp.Entities;

using System.Data.SqlClient;

namespace EcommerceApp.Repository
{
    public class AttributeRepository
    {
        public List<AttributeEntity> GetAll()
        {
            var attributes = new List<AttributeEntity>();
            string query = "SELECT AttributeId, Name FROM Attributes";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attributes.Add(new AttributeEntity
                        {
                            AttributeId = reader.GetInt32(0),
                            AttributeName = reader.GetString(1)
                        });
                    }
                }
            }
            return attributes;
        }

        public AttributeEntity GetById(int id)
        {
            AttributeEntity attribute = null;
            string query = "SELECT AttributeId, Name FROM Attributes WHERE AttributeId=@Id";

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
                            attribute = new AttributeEntity
                            {
                                AttributeId = reader.GetInt32(0),
                                AttributeName = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return attribute;
        }

        public void Add(AttributeEntity attribute)
        {
            string query = "INSERT INTO Attributes (Name) VALUES (@Name)";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", attribute.AttributeName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(AttributeEntity attribute)
        {
            string query = "UPDATE Attributes SET Name=@Name WHERE AttributeId=@Id";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", attribute.AttributeName);
                    cmd.Parameters.AddWithValue("@Id", attribute.AttributeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Attributes WHERE AttributeId=@Id";
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
