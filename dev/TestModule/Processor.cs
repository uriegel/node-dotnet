using NodeDotnet.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestModule
{
    [JavascriptObject]
    public class Processor 
    {
        [JavascriptMethod]
        public static ProcessorResult GetTest(ProcessorInput input)
            => new ProcessorResult(input.text, input.number, input.dateTime);

        [JavascriptMethod]
        public static StringResult GetResult()
            => new StringResult("The result");

        public int Noop() => 9;

        public static string Execute(string method, string payload)
            => "returned from C#: " + payload; 
    }
}
