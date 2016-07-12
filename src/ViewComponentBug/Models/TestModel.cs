using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ViewComponentBug.Models
{
    public class TestModel
    {
        public string Name { get; set; } = "";

        public string TestGuid1 { get; set; }

        public string TestGuid2 { get; set; }

        public TestModel()
        {
        }
    }
}