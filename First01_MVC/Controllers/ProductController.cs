using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace First01_MVC.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            //1- Get Data
            //2- return
            var result = productService.GetProducts().ToList();

            return Ok(result);
        }
        [HttpGet("Max")]
        public ActionResult GetMax()
        {
            List<Product> products = productService.GetProducts().ToList();
            Product maxTemp = products[0];
            for (int i = 1; i < products.Count; i++)
            {
                if (products[i].Id > maxTemp.Id)
                {
                    maxTemp = products[i];
                }
            }

            return Ok(maxTemp);
        }
        [HttpGet("MaxSecond")]
        public ActionResult GetMaxSecond()
        {
            List<Product> products = productService.GetProducts().ToList();
            Product maxTemp = products[0];
            for (int i = 1; i < products.Count; i++)
            {
                if(products[i].Id > maxTemp.Id)
                {
                    maxTemp = products[i];
                }
            }
            Product maxTempSecond = products[0];
            for (int i = 1; i < products.Count; i++)
            {
                if(products[i].Id > maxTempSecond.Id && products[i].Id != maxTemp.Id)
                {
                    maxTempSecond = products[i];
                }
            }
            return Ok(maxTempSecond);
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody]Product product)
        {
            // 1- Check validate
            // 2- Service Add
            // 3- Service SaveChange
            // 4- return ok
            try
            {
                if (product.Name == null || product.Code == null || product.Name.Length == 0 || product.Code.Length == 0)
                {
                    return BadRequest("Please try again!");
                    //return StatusCode(400, "Please try again!");
                }
                productService.AddProduct(product);
                productService.SaveChange();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
        // Delete Update Get by id
        [HttpPut]
        public ActionResult UpdateProduct([FromBody]Product product)
        {
            try
            {
                if (product.Name == null || product.Code == null || product.Name.Length == 0 || product.Code.Length == 0)
                {
                    return StatusCode(400, "Please try again!!!");
                }
                productService.UpdateProduct(product);
                productService.SaveChange();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);

            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var product = productService.GetById(id);
                if(product == null)
                {
                    return NotFound();
                }
                productService.DeleteProduct(product);
                productService.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
               var product = productService.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);

            }
        }


    }
}
