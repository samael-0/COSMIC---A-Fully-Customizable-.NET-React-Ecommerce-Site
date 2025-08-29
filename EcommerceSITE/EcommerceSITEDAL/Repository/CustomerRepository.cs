using EcommerceSITEDAL.DataAccess;
using EcommerceSITEDAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ISqlDataAccess _db;

        public CustomerRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int>GetCartByUserId(int userId)
        {
            string sql = @"select CartId from cart where UserId = @userid";
            var parameter = new { userId };
            var result = await _db.GetData<int, dynamic>(sql, parameter);
            return result.FirstOrDefault();
        }

        public async Task CreateCart(int userId)
        {


            var cartid =  await GetCartByUserId(userId);
            if (cartid == 0)
            {

                string sql = @"INSERT INTO Cart (UserId)
            VALUES (@userid);";
                var parameter = new { userid = userId };
                await _db.SaveData(sql, parameter);
            }

        }


        public async Task AddItemstoCart(CartItems cartitems)
        {
            string sql = @"insert into CartItems(CartId, ProductId, Quantity,PriceAtTime) values(@cartid, @productid, @quantity,@priceattime);";
            var parameter = new CartItems
            {   
                CartId = cartitems.CartId,
                ProductId = cartitems.ProductId,
                Quantity = cartitems.Quantity,
                PriceAtTime = cartitems.PriceAtTime,


            };

            await _db.SaveData(sql, parameter);

        }

    }
}
