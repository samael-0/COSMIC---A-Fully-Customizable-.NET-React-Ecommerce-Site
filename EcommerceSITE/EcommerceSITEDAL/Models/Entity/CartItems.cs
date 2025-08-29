using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Models.Entity
{
    public class CartItems
    {

        public int CartItemId { get; set; }

        // Foreign key to Cart
        public int CartId { get; set; }

        // Foreign key to Product
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PriceAtTime { get; set; }

    }
}
