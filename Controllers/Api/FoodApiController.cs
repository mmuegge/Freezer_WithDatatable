using Freezer_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Freezer.Controllers.Api
{
    [Route("Api/FoodApi")]
    [ApiController]
    public class FoodApiController : Controller
    {
        private readonly DataContext _context;

        public FoodApiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _context.Foods.ToList() });
        }
    }
}
