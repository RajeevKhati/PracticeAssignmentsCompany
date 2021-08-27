using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise13
{
    public static class ExtendedMethodsOnIEnumerable
    {
        //1. CustomAll - Should work as All operation of LINQ, with custom logic passed as delegate
        public static bool CustomAll<T>(this IEnumerable<T> list, Predicate<T> logic)
        {
            foreach(T val in list)
            {
                if (!logic(val))
                {
                    return false;
                }
            }
            return true;
        }

        //2. CustomAny - Should work as Any operation of LINQ, with custom logic passed as delegate
        public static bool CustomAny<T>(this IEnumerable<T> list, Predicate<T> logic)
        {
            foreach(T val in list)
            {
                if (logic(val))
                    return true;
            }
            return false;
        }

        //3. CustomMax - Should work as Max operation of LINQ, with custom logic passed as delegate
        public static T CustomMax<T>(this IEnumerable<T> list)
        {
            if (typeof(T).FullName.Equals("System.String"))
            {
                string maxString = list.First().ToString();
                foreach(T item in list)
                {
                    if (maxString.CompareTo(item.ToString()) == -1)
                    {
                        maxString = item.ToString();
                    }
                }

                return (T)Convert.ChangeType(maxString, typeof(T));
            }
            else 
            {
                double max = double.Parse(list.First().ToString());
                foreach (T item in list)
                {
                    if (double.Parse(item.ToString()) > max)
                    {
                        max = double.Parse(item.ToString());
                    }
                }
                return (T)Convert.ChangeType(max, typeof(T));
            }
        }

        //4. CustomMin - Should work as Min operation of LINQ, with custom logic passed as delegate
        public static T CustomMin<T>(this IEnumerable<T> list)
        {
            if (typeof(T).FullName.Equals("System.String"))
            {
                string minString = list.First().ToString();
                foreach (T item in list)
                {
                    if (minString.CompareTo(item.ToString()) == 1)
                    {
                        minString = item.ToString();
                    }
                }

                return (T)Convert.ChangeType(minString, typeof(T));
            }
            else
            {
                double min = double.Parse(list.First().ToString());
                foreach (T item in list)
                {
                    if (double.Parse(item.ToString()) < min)
                    {
                        min = double.Parse(item.ToString());
                    }
                }
                return (T)Convert.ChangeType(min, typeof(T));
            }
        }


        //5. CustomWhere - Should work as Where operation of LINQ, with custom logic passed as delegate
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> list, Predicate<T> logic)
        {
            foreach (T val in list)
            {
                if (logic(val))
                {
                    yield return val;
                }
            }
        }

        //6. CustomSelect - Should work as Select operation of LINQ, with custom logic passed as delegate
        public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> list, Func<T, TResult> logic)
        {
            foreach (T val in list)
            {
                yield return logic(val);
            }
        }


    }
}
