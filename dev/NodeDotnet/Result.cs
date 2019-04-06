using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NodeDotnet
{
    public struct Result
    {
        public string Type { get; }
        public Result(MethodInfo methodInfo)
        {
            Type = methodInfo.ReturnType.Name;
        }
    }
}
