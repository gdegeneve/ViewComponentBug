using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ViewComponentBug.Models;
using ViewComponentBug.Services;

namespace ViewComponentBug.ViewComponents
{
    public class TestViewComponent : ViewComponent
    {
        private readonly ILogger<TestViewComponent> _Logger;
        private readonly IScopeService Svc;

        public TestViewComponent(IScopeService svc, ILogger<TestViewComponent> logger)
        {
            _Logger = logger;
            Svc = svc;
        }

        public IViewComponentResult Invoke(TestModel model)
        {
            //Simulate high workload
            Thread.Sleep(1000);
            model.TestGuid2 = Svc.GuidTest;
            return View(model);
        }
    }
}