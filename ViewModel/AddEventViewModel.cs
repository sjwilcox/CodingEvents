using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModel
{
    public class AddEventViewModel 
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,MinimumLength =2, ErrorMessage ="Name must be between 2 and 50 characters")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage ="Please add a message.")]
        [Required(ErrorMessage ="Please enter a description for your event.")]
        public string Description { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "Cannot be blank")]
        public string EventLocation { get; set; }
        [Range(0, 100000)]
        [Required]
        public int AttendeesTotal { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public bool Reigster { get { return true; } }
        [Compare("Register")]
        public bool IsTrue { get { return true; } }
    }
}
