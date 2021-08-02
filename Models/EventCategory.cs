using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EventCategory()
        {

        }
        public EventCategory(string name)
        {
            Name = name;
        }
    }
}
