using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Website_System.Models
{
    public class OrderProduct
    {
        /*
        Note:This M:N relationship carries the attribute 'quantity' (int, required, range 1-999). Think
        carefully about how to represent this in your ERD and how to convert it when you
        implement the C# models — a many-to-many relationship with an extra attribute requires
        special handling
        **********************************************************************************************
        Important — the Order-Product relationship: You noticed in Section 3 that the Order-Product
        relationship is many-to-many and carries an extra attribute (quantity). A many-to-many relationship
        with its own attribute cannot be represented with just two classes and a navigation property alone.
        Think about what you need to add to handle this correctly in your Models/ folder — this is your decision
        to make
        **********************************************************************************************
        */
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderProductId { get; set; } // System Generated

        [ForeignKey("order")]
        public int orderId { get; set; } // Foreign Key

        [ForeignKey("product")]
        public int productId { get; set; } // Foreign Key

        [Required]
        [Range(1, 999)]
        public int quantity { get; set; } // User Input

        // Navigation Properties

        public Order order { get; set; }

        public Product product { get; set; }
    }
}
