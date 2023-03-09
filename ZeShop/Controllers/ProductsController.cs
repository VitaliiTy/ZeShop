using Microsoft.AspNetCore.Mvc;
using ZeShop.Models;

namespace ZeShop.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(GlobalVariables.Products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = GlobalVariables.Products.Find(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                if (product.Name == null || product.Amount == null || product.Price == null)
                {
                    return BadRequest("Missing required params");
                }

                product.Id = GlobalVariables.Products.Count + 1;
                GlobalVariables.Products.Add(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Patch(Product product)
        {
            try
            {
                var productExisting = GlobalVariables.Products.Find(x => x.Id == product.Id);
                if (productExisting == null)
                {
                    return BadRequest("Product don't exist");
                }
                if (product.Name != null)
                {
                    productExisting.Name = product.Name;
                }   
                if (product.Name != null)
                {
                    productExisting.Amount = product.Amount;
                }   
                if (product.Name != null)
                {
                    productExisting.Price = product.Price;
                }  

                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                GlobalVariables.Products.RemoveAll(x => x.Id == id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}