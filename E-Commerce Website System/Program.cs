using E_Commerce_Website_System.Models;

namespace E_Commerce_Website_System
{
    public class Program
    {
        public static ECommerceContext context = new ECommerceContext();

        //==========================================================================================================================
        public static void RegisterUser() //01 Register a New User
        {
            Console.WriteLine("\n=== Register New User ===");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string passwordHash = password;

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter phone number (optional): ");
            string phone = Console.ReadLine();

            Console.Write("Enter address (optional): ");
            string address = Console.ReadLine();

            User user = new User
            {
                username = username,
                email = email,
                passwordHash = passwordHash,
                fullName = fullName,
                phoneNumber = string.IsNullOrWhiteSpace(phone) ? null : phone,
                address = string.IsNullOrWhiteSpace(address) ? null : address,
                registrationDate = DateTime.Now,
                isActive = true
            };

            context.Users.Add(user);
            context.SaveChanges();

            Console.WriteLine($"User registered successfully. Assigned ID: {user.userId}");
        }

        public static void AddNewProduct() //02 Add a New Product to a Category
        {
            Console.WriteLine("\n=== Add New Product ===");

            Console.WriteLine("\nAvailable Categories:");

            foreach (Category category in context.Categories.ToList())
            {
                Console.WriteLine($"{category.categoryId} - {category.categoryName}");
            }

            Console.Write("\nEnter Category ID: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Description (optional): ");
            string description = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Stock Quantity: ");
            int stockQuantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Image URL (optional): ");
            string imageUrl = Console.ReadLine();

            Product product = new Product
            {
                productName = productName,
                description = string.IsNullOrWhiteSpace(description) ? null : description,
                price = price,
                stockQuantity = stockQuantity,
                imageUrl = string.IsNullOrWhiteSpace(imageUrl) ? null : imageUrl,
                categoryId = categoryId,
                createdAt = DateTime.Now,
                isAvailable = true
            };

            context.Products.Add(product);
            context.SaveChanges();

            Console.WriteLine($"Product added successfully. Assigned ID: {product.productId}");
        }

        public static void WriteProductReview() //04 Write a Product Review
        {
            Console.WriteLine("\n=== Write Product Review ===");

            Console.WriteLine("\nAvailable Users:");

            foreach (User user in context.Users.ToList())
            {
                Console.WriteLine($"{user.userId} - {user.fullName}");
            }

            Console.WriteLine("\nAvailable Products:");

            foreach (Product product in context.Products.ToList())
            {
                Console.WriteLine($"{product.productId} - {product.productName}");
            }

            Console.Write("\nEnter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Rating (1-5): ");
            int rating = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Comment (optional): ");
            string comment = Console.ReadLine();

            Review review = new Review
            {
                userId = userId,
                productId = productId,
                rating = rating,
                comment = string.IsNullOrWhiteSpace(comment) ? null : comment,
                reviewDate = DateTime.Now
            };

            context.Reviews.Add(review);
            context.SaveChanges();

            Console.WriteLine($"Review added successfully. Review ID: {review.reviewId}");
        }

        public static void UpdateProductPriceAndAvailability() //05 Update Product Price and Availability
        {
            Console.WriteLine("\n=== Update Product ===");

            Console.WriteLine("\nAvailable Products:");

            foreach (Product product1 in context.Products.ToList())
            {
                Console.WriteLine($"{product1.productId} - {product1.productName} - {product1.price}");
            }

            Console.Write("\nEnter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product product = context.Products.FirstOrDefault(p => p.productId == productId);

            if (product == null)
            {
                Console.WriteLine("Product Not Found.");
                return;
            }

            Console.Write("Enter New Price: ");
            product.price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Is Product Available? (true/false): ");
            product.isAvailable = Convert.ToBoolean(Console.ReadLine());

            context.SaveChanges();

            Console.WriteLine("Product updated successfully.");
        }

        public static void DeleteReview() //07 Delete a Review
        {
            Console.WriteLine("\n=== Delete Review ===");

            Console.WriteLine("\nAvailable Reviews:");

            foreach (Review review in context.Reviews.ToList())
            {
                Console.WriteLine($"{review.reviewId} - User {review.userId} - Product {review.productId}");
            }

            Console.Write("\nEnter Review ID: ");
            int reviewId = Convert.ToInt32(Console.ReadLine());

            Review reviewDelete = context.Reviews.FirstOrDefault(r => r.reviewId == reviewId);

            if (reviewDelete == null)
            {
                Console.WriteLine("Review Not Found.");
                return;
            }

            context.Reviews.Remove(reviewDelete);

            context.SaveChanges();

            Console.WriteLine("Review deleted successfully.");
        }

        public static void ViewAllProducts() //08 View All Products
        {
            Console.WriteLine("\n=== All Products ===");

            List<Product> products = context.Products.ToList();

            foreach (Product product in products)
            {
                Console.WriteLine($"ID: {product.productId}");
                Console.WriteLine($"Name: {product.productName}");
                Console.WriteLine($"Price: {product.price}");
                Console.WriteLine($"Stock: {product.stockQuantity}");
                Console.WriteLine($"Available: {product.isAvailable}");
                Console.WriteLine("-----------------------------------");
            }
        }
        
        //==========================================================================================================================
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("        E-Commerce System");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1  - Register a New User");
                Console.WriteLine(" 2  - Add a New Product to a Category");
                Console.WriteLine(" 3  - ");
                Console.WriteLine(" 4  -  Write a Product Review");
                Console.WriteLine(" 5  -  Update Product Price and Availability");
                Console.WriteLine(" 6  - ");
                Console.WriteLine(" 7  -  Delete a Review");
                Console.WriteLine(" 8  -  View All Products");
                Console.WriteLine(" 9  - ");
                Console.WriteLine(" 10 - ");
                Console.WriteLine(" 11 - ");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: RegisterUser(); break;
                    case 2: AddNewProduct(); break;
                    //case 3: (); break;
                    case 4: WriteProductReview(); break;
                    case 5: UpdateProductPriceAndAvailability(); break;
                    //case 6: (); break;
                    case 7: DeleteReview(); break;
                    case 8: ViewAllProducts(); break;
                    //case 9: (); break;
                    //case 10: (); break;
                    //case 11: (); break;
                    case 0: exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("Goodbye!");

        }
    }
}
