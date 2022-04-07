using MVC_Practical;
using MVC_Practical.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_Practical.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDBContext _db;

         [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Teacher newTeacher)
        {
            _db.Teacher.Add(newTeacher);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public TeacherController(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var teachers = from t in _db.Teacher
                           select t;
            if(!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(s => s.Name.Contains(searchString));
            }

            return View(await teachers.ToListAsync());

        }

        [HttpGet]
        public IActionResult Edit(int teacherid)
        {
            var teacherobj = _db.Teacher.Find(teacherid);
            return View(teacherobj);

        }

        [HttpPost]
        public IActionResult Edit(Teacher updatedvaluesobj)
        {
            _db.Teacher.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

         public IActionResult Delete(int teacherid) {
            var teacherObj = _db.Teacher.Find(teacherid);
            return View(teacherObj);
        }


        [HttpPost]
        public IActionResult DeletePost(int id) {
            var teacherObj = _db.Teacher.Find(id);

            if (ModelState.IsValid)
            {
                _db.Teacher.Remove(teacherObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherObj);
        }

    }
}
