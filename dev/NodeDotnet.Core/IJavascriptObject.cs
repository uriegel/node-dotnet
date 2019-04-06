using System;
using System.Collections.Generic;
using System.Text;

namespace NodeDotnet.Core
{
    public interface IJavascriptObject
    {
        object Execute(string method, object payload);
    }
}
