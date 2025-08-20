namespace EcommerceApp.Entities
{
    public class AttributeEntity


    {
        public int AttributeId { get; set; }
        public int CategoryId { get; set; }
        public string AttributeName { get; set; }

        public string DataType { get; set; }   // e.g., varchar, int, decimal
        public bool IsRequired { get; set; }   // true if mandatory, false otherwise
    }
}
