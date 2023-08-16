using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProjectMVC.Models;

namespace MiniProjectMVC.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        public ActionResult Index()
        {
            List<Student> lstEmp = Student.GetAllStudents();
            return View(lstEmp);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            Student obj = Student.GetSingleStudent(id.Value);
            return View(obj);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student obj)
        {
            try
            {
                Student.InsertStudent(obj);
                ViewBag.message = "Successfully Added!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Student obj = Student.GetSingleStudent(id.Value);
            return View(obj);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student obj)
        {
            try
            {
                Student.UpdateStudent(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Student obj = Student.GetSingleStudent(id.Value);
            return View(obj);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student obj)
        {
            try
            {
                Student.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
