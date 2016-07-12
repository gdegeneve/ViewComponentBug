using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentBug.Models;
using ViewComponentBug.Services;

namespace ViewComponentBug.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScopeService Svc;

        public HomeController(IScopeService svc)
        {
            Svc = svc;
        }

        public IActionResult Component(string name)
        {
            Svc.FillGuid();
            TestModel model = new TestModel();
            model.Name = name;
            model.TestGuid1 = Svc.GuidTest;
            return ViewComponent("Test", new { model = model });
        }

        public IActionResult Index()
        {
            List<TestModel> models = new List<TestModel>();
            for (int i = 0; i < 10; i++)
            {
                var model = new TestModel();
                model.Name = "Test" + i;
                models.Add(model);
            }
            return View(models);
        }

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View();
        //}
    }
}