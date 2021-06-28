using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public class TestClone1
    {
        public int id { get; set; }

        public List<TestClone1> list1 { get; set; }

        public List<TestClone2> list2 { get; } = new List<TestClone2>();

        public TestClone2 testClone2 { get; set; }
    }
}
