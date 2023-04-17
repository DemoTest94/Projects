using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video_Library.Models;
using Video_Library.Areas.Admin.Models.ViewModel;

namespace Video_Library.Areas.Admin.Controllers
{
    public class ShowController : Controller
    {
        private ApplicationDbContext context;
        public ShowController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var user = context.Users.ToList();
            return View(user);
        }
    }
}
