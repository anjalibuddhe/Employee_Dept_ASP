using EmployeecurdASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace EmployeecurdASP.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IConfiguration configuration;
        private DeparmentCurd crud;
        // GET: Department

        public DepartmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new DeparmentCurd(this.configuration);
        }

        public ActionResult Index()
        {
            var model=crud.GetDepartments();
            return View(model);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                int result=crud.AddDepartment(department);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
           var result = crud.GetDepartmentById(id);
            return View(result);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            try
            {
                int result = crud.UpdateDepartment(department);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var result = crud.GetDepartmentById(id);
            return View(result);
        }

        // POST: Department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteDepartment(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
