using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video_Library.Areas.Admin.Models;

namespace Video_Library.Models
{
    public class ApplicationDbContext:IdentityDbContext<IdentityCustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
    }
}
