﻿using mvc_codefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_codefirst.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext myContext = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            var list = myContext.Roles.ToList();
            return View(list);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {
            try
            {
                // TODO: Add insert logic here
                myContext.Roles.Add(role);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Role role)
        {
            try
            {
                // TODO: Add update logic here
                var edit = myContext.Roles.Find(id);
                edit.Name = role.Name;
                myContext.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Role role)
        {
            try
            {
                // TODO: Add delete logic here
                var delete = myContext.Roles.Find(id);
                myContext.Roles.Remove(delete);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
