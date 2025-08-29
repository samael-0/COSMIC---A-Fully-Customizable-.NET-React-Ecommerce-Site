using EcommerceSITEDAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Repository
{
    public interface IProductRepository
    {

        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task AddCategory(Category category);
        Task AddProducts(Products products);
        Task<int> GetTotalProducts();
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductfromId(int productid);
    }
}
