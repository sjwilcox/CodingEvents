using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Data
{
    public class EventData
    {
        //store data
        private static Dictionary<int,Event> Events = new Dictionary<int, Event>();
        //retrieve events
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }
        //add events
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }
        //remove events
        public static void Remove(int id)
        {
            Events.Remove(id);
        }
        //retrieve single event
        public static Event GetById(int id)
        {
            return Events[id];
        }
    }
}
