using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CxApi.Models;

namespace CxApi.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        // GET api/hello
        [HttpGet]
        public JsonResult Get()
        {
            var response = new HelloResponse
            {
                Prompt = "Hello Dr. Who?" 
            };

            return Json(response);
        }

        // GET api/hello/world
        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            var response = new HelloResponse
            {
                Prompt = String.Format("Hello {0}!", name) 
            };

            return Json(response);
        }
    }
}
