using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SundSalgBackend.Data;
using SundSalgBackend.Models;
using SundSalgBackend.Models.DataTransferObjects;
using AutoMapper;
using SundSalgBackend.Contracts;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SundSalgBackend.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ProductController(IRepositoryManager repository, IMapper mapper, IdentityContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

                //var claims = User.Claims;
                var products = _repository.Product.GetAllProducts(trackchanges: false);
                var productResult = _mapper.Map<IEnumerable<ProductDto>>(products);

                return Ok(productResult);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> ProductDetails(int id)
        {
            var product = _repository.Product.GetProductById(id, trackChanges: false);
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            product.Picture = "";
            _repository.Product.CreateProduct(product);

            return Ok();
        }
        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _repository.Product.UpdateProduct(product);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _repository.Product.GetProductById(id, trackChanges: false);
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _repository.Product.DeleteProduct(product);

            return Ok();
        }
    }
}
