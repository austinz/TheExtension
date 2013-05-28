using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheExtension
{
    public static class ObjectExtension
    {
        [Obsolete]
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

        [Obsolete]
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

        public static void IfThen<T>(this T x, Predicate<T> predicate, Action<T> action)
        {
            if (predicate(x))
            {
                action(x);
            }
        }

        public static Ttarget If<Tsource, Ttarget>(this Tsource x, Predicate<Tsource> predicate, Func<Tsource, Ttarget> ifFunc, Func<Tsource, Ttarget> elseFunc = null)
            where Ttarget : class
        {
            if (predicate(x))
            {
                return ifFunc(x);
            }
            else
            {
                if (elseFunc != null)
                {
                    return elseFunc(x);
                }
                else
                {
                    if (typeof(Ttarget).IsAssignableFrom(typeof(Tsource)))
                    {
                        return x as Ttarget;
                    }

                    return null;

                }
            }


        }

        //有存在价值么？
        //public static Ttarget Else<Tsource, Ttarget>(this Tsource x, Func<Tsource, Ttarget> func)
        //    where Ttarget : class
        //{
        //    return func(x);
        //}

    }

}
