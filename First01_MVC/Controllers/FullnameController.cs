using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace First01_MVC.Controllers
{
    [Route("api/[controller]")]
    public class FullnameController : Controller
    {
        [HttpGet]
        public ActionResult GetFullname(string name)
        {
           if(name == null || name.Length == 0)
            {
                return BadRequest("Vui long nhap lai");
            }
            string mess = "";
            string[] catchuoi = name.Split(" ");
            string regexName = "[A-Z]{1}[a-z]{1,}";
            foreach (var i in catchuoi)
            {
                if (Regex.IsMatch(i,regexName))
                {
                    mess = "Valid Name" + name;
                }
                else
                {
                    mess = "InValid Name";
                    return Ok(mess);
                }
            }
            return Ok(mess);
        }
    }
}
