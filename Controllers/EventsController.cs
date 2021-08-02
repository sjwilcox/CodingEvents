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
    public class EventsController : Controller
    {
        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            
            List<Event> events = context.Events.ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type = addEventViewModel.Type
                    
                };
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/Events");
            }
            return View(addEventViewModel);
            
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event updateInfo = context.Events.Find(eventId);
            ViewBag.title = "Edit Event " + updateInfo.Name + "(id = " + updateInfo.Id + ")";
            ViewBag.eventinfo = updateInfo;
            
            return View();
        }
        [HttpPost]
        [Route("/Events/Edit/")]
        public IActionResult SubmitEditEventFrom(int eventId,string name, string description) 
        {
            Event updateEvent = context.Events.Find(eventId);
            if(eventId == updateEvent.Id)
            {
                updateEvent.Name = name;
                updateEvent.Description = description;
            }
            context.SaveChanges();

            return Redirect("/Events/");
        }
    }
}
