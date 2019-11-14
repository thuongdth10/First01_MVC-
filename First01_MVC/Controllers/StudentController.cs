using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First01_MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace First01_MVC.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        //28/10
        //[HttpGet]
        //public ActionResult GettMessage(string username)
        //{
        //    string message;
        //    if(username == null || username.Length ==0)
        //    {
        //        message = "Vui long nhap username";
        //    }
        //    else
        //    {
        //        message = "Hello " + username;
        //    }
        //    return Ok(message);
        //}
        //static 
        static List<Student> students = new List<Student>();
        public StudentController()
        {
            if(students.Count == 0)
            {
                students.Add(new Student(1, "Hoai Thuong", true));
                
            }
        }
        [HttpGet]
        public ActionResult GetAll()
        {

            return Ok(students);
        }
        [HttpPost]
        public ActionResult CreateStudent([FromBody]Student student)
        {

            if (student.Id == 0 || student.Username == null || student.Username.Length == 0)
            {
                return BadRequest("Please try again!!!");
            }

            //
            foreach (var s in students)
            {
                if (s.Id == student.Id)
                {
                    return BadRequest("Trung Id");
                }

            }
            students.Add(student);
            return StatusCode(201);
        }
        //put sua
        //delete theo id
        [HttpPut]
        public ActionResult UpdateStudent([FromBody] Student model)
        {
            if (model.Username == null || model.Username.Length == 0)
            {
                return BadRequest("Please fill Username");
            }
            foreach (var s in students)
            {
                if (s.Id == model.Id)
                {
                    s.Username = model.Username;
                    s.Gender = model.Gender;
                    return Ok();
                }

            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            foreach (var s in students)
            {
                if (s.Id == id)
                {
                    students.Remove(s);
                    return Ok();
                }
            }
            return NotFound();

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            //Student student = null;
            foreach (var s in students)
            {
                if (s.Id == id)
                {
                    //student = new Student(s.Id, s.Username, s.Gender);
                    return Ok(s);
                }
            }
            return NotFound();
        }
  }
}
