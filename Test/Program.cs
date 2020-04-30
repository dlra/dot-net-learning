using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Test
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
        class MyEnumerable : IEnumerable<string>, IEnumerator<string>
        {
            readonly string[] fruit = { "Apples", "Pears", "Rhubarb" };
            int index = 0;

            string _current;
            string IEnumerator<string>.Current => _current;

            object IEnumerator.Current => _current;

            void IDisposable.Dispose()
            {
                index = 0;
            }

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;
            }

            bool IEnumerator.MoveNext()
            {
                if (index < fruit.Length)
                    _current = fruit[index];

                if (index++ == fruit.Length)
                    return false;
                else
                    return true;
            }

            void IEnumerator.Reset()
            {
                index = 0;
            }
        }
    }
}
