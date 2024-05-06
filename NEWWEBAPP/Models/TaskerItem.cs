using NEWWEBAPP.Client.Models;
using NEWWEBAPP.Data;
using System.ComponentModel.DataAnnotations;

namespace NEWWEBAPP.Models
{
    public class TaskerItem
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage="Every task must have a Name")]
        public string? Name { get; set; }

        public bool IsComplete { get; set; }

        [Required]
        public string? UserId { get; set; } 

        public virtual ApplicationUser? User { get; set; } //lazy loaded object, always gets user corresponding to userid we get
    }

    public static class TaskerItemExtension //static = only one instance ever (the class itself) no new objects
    {
        public static TaskerItemDTO ToDTO(this TaskerItem item) => new TaskerItemDTO
        {
            Id = item.Id,
            Name = item.Name,
            IsComplete = item.IsComplete
        };
    }

}