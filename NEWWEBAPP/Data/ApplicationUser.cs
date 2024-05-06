using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using NEWWEBAPP.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEWWEBAPP.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} at most {1} characters long.", MinimumLength = 2)]
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} at most {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName => $"{FirstName} {LastName}";

        public Guid? ImageId { get; set; }

        public virtual ImageUpload? Image { get; set; }

        public virtual ICollection<TaskerItem> TaskerItems { get; set; } = new HashSet<TaskerItem>(); //one to many relationship user can have many tasker items
        //entity framework for when we retrieve data base

    }

}