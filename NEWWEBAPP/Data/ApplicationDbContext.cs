using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NEWWEBAPP.Models;

namespace NEWWEBAPP.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options) 
    {
        public virtual DbSet<ImageUpload> Images { get; set; }

        public virtual DbSet<TaskerItem> TaskerItems { get; set; }  
    }
}
