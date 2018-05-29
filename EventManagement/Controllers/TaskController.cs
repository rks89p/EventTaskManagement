using EventManagement.Models;
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  

  
namespace EventManagement.Controllers
{
    public class TaskController : Controller
    {

        TaskDetailClient taskDetailClient = new TaskDetailClient();
        public ActionResult Index()
        {
            ViewBag.listCustomers = taskDetailClient.findAll();

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(TaskDetails taskDetails)
        {
            taskDetailClient.Create(taskDetails);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            taskDetailClient.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TaskDetails CVM = new TaskDetails();
            CVM = taskDetailClient.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(TaskDetails taskDetails)
        {
            taskDetails.CreatedDate = DateTime.Now;
            taskDetailClient.Edit(taskDetails);
            return RedirectToAction("Index");
        }
    }

}