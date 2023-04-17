using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video_Library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult CreateCategory()
        {
            return View();
        }
        public IActionResult ShowCategory()
        {
            return View();
        }
        public IActionResult DeleteCategory()
        {
            return View();
        }
        public IActionResult UpdateCategory()
        {
            return View();
        }
    }
}
