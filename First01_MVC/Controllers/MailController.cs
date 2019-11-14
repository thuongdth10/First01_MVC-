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
    public class MailController : Controller
    {
       //[HttpGet]
       //public ActionResult GetMail(string mail)
       // {
       //     if (mail == null || mail.Length == 0)
       //     {
       //         return BadRequest("Vui long nhap mail");
       //     }
       //         string mailRegex = "[a-zA-Z0-9]{1,}@[a-z]{1,}.[a-z]{1,}";
       //     string mess = "";
       //     // kt mail hay k
       //     if(Regex.IsMatch(mail, mailRegex, RegexOptions.IgnoreCase))
       //     {
       //         //kt xem co phai mail gg k
       //         if(mail.Contains("@gmail.com"))
       //         {
       //             int pos = -1;
       //            for(int i =0; i < mail.Length; i++)
       //             {
       //               if(mail[i] == '@')
       //                 {
       //                     pos = i;
       //                 }  
       //             }
       //             mess = "Hello " + mail.Substring(0,pos);
       //         }
       //         else
       //         {
       //             mess = "day ko phai mail gg";
       //         }
       //     }
       //     else 
       //     {
       //         mess = "Khoong hop le";
       //     }


       //     return Ok(mess);
          
       // }
        [HttpGet]
        public ActionResult GetMail1(string email)
        {
            if(email== null || email.Length == 0)
            {
                return BadRequest("Vui long nhap lai"); 
            }
            string mess = "";
            string regexMail = "[a-zA-Z0-9]{1,}@[a-z]{1,}.[a-z]{1,}";
            if(Regex.IsMatch(email, regexMail, RegexOptions.IgnoreCase))
            {
                if (email.Contains("@gmail.com"))
                {
                    int pos = -1;
                    for(int i = 0; i < email.Length; i++)
                    {
                      if(email[i] == '@'){
                            pos = i;
                        }
                    }
                    mess = "Day la mail he thong" + email.Substring(0, pos);
                }
            }
            else
            {
                mess = "Khong hop le";
            }
            return Ok(mess);
        }
    }
}
