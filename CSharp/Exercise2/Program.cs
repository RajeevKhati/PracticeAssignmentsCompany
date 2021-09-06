using System;

namespace Exercise2
{
    class Program
    {
        class Temp
        {
            public int i { get; set; }

            public Temp(int i)
            {
                this.i = i;
            }
        }
        static void Main(string[] args)
        {
            //Value types
            int vt1 = 10;
            int vt2 = 10;
            int vt3 = vt1;

            //objects/Reference types
            Temp o1 = new Temp(10);
            Temp o2 = new Temp(10);
            Temp o3 = o1;

            //string objects
            /*
             * ****IMPORTANT ***
             * String are immutable and has concept of string pool.
             * if two strings are initialised with same content, they will point to the same object in memory.
             * Example:-string a = "test"; will make a string object in string pool, now suppose if we do string b = "test";
             * As "test" object is already present in string pool, b will also point to it and will not make a new object.
            */
            string s1 = "test";
            string s2 = "test";//s1 and s2 points to same objects.
            string s3 = "test1".Substring(0, 4); //although s3 also has value "test", but as it derived from substring method, s3 will point to a new object in memory which has same value "test"
            object s4 = s3;



            //*****==*****
            Console.WriteLine("== Results :\n");

            //Value types
            // in case of value types double equals operator compares the values
            Console.WriteLine(vt1==vt2);// True because vt1 and vt2 both has value 10.
            Console.WriteLine(vt1==vt3);// True because vt2 and vt3 both has value 10.

            //Reference types
            //in case of reference type == operator compares whether reference variables are pointing to the same object or not
            Console.WriteLine(o1==o2); //False because o1 and o2 are pointing to different objects in heap.
            Console.WriteLine(o1==o3); //True because o1 and o3 are pointing to same object.

            //reference types which has == overloaded
            //string class has == operator overloaded which compares the value.
            Console.WriteLine(s1 == s2);//True because s1, s2 both has value "test"
            Console.WriteLine(s1 == s3);//True because s1, s3 both has value "test"
            Console.WriteLine(s1 == s4);//Here as s4 is an object type, so default implementation of == operator is being called which compares the reference and as s1 and s4 are pointing to different objects we get False here.




            //*****Object.Equals()*****
            /* 
             * Object.Equals() method is static method in object class. 
             * Suppose x and y are two objects.
             * Now if we call Object.Equals(x,y), internally it will call x.Equals(y).
             * But before calling x.Equals(y) it checks whether x is null or not.
             * So whenever you suspect that one of the objects can be null use Object.Equals(), otherwise x.Equals(y) will work.
             * x.Equals(y) method compares if two reference variables are pointing to the same object in memory, but this method can be overriden for value comparisons.
             ***IMPORTANT:- In discussion below, we will only talk about x.Equals(y) method and not Object.Equals() method.***
            */
            Console.WriteLine("\nObject.Equals() Results :\n");

            //Value types
            /*
             * All structs i.e. value types inherits System.ValueTypes.
             * System.ValueTypes overrides Equals() method to check for value comparison.
             * Example:- Suppose a and b are value types,so a.Equals(b) will return true if both values are same.
            */
            Console.WriteLine(Object.Equals(vt1, vt2));//True because vt1, vt2 both values are 10.
            Console.WriteLine(Object.Equals(vt1, vt3));//True because vt1, vt3 both values are 10.

            //Reference types
            //As our Temp class does not override Equals method, so System.Object class Equals() method will be called which compares if reference are pointing to same objector not.
            Console.WriteLine(Object.Equals(o1, o2));//False as o1 and o2 refers to different objects.
            Console.WriteLine(Object.Equals(o1, o3));//True as o1, o3 refers to same object.

            //reference types which has .Equals overriden
            /*
             * Object.String class overrides Equals method for value comparison.
            */

            //below 3 output are True because s1, s2, s3, s4 has value "test"
            Console.WriteLine(Object.Equals(s1, s2));
            Console.WriteLine(Object.Equals(s1, s3));
            Console.WriteLine(Object.Equals(s1, s4));




            //*****Object.ReferenceEquals()*****
            //This method compares only the reference of objects i.e. if it is pointing to same object or not.
            Console.WriteLine("\nObject.ReferenceEquals() Results :\n");

            //Value types
            /*
             * Object.ReferenceEquals() method expect parameters to be reference types.
             * So if we pass value types as parameters, boxing of those value types will happen which will convert those to objects which will reside in heap at different place.
             * Example:- even if we pass Object.ReferenceEquals(10,10); it will give false, as both parameters will be boxed in inside 2 different objects at different memory location.
            */

            //Value types will always give False.
            Console.WriteLine(Object.ReferenceEquals(vt1, vt2));
            Console.WriteLine(Object.ReferenceEquals(vt1, vt2));

            //Reference types
            Console.WriteLine(Object.ReferenceEquals(o1, o2));//False as o1,o2 points to different objects.
            Console.WriteLine(Object.ReferenceEquals(o1, o3));//True as o1,o3 points to same objects.

            //string behaviour
            Console.WriteLine(Object.ReferenceEquals(s1, s2));//True as s1,s2 points to same objects due to string immutability
            Console.WriteLine(Object.ReferenceEquals(s1, s3));//False as s1, s3 points to different objects.(Explained when initialised them)
            Console.WriteLine(Object.ReferenceEquals(s1, s4));//False as s1, s4 points to different objects.
        }
    }
}
