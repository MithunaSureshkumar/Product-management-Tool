using EcommerceApp.Entities;
using EcommerceApp.Repository;

namespace EcommerceApp.Services
{
    public class AttributeService
    {
        private readonly AttributeRepository _attributeRepository;

        public AttributeService()
        {
            _attributeRepository = new AttributeRepository();
        }

        public void AddAttribute(AttributeEntity attribute)
        {
            _attributeRepository.Add(attribute);
        }

        public List<AttributeEntity> GetAttributesByCategory(int categoryId)
        {
            return _attributeRepository.GetById(categoryId);
        }
    }
}
