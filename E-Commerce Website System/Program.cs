using E_Commerce_Website_System.Models;
using Microsoft.EntityFrameworkCore;

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

        public static void AddCategory() // 02 Add category
        {
            Console.WriteLine("\n=== Add New Category ===");

            Console.Write("Enter Category Name: ");
            string categoryName = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Category category = new Category
            {
                categoryName = categoryName,
                description = string.IsNullOrWhiteSpace(description) ? null : description
            };

            context.Categories.Add(category);
            context.SaveChanges();

            Console.WriteLine($"Category added successfully. ID: {category.categoryId}");
        }

        public static void AddNewProduct() //03 Add a New Product to a Category
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

        public static void PlaceOrder() //04 Place an Order
        {
            Console.WriteLine("\n=== Place New Order ===");

            Console.WriteLine("\nUsers:");

            foreach (User user in context.Users.ToList())
            {
                Console.WriteLine($"{user.userId} - {user.fullName}");
            }

            Console.Write("\nEnter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Shipping Address: ");
            string shippingAddress = Console.ReadLine();

            Console.Write("Enter Payment Method: ");
            string paymentMethod = Console.ReadLine();

            Order order = new Order
            {
                userId = userId,
                orderDate = DateTime.Now,
                totalAmount = 0,
                status = "Pending",
                shippingAddress = shippingAddress,
                paymentMethod = paymentMethod
            };

            context.Orders.Add(order);
            context.SaveChanges();

            string choice = "y";

            while (choice.ToLower() == "y")
            {
                Console.WriteLine("\nAvailable Products:");

                foreach (Product product01 in context.Products.Where(p => p.isAvailable && p.stockQuantity > 0).ToList())
                {
                    Console.WriteLine($"{product01.productId} - {product01.productName} - {product01.price}");
                }

                Console.Write("\nEnter Product ID: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Product product = context.Products.FirstOrDefault(p => p.productId == productId);

                if (product == null)
                {
                    Console.WriteLine("Product Not Found.");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity > product.stockQuantity)
                {
                    Console.WriteLine("Not enough stock.");
                    continue;
                }

                OrderProduct orderProduct = new OrderProduct
                {
                    orderId = order.orderId,
                    productId = product.productId,
                    quantity = quantity
                };

                context.OrderProducts.Add(orderProduct);

                order.totalAmount += product.price * quantity;

                product.stockQuantity -= quantity;

                Console.Write("\nAdd another product? (y/n): ");
                choice = Console.ReadLine();
            }

            context.SaveChanges();

            Console.WriteLine($"Order placed successfully. Order ID: {order.orderId}");
        }

        public static void WriteProductReview() //05 Write a Product Review
        {
            Console.WriteLine("\n=== Write Product Review ===");

            Console.WriteLine("\nAvailable Users:");

            foreach (User user in context.Users.ToList())
            {
                Console.WriteLine($"{user.userId} - {user.fullName}");
            }

            Console.WriteLine("\nAvailable Products:");

            foreach (Product product02 in context.Products.ToList())
            {
                Console.WriteLine($"{product02.productId} - {product02.productName}");
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

        public static void UpdateProductPriceAndAvailability() //06 Update Product Price and Availability
        {
            Console.WriteLine("\n=== Update Product ===");

            Console.WriteLine("\nAvailable Products:");

            foreach (Product product03 in context.Products.ToList())
            {
                Console.WriteLine($"{product03.productId} - {product03.productName} - {product03.price}");
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

        public static void CancelOrder() //07 Cancel an Order
        {
            Console.WriteLine("\n=== Cancel Order ===");

            Console.Write("Enter Order ID: ");
            int orderId = Convert.ToInt32(Console.ReadLine());

            Order order = context.Orders.FirstOrDefault(o => o.orderId == orderId);

            if (order == null)
            {
                Console.WriteLine("Order Not Found.");
                return;
            }

            List<OrderProduct> orderProducts = context.OrderProducts.Where(op => op.orderId == orderId)
                                                                    .ToList();

            foreach (OrderProduct item in orderProducts)
            {
                Product product = context.Products.FirstOrDefault(p => p.productId == item.productId);

                if (product != null)
                {
                    product.stockQuantity += item.quantity;
                }
            }

            order.status = "Cancelled";

            context.SaveChanges();

            Console.WriteLine("Order cancelled successfully.");
        }

        public static void DeleteReview() //08 Delete a Review
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

        public static void ViewAllProducts() //09 View All Products
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

        public static void FilterProducts() //10 Filter Products by Category and Price Range 
        {
            Console.WriteLine("\n=== Filter Products ===");

            Console.Write("Enter Category ID: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            //select price rang (between max and min)
            Console.Write("Enter Minimum Price: ");
            decimal minPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Maximum Price: ");
            decimal maxPrice = Convert.ToDecimal(Console.ReadLine());

            List<Product> products = context.Products.Where(p => p.categoryId == categoryId &&
                                                                 p.price >= minPrice &&
                                                                 p.price <= maxPrice)
                                                     .OrderBy(p => p.price)
                                                     .ToList();

            foreach (Product product in products)
            {
                Console.WriteLine($"{product.productId} - {product.productName} - {product.price}");
            }
        }

        public static void GetCategoryWithProducts() //11 Get Category with All Its Products (Include)
        {
            Console.WriteLine("\n=== Category Details ===");

            Console.Write("Enter Category ID: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Category category = context.Categories.Include(c => c.categoryProducts) // relationship between (category & Products) => incude()
                                                  .FirstOrDefault(c => c.categoryId == categoryId);

            if (category == null)
            {
                Console.WriteLine("Category Not Found.");
                return;
            }

            Console.WriteLine($"\nCategory: {category.categoryName}");
            Console.WriteLine($"Description: {category.description}");

            Console.WriteLine("\nProducts:");

            foreach (Product product in category.categoryProducts)
            {
                Console.WriteLine($"{product.productId} - {product.productName} - {product.price}");
            }
        }

        public static void ViewOrderHistory() //12 View Order History with Full Details (ThenInclude)
        {
            Console.WriteLine("\n=== Order History ===");

            Console.Write("Enter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            User user = context.Users.Include(u => u.userOrders)
                                     .ThenInclude(o => o.orderProducts)
                                     .ThenInclude(op => op.product)
                                     .FirstOrDefault(u => u.userId == userId);

            if (user == null)
            {
                Console.WriteLine("User Not Found.");
                return;
            }

            foreach (Order order in user.userOrders)
            {
                Console.WriteLine($"\nOrder ID: {order.orderId}");
                Console.WriteLine($"Date: {order.orderDate}");
                Console.WriteLine($"Status: {order.status}");
                Console.WriteLine($"Total: {order.totalAmount}");

                foreach (OrderProduct item in order.orderProducts)
                {
                    Console.WriteLine($"{item.product.productName} - Qty: {item.quantity}");
                }
            }
        }

        public static void ProductSummaryReport() //13 Product Summary Report (Projection + Lazy Loading)
        {
            Console.WriteLine("\n=== Product Summary Report ===");

            var products = context.Products.Select(p => new
                                           {
                                                   p.productName,
                                                   Category = p.productCategory.categoryName,
                                                   ReviewCount = p.productReviews.Count(),
                                                   AverageRating = p.productReviews.Any()
                                                                 ? p.productReviews.Average(r => r.rating): 0,
                                                                   p.stockQuantity
                                           })
                                           .ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"\nProduct Name : {product.productName}");
                Console.WriteLine($"Category       : {product.Category}");
                Console.WriteLine($"Reviews        : {product.ReviewCount}");
                Console.WriteLine($"Average Rate   : {product.AverageRating:F1}");
                Console.WriteLine($"Stock          : {product.stockQuantity}");
            }

            Console.WriteLine("\n========== Lazy Loading Demo ==========");

            Product firstProduct = context.Products.FirstOrDefault();

            if (firstProduct == null)
            {
                Console.WriteLine("No Products Found.");
                return;
            }

            Console.WriteLine($"Product: {firstProduct.productName}");

            Console.WriteLine("\nLoading Reviews...");

            foreach (Review review in firstProduct.productReviews)
            {
                Console.WriteLine($"{review.reviewUser.fullName} - Rating: {review.rating}");

                if (!string.IsNullOrWhiteSpace(review.comment))
                {
                    Console.WriteLine($"Comment: {review.comment}");
                }
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
                Console.WriteLine(" 2  - Add category");
                Console.WriteLine(" 3  - Add a New Product");
                Console.WriteLine(" 4  - Place an Order");
                Console.WriteLine(" 5  - Write a Product Review");
                Console.WriteLine(" 6  - Update Product Price and Availability");
                Console.WriteLine(" 7  - Cancel an Order");
                Console.WriteLine(" 8  - Delete a Review");
                Console.WriteLine(" 9  - View All Products");
                Console.WriteLine(" 10 - Filter Products");
                Console.WriteLine(" 11 - Get Category With Products");
                Console.WriteLine(" 12 - View Order History");
                Console.WriteLine(" 13 - Product Summary Report");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: RegisterUser(); break;
                    case 2: AddCategory(); break;
                    case 3: AddNewProduct(); break;
                    case 4: PlaceOrder(); break;
                    case 5: WriteProductReview(); break;
                    case 6: UpdateProductPriceAndAvailability(); break;
                    case 7: CancelOrder(); break;
                    case 8: DeleteReview(); break;
                    case 9: ViewAllProducts(); break;
                    case 10: FilterProducts(); break;
                    case 11: GetCategoryWithProducts(); break;
                    case 12: ViewOrderHistory(); break;
                    case 13: ProductSummaryReport(); break;
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
