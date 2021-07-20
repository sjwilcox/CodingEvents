using CodingEvents.Data;
using CodingEvents.Models;
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
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add/")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/Events/");
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
