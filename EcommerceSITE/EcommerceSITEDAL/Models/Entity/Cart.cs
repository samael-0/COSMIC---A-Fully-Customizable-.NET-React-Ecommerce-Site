using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Models.Entity
{
    public class Cart
    {
        public int CartId { get; set; }

        // Foreign key to User
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property for CartItems
        public ICollection<CartItems> CartItems { get; set; }
    }
}
