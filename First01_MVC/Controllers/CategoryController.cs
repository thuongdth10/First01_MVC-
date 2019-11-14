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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult GetCategories()
        {
            var result = categoryService.GetCategories().ToList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var result = categoryService.GetById(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                if (category.Name == null || category.Name.Length == 0)
                {
                    return BadRequest("Name can not blank!");
                }
                categoryService.AddCategory(category);
                categoryService.SaveChange();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
        [HttpPut]
        public ActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                if(category.Name == null || category.Name.Length == 0)
                {
                    return BadRequest("Name can not blank!");
                }
                categoryService.UpdateCategory(category);
                categoryService.SaveChange();
                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                var result = categoryService.GetById(id);
                if(result == null)
                {
                    return NotFound();
                }
                categoryService.DeleteCategory(result);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
