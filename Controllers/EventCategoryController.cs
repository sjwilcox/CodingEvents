using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Index()
        {
            List<EventCategory> eventCat = context.EventCat.ToList();
            return View(eventCat);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEvent = new()
                {
                    Name = addEventCategoryViewModel.Name
                };
                context.EventCat.Add(newEvent);
                context.SaveChanges();
                return Redirect("Index");
            }
            return View(addEventCategoryViewModel);
        }
    }
}
