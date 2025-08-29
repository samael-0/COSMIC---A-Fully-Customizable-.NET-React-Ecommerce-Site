using EcommerceSITEDAL.Models.Entity;
using EcommerceSITEDAL.Repository;
using EcommerceSITEDAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSITE.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {

        private readonly IProductRepository _db;
        private readonly IConfiguration _config;
        private readonly AdminService _adminservice;
        public AdminPanelController(IProductRepository db, IConfiguration config, AdminService adminservice)
        {
            _db = db;
            _config = config;
            _adminservice = adminservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _db.GetAllCategoriesAsync();
            return Ok(categories);
        }

       
        [HttpPost("add")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var result = await _adminservice.AddCategory(category);

            if (result.Contains("required") || result.Contains("does not exist"))
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(Products products)
        {
            var result = await _adminservice.AddProducts(products);

            if (result.Contains("required") || result.Contains("does not exist"))
                return BadRequest(result);

            return Ok(result);
        }







    }
}
