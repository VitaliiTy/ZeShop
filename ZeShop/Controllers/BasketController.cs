using Microsoft.AspNetCore.Mvc;
using ZeShop.Models;

namespace ZeShop.Controllers
{
    public class BasketController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(GlobalVariables.Basket);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Patch(List<ProductRow> productRows)
        {
            try
            {
                foreach (var item in productRows)
                {
                    var product = GlobalVariables.Products.Find(x => x.Id == item.ProductId);
                    if (item.Amount < 1 || product == null)
                    {
                        return BadRequest("Bad values");
                    }
                    item.Product = product;
                }

                GlobalVariables.Basket.ProductRows.AddRange(productRows);

                return Ok(GlobalVariables.Basket);
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
                GlobalVariables.Basket.ProductRows.RemoveAll(x => x.Product.Id == id);

                return Ok(GlobalVariables.Basket);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
