﻿using Microsoft.AspNetCore.Mvc;
using ZeShop.Models;

namespace ZeShop.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(GlobalVariables.Orders);
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
                var order = GlobalVariables.Orders.Find(x => x.Id == id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(List<OrderRow> orderRows)
        {
            try
            {
                if (orderRows.FirstOrDefault() == null)
                {
                    return BadRequest("Missing required params");
                }
                foreach (var item in orderRows)
                {
                    var product = GlobalVariables.Products.Find(x => x.Id == item.ProductId);
                    if (item.Amount < 1 || product == null)
                    {
                        return BadRequest("Bad values");
                    }
                    item.Product = product;
                }

                var order = new Order
                {
                    OrderRows = orderRows,
                    Id = GlobalVariables.Orders.Count + 1
                };

                GlobalVariables.Orders.Add(order);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}