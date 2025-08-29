using EcommerceSITEDAL.DataAccess;
using EcommerceSITEDAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Repository
{
    public class ProductsRepository : IProductRepository
    {
        private readonly ISqlDataAccess _db;

        public ProductsRepository(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            string sql = "SELECT CategoryId, Name, Description, ParentCategoryId, CreatedAt FROM Categories";
            var parameters = new { }; 

            return await _db.GetData<Category, dynamic>(sql, parameters);
        }

        public async Task AddCategory(Category category)
        {
            string sql = @"
            INSERT INTO Categories (Name, Description, ParentCategoryId)
            VALUES (@Name, @Description, @ParentCategoryId)";

            var parameters = new
            {
                Name = category.Name,
                Description = category.Description,
                ParentCategoryId = category.ParentCategoryId
            };

            await _db.SaveData(sql, parameters);
        }
        


        public async Task AddProducts(Products products)
        {
            string sql = @"INSERT INTO Products (Name, Description, Price, Stock, CategoryId, ImageUrl, IsActive)
VALUES (@Name, @Description, @Price, @Stock, @CategoryId, @ImageUrl, @IsActive);
";

            var parameters = new
            {
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                Stock = products.Stock,
                CategoryId = products.CategoryId,
                ImageUrl = products.ImageUrl,
                IsActive = products.IsActive,


            };

             await _db.SaveData(sql, parameters);
        }

        public async Task<int> GetTotalProducts()
        {
            string sql = "select * from [dbo].[GetTotalProductsTable]()";

            var results = await _db.GetData<int, dynamic>(sql, null);
            int total = results.FirstOrDefault();  

            return total;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            string sql = "SELECT p.ProductId,p.Name,p.Description,p.Price,p.Stock,p.CategoryId,pi.ImageUrl,pi.ImageOne,pi.ImageTwo\r\nFROM Products p\r\nLEFT JOIN \r\n    ProductImages pi\r\nON \r\n    p.ProductId = pi.ProductId;";

            var allproducts = await _db.GetData<Products, dynamic>(sql, null);
            return allproducts;

            
        }



        public async Task<Products> GetProductfromId(int productid)
        {
            string sql = @"select * from products where ProductId = @productId";
            var parameter = new
            {
                 productid

            };

            var product = await _db.GetData<Products, dynamic>(sql, parameter);
            return product.FirstOrDefault();
        }

        



    }
}
