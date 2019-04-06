using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

namespace NodeDotnet
{
    public struct Method
    {
        public string Name { get; }
        public ClassInfo? ClassInfo { get; }
        public Result? Result { get; }
        public Parameter? Parameter { get; }

        public Method(MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            ClassInfo = methodInfo.IsStatic == false ? new ClassInfo(methodInfo) as ClassInfo? : null;
            Parameter = default;
            Result = methodInfo.ReturnType != typeof(void) ? new Result(methodInfo)as Result? : null;
        }
    }
}
