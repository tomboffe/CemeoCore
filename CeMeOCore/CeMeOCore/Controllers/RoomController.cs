﻿using CeMeOCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CeMeOCore.Controllers
{
    public class RoomController : Controller
    {
        private CeMeoContext _db = new CeMeoContext();
        static readonly Room repository = new Room();

        public ActionResult Index()
        {
            ViewBag.Title = "Overview of all the meeting rooms.";
            var model = _db.Rooms;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var meetingRoom = _db.Rooms.FirstOrDefault((p) => p.RoomID == id);
            if (meetingRoom == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return View(meetingRoom);
        }

        public ActionResult Create(Room meetingRoom)
        {
            if (meetingRoom == null)
            {
                throw new ArgumentNullException("item");
            }
            _db.Rooms.Add(meetingRoom);
            _db.SaveChanges();
            return View(meetingRoom);
        }

        public ActionResult Edit(Room meetingRoom)
        {
            _db.Entry(meetingRoom).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Room meetingRoom = _db.Rooms.Find(id);
            _db.Rooms.Remove(meetingRoom);
            _db.SaveChanges();
            return View(meetingRoom);
        }
    }
}
