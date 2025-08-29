using EcommerceSITEDAL.Models.Entity;
using EcommerceSITEDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Services
{
    public class AdminService
    {

        private readonly IProductRepository _repo;
        private readonly ICustomerRepository _customerrepo;

        public AdminService(IProductRepository repo, ICustomerRepository customerrepo)
        {
            _repo = repo;
            _customerrepo = customerrepo;
        }
        public async Task<string> AddCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                return "Category name is required.";

            // Optional: Validate ParentCategoryId exists if not null
            //if (category.ParentCategoryId.HasValue)
            //{
            //    var parent = await _repo.GetById(category.ParentCategoryId.Value);
            //    if (parent == null)
            //        return "Parent category does not exist.";
            //}

            await _repo.AddCategory(category);
            return "Category added successfully.";
        }


        public async Task<string> AddProducts(Products products)
        {
            if (string.IsNullOrWhiteSpace(products.Name))
                return "Category name is required.";

            await _repo.AddProducts(products);
            return "Product added succesfully";

        }


        public async Task<int> GetCartidByuid(int userid)
        {
            int cartid = await _customerrepo.GetCartByUserId(userid);
            return cartid;
        }

        public async Task<string> AddItemstoCart(CartItems cartitems)
        {
            // Call repository method to add the item
            await _customerrepo.AddItemstoCart(cartitems);

            return "Product added successfully";
        }

        public async Task<string> CreateNewCart(int userId)
        {
            await _customerrepo.CreateCart(userId);
            return "Cart created";
        }





        public async Task<int> GetTotalProducts()
        {
            int total = await _repo.GetTotalProducts();
            return total;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var allProducts = await _repo.GetAllProducts();
            return allProducts;
        }



        public async Task<Products>GetProductfromId(int id)
        {
            var product = await _repo.GetProductfromId(id);
            return product;
        }


       

    }
}
