using System;
using System.Collections;
using System.Collections.Generic;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IEnumerable<string> obj = new MyEnumerable();

            foreach (var item in obj)
                Console.WriteLine(item);

            foreach (var item in obj)
                Console.WriteLine("2: " + item);

            Console.ReadKey();
        }

        class MyEnumerable : IEnumerable<string>
        {
            readonly string[] fruit = { "Apples", "Pears", "Rhubarb" };

            Enumerator GetEnumerator()
            {
                return new Enumerator(this);
            }

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            struct Enumerator : IEnumerator<string>
            {
                int index;
                MyEnumerable myEnumerable;

                internal Enumerator(MyEnumerable myEnumerable)
                {
                    this.myEnumerable = myEnumerable;
                    index = 0;
                    Current = myEnumerable.fruit[index];
                }

                public string Current { get; private set; }

                object IEnumerator.Current => Current;

                public void Dispose()
                {

                }

                public bool MoveNext()
                {
                    if (index < myEnumerable.fruit.Length)
                    {
                        Current = myEnumerable.fruit[index];
                        index++;
                        return true;
                    }

                    return false;
                }

                public void Reset()
                {
                    index = 0;
                }
            }
        }
    }
}