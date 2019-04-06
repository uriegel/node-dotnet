using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Threading;
using NodeDotnet.Core;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Threading.Tasks;

namespace NodeDotnet
{
    public class Bridge
    {
        [DllImport("user32.dll")]
        static extern int MessageBox(IntPtr hWnd, string text, string caption, int type);

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static string Initialize([MarshalAs(UnmanagedType.LPWStr)] string assemblyName)
        {
            try
            {
                // TODO: in managedBridge, read all assemblies in root (TestModule) and add those to tpaList
                // TODO: return MethodInfos as json to calling javascript. Create javascript classes in C++
                // TODO: At the moment create d.ts file manually
                // TODO: Constructor of C++-Proxy -> Invoke new Object in TestModule

                //MessageBox(IntPtr.Zero, "Haha", "Huhu", 0);
                assembly = Assembly.Load(assemblyName);
                var methodInfos = from n in assembly.GetExportedTypes()
                                  where n.GetCustomAttribute(typeof(JavascriptObjectAttribute)) != null
                                  from m in n.GetMethods()
                                  where m.GetCustomAttribute(typeof(JavascriptMethodAttribute)) != null
                                  select new Method(m);

                var nichts = methodInfos.Count();
                                    

                //objectInfos = objectTypes.ToDictionary(m => m.Name, m => new ObjectInfo(m));
                //var classes = objectInfos.ToArray().Select(n => new JSClass(n.Key, n.Value.Methods.Values));
                //var seri = new DataContractJsonSerializer(typeof(JSClass[]));
                //var ms = new MemoryStream();
                //seri.WriteObject(ms, classes.ToArray());
                //ms.Capacity = (int)ms.Length;
                //var buff = ms.GetBuffer();
                //var result = Encoding.UTF8.GetString(buff);

                return "result";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public static void ConstructObject(int objectId, [MarshalAs(UnmanagedType.LPWStr)] string name)
        {
            //var info = objectInfos[name];
            //var t = assembly.GetType(info.FullName);
            //var o = Activator.CreateInstance(t);
            //objects[objectId] = new ObjectHolder(o, info);
        }

        //public static void DeleteObject(int objectId)
        //    => objects.Remove(objectId);

        static object InternalExecute(int objectId, string method, byte[] payload)
        {
//            var info = objects[objectId];
  //          var methodInfo = info.Info.Methods[method];
            var position = 0;

            object GetParameter(Parameter parameterInfo)
            {
                switch (parameterInfo.Type)
                {
                    case ParameterType.Number:
                        switch (parameterInfo.NumberType)
                        {
                            case NumberType.Int:
                                return ReadInt(payload, ref position);
                            case NumberType.Double:
                                ReadInt(payload, ref position);
                                return 9.9;
                            default:
                                return null;
                        }
                    case ParameterType.String:
                        return ReadString(payload, ref position);
                    case ParameterType.Date:
                        return DateTime.Now;
                    default:
                        return null;
                }
            }

            //var parameters = methodInfo.Parameters.Select(n => GetParameter(n)).ToArray();
            //return methodInfo.Info.Invoke(info.Object, parameters);
            return "";
        }

        static int ReadInt(byte[] payload, ref int position)
        {
            var length = BitConverter.ToInt32(payload, position);
            position += 4;
            var result = BitConverter.ToInt32(payload, position);
            position += length;
            return result;
        }

        static string ReadString(byte[] payload, ref int position)
        {
            var length = BitConverter.ToInt32(payload, position);
            position += 4;
            var result = Encoding.Unicode.GetString(payload, position, length);
            position += length;
            return result;
        }

        static Assembly assembly;
    }
}
