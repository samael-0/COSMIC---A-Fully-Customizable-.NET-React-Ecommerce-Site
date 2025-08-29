using EcommerceSITEDAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Repository
{
    public interface ICustomerRepository
    {

        Task<int> GetCartByUserId(int userId);
        Task CreateCart(int userId);

        Task AddItemstoCart(CartItems cartitems);
    }
}
