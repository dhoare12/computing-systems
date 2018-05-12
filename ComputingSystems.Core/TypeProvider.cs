using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputingSystems.Core
{
    public static class TypeProvider
    {
        private static readonly Dictionary<Type, Func<object>> Kernel = new Dictionary<Type, Func<object>>();

        public static T Get<T>()
        {
            var type = typeof(T);
            if (!Kernel.ContainsKey(type))
            {
                throw new Exception($"{type.Name} is not bound");
            }
            return (T) Kernel[typeof(T)]();
        }

        public static T[] GetArray<T>(int count)
        {
            return Enumerable.Range(0, count).Select(_ => Get<T>()).ToArray();
        }

        public static void Bind<T>(Func<T> func)
        {
            var type = typeof(T);
            if (Kernel.ContainsKey(type))
            {
                throw new Exception($"{type.Name} already bound!");
            }

            Kernel[type] = () => func();
        }

        public static void Clear()
        {
            Kernel.Clear();
        }
    }
}