using AutoMapper;
using FirstAPI.DataAccess.Entity;
using FirstAPI.Services.Abstract;
using FirstAPI.Services.Models;
using Microsoft.AspNetCore.Mvc;


namespace First.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
    

        public ProductsController(IProductService productService)
        {
            _productService = productService;
           
        }


          
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products =await _productService.GetAll();
           
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _productService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _productService.Create(product);
            return CreatedAtAction(nameof(GetProduct), new { id = result.Id }, result);
        }
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductModel product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _productService.Update(id, product);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async  Task<ActionResult> DeleteProduct(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.Delete(id);
            return NoContent();
            
        }
        [HttpPost]
        [Route("delete")]
        public ActionResult<List<Product>> DeleteMultiple([FromQuery]int[] ids)
        {
            return _productService.DeleteMultible(ids);

        }

    }
}
