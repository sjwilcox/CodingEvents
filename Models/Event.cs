using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        public String Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string EventLocation { get; set; }
        public int AttendeesTotal { get; set; }
        public bool Register { get { return true; } }
        public int Id { get; }
        private static int nextId = 1;

        public Event()
        {
            Id = nextId;
            nextId++;
        }

        public Event(string name, string description, string contactEmail, string eventLocation, int attendees) : this()
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            EventLocation = eventLocation;
            AttendeesTotal = attendees;
            
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
