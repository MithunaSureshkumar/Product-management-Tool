using EcommerceApp.Entities;
using EcommerceApp.Repository;

namespace EcommerceApp.Services
{
    public class ProductService
    {

        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void AddAttributeValue(ProductAttributeValue pav)
        {
            _productRepository.AddAttributeValue(pav);
        }

        public void UpdateAttributeValue(ProductAttributeValue pav)
        {
            _productRepository.UpdateAttributeValue(pav);
        }
    }
}
