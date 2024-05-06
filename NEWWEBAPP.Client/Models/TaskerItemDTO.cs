using System.ComponentModel.DataAnnotations;

namespace NEWWEBAPP.Client.Models

{
    public class TaskerItemDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Every task must have a Name")]
        public string? Name { get; set; }

        public bool IsComplete { get; set; }

    }
}
