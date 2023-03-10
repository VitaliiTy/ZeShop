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

        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            try
            {
                var product = GlobalVariables.Products.Find(x => x.Id == id);
                if (product == null)
                {
                    return NotFound("Product doesn't exist");
                }
                var productRow = GlobalVariables.Basket.ProductRows.Find(x => x.ProductId == id);
                if (productRow == null)
                {
                    GlobalVariables.Basket.ProductRows.Add(new ProductRow { ProductId = id, Amount = 1, Product = product});
                }
                else
                {
                    productRow.Amount++;
                }

                return Ok(GlobalVariables.Basket);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("{id}/ChangeAmount")]
        public IActionResult AddAmount(int id, int amount)
        {
            try
            {
                var product = GlobalVariables.Products.Find(x => x.Id == id);
                if (product == null)
                {
                    return NotFound("Add product first");
                }

                GlobalVariables.Basket.ProductRows.Add(new ProductRow { ProductId = product.Id.Value, Amount = amount, Product = product });

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
