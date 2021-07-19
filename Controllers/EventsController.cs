﻿using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private List<Event> Events = new List<Event>();
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = Events;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add/")]
        public IActionResult NewEvent(string name)
        {
            Events.Add(new Event(name));
            return Redirect("/Events/");
        }
    }
}
