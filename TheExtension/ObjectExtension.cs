using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheExtension
{
    public static class ObjectExtension
    {
        public static bool If<T>(this Object x, Predicate<T> predicate)
            where T : class
        {
            if (typeof(T).IsAssignableFrom(x.GetType()))
            {
                return predicate((T)x);
            }
            else
            {
                throw new ArgumentException(string.Format("The parameter should be instance of {0}", typeof(T).ToString()));
 
            }
            

        }

        public static void IfThen<T>(this Object x, Predicate<T> predicate, Action<T> action)
        {
            if (typeof(T).IsAssignableFrom(x.GetType()))
            {
                if (predicate((T)x))
                {
                    action((T)x);
                }
            }
 
        }
    }

    public static class TypeExtension
    {
        //public static bool If<T>(this Type x, Predicate<T> predicate,Object obj)
        //{
        //    if (x.IsAssignableFrom(obj.GetType()))
        //    {
        //        return predicate((T)obj);
        //    }
        //    else
        //    {
        //        throw new ArgumentException(string.Format("The parameter should be instance of {0}",x));
        //    }
            
        //}
    }
}
