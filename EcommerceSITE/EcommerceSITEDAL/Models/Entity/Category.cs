using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Models.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }  
        public DateTime CreatedAt { get; set; } 
    }
}
