using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Processor.GetTest(new ProcessorInput { dateTime = DateTime.Now, number = 345, text = "Calling from test" });
        }
    }
}
