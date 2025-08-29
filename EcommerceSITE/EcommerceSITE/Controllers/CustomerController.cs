using EcommerceSITEDAL.Models.Entity;
using EcommerceSITEDAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceSITE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly AdminService _adminservice;

        public CustomerController(AdminService adminservice)
        {
            _adminservice = adminservice;
        }

        [HttpPost("AddtoCart")]
        [Authorize]
        public async Task<IActionResult> AddtoCart(int productId,int quantity,decimal price)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            int userId = int.Parse(userIdClaim.Value);

            var cartid = await _adminservice.GetCartidByuid(userId);
            if (cartid == 0) { 
                 await _adminservice.CreateNewCart(userId);
                var cartidget = await _adminservice.GetCartidByuid(userId);
                var cart = new CartItems
                {
                    CartId = cartidget,
                    ProductId = productId,
                    Quantity = quantity,
                    PriceAtTime = price,


                };
                await _adminservice.AddItemstoCart(cart);

            }
            else
            {
                var newcartid = await _adminservice.GetCartidByuid(userId);
                var cart = new CartItems
                {
                    CartId = newcartid,
                    ProductId = productId,
                    Quantity= quantity,
                    PriceAtTime = price,


                };
                await _adminservice.AddItemstoCart(cart);

            }

            return Ok("Product added Succesfully");

        }


        [HttpGet("gettotalproducts")]
        public async Task<IActionResult> GetTotalProducts()
        {
            var totalproducts = await _adminservice.GetTotalProducts();
            return Ok(totalproducts);  // returns 200 OK with the total products value
        }

        [HttpGet("getAllproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var allproducts = await _adminservice.GetAllProducts();
            return Ok(allproducts);
        }

        [HttpGet("getproductfromId/{id}")]
        public async Task<IActionResult> GetProductfromId(int id)
        {
            var product = await _adminservice.GetProductfromId(id);
            return Ok(product);
        }



    }
}
