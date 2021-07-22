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
        
        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());
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
                    EventLocation = addEventViewModel.EventLocation,
                    AttendeesTotal = addEventViewModel.AttendeesTotal,
                    ContactEmail = addEventViewModel.ContactEmail
                    
                };
                EventData.Add(newEvent);
                return Redirect("/Events/");
            }
            return View(addEventViewModel);
            
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event updateInfo = EventData.GetById(eventId);
            ViewBag.title = "Edit Event " + updateInfo.Name + "(id = " + updateInfo.Id + ")";
            ViewBag.eventinfo = updateInfo;
            
            return View();
        }
        [HttpPost]
        [Route("/Events/Edit/")]
        public IActionResult SubmitEditEventFrom(int eventId,string name, string description) 
        {
            Event updateEvent = EventData.GetById(eventId);
            if(eventId == updateEvent.Id)
            {
                updateEvent.Name = name;
                updateEvent.Description = description;
            }
            
            return Redirect("/Events/");
        }
    }
}
