using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Models.Entity
{
    public class Products
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        public string ImageOne { get; set; }

        public string ImageTwo { get; set; }

        public bool IsActive {get; set;}

        public DateTime CreatedAt { get; set; }




    }
}
