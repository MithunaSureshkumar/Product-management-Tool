using EcommerceApp.Entities;
using EcommerceApp.Services;

namespace EcommerceApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var categoryService = new CategoryService();
            var attributeService = new AttributeService();
            var productService = new ProductService();

            while (true)
            {
                Console.WriteLine("\n--- Product Management System ---");
                Console.WriteLine("1. View Categories");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Add Category");
                Console.WriteLine("4. Add Attribute to Category");
                Console.WriteLine("5. Add Product");
                Console.WriteLine("6. Add Attribute Value to Product");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var categories = categoryService.GetAllCategories();
                        Console.WriteLine("\n--- Categories ---");
                        foreach (var c in categories)
                        {
                            Console.WriteLine($"{c.CategoryId}. {c.CategoryName}");
                        }
                        break;

                    case "2":
                        var products = productService.GetAllProducts();
                        Console.WriteLine("\n--- Products ---");
                        foreach (var p in products)
                        {
                            Console.WriteLine($"{p.ProductId}. {p.ProductName} (CategoryId: {p.CategoryId})");
                        }
                        break;

                    case "3":
                        Console.Write("Enter new category name: ");
                        string catName = Console.ReadLine();
                        var newCategory = new Category { CategoryName = catName };
                        categoryService.AddCategory(newCategory);
                        Console.WriteLine("Category added successfully!");
                        break;

                    case "4":
                        Console.Write("Enter CategoryId: ");
                        int catId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Attribute Name: ");
                        string attrName = Console.ReadLine();
                        var attr = new AttributeEntity { CategoryId = catId, AttributeName = attrName };
                        attributeService.AddAttribute(attr);
                        Console.WriteLine("Attribute added successfully!");
                        break;

                    case "5":
                        Console.Write("Enter Product Name: ");
                        string prodName = Console.ReadLine();
                        Console.Write("Enter CategoryId: ");
                        int prodCatId = int.Parse(Console.ReadLine());
                        var prod = new Product { ProductName = prodName, CategoryId = prodCatId };
                        productService.AddProduct(prod);
                        Console.WriteLine("Product added successfully!");
                        break;

                    case "6":
                        Console.Write("Enter ProductId: ");
                        int productId = int.Parse(Console.ReadLine());
                        Console.Write("Enter AttributeId: ");
                        int attributeId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Attribute Value: ");
                        string value = Console.ReadLine();
                        var pav = new ProductAttributeValue
                        {
                            ProductId = productId,
                            AttributeId = attributeId,
                            AttributeValue = value
                        };
                        productService.AddAttributeValue(pav);
                        Console.WriteLine("Product attribute value added successfully!");
                        break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
        }
    }
}
