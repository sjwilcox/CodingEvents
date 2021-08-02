using CodingEvents.Data;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<EventCategory> eventCat = context.EventCat.ToList();
            return View(eventCat);
        }
    }
}
