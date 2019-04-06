using System;
using System.Collections.Generic;
using System.Text;

namespace TestModule
{
    public struct ProcessorInput
    {
        public string text { get; set; }
        public double number { get; set; }
        public DateTime dateTime { get; set; }
    }
    public struct ProcessorResult
    {
        public ProcessorResult(string text, double number, DateTime dateTime)
        {
            this.text = $"Returned from CSharp: {text}, {number}, {dateTime}";
            this.number = number + 1000_000;
            this.dateTime = dateTime;
        }
        public string text { get;  }
        public double number { get;  }
        public DateTime dateTime { get;  }
    }
}
