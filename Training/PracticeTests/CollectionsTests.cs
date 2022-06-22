using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Training.BDD.PracticeTests
{
    public class CollectionsTests
    {
        [Test]
        public void CollectionsTypes()
        {
            // Array

            Console.WriteLine("-------------------ARRAY-----------------------------------------");

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            numbers[3] = 9;
            foreach(int i in numbers)
            {
                Console.WriteLine($"The value of array element is: {i}");
            }

            Array.Reverse(numbers);
            foreach(int i in numbers)
            {
                Console.WriteLine($"The value of array element after reversing is: {i}");
            }

            Array.Sort(numbers);
            Array.Clear(numbers, 3, 3);
            foreach (int i in numbers)
            {
                Console.WriteLine($"The sorted value of array element is: {i}");
            }

            // List

            Console.WriteLine("---------------------------LIST---------------------------------");

            List<string> list = new List<string> { "3", "4", "5" };
            list.Add("1");
            list.Add("2");

            List<int> list2 = new List<int>();
            foreach(string s in list)
            {
                list2.Add(list.IndexOf(s));
            }
            Console.WriteLine(list2.Count);

            Console.WriteLine("--------------------------------------ARRAY LIST------------------------");

            // Array List
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Hi");
            arrayList.Add(35);
            arrayList.Add(10.5);

            foreach(var i in arrayList)
            {
                Console.WriteLine($"The value '{i}' is in the Index of '{arrayList.IndexOf(i)}'");
            }

            Console.WriteLine("----------------------------------DICTIONARY--------------------");

            // Dictionary

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("One", 1);
            dictionary.Add("Eleven", 11);
            dictionary.Add("One hundred and eleven", 111);

            foreach(KeyValuePair<string, int> kvp in dictionary)
            {
                Console.WriteLine($"The Key '{kvp.Key}' has the value as '{kvp.Value}'");
            }

            List<int> ListValues = dictionary.Values.ToList();

            foreach(int i in ListValues)
            {
                Console.WriteLine($"The value '{i}' is in the Index of '{ListValues.IndexOf(i)}'");
            }

            Console.WriteLine("--------------------------SORTED LIST------------------------");

            // Sorted List 

            SortedList<string, int> sortList = new SortedList<string, int>();
            sortList.Add("Ten", 10);
            sortList.Add("One", 1);
            sortList.Add("Five", 5);
            sortList.Add("Three", 3);

            foreach(KeyValuePair<string, int> skvp in sortList)
            {
                Console.WriteLine($"The Key '{skvp.Key}' has the value as '{skvp.Value}'");
            }

            // Queue

            Console.WriteLine("-------------------------QUEUE-----------------------------");

            Queue queue = new Queue();
            queue.Enqueue(10);
            queue.Enqueue("Hi");
            queue.Enqueue(30);
            queue.Dequeue();

            foreach(var q in queue)
            {
                Console.WriteLine($"The value '{q}' is in the type of {q.GetType()}");
            }

            Console.WriteLine("----------------------STACK----------------------------");

            // Stack
            Stack stack = new Stack();
            stack.Push(10);
            stack.Push("Hi");
            stack.Push(1000);

            Console.WriteLine("Next element to get removed: " + stack.Peek());
            
            stack.Pop();
            foreach (var s in stack)
            {
                Console.WriteLine($"The value '{s}' is in the type of {s.GetType()}");
            }

            Console.WriteLine("--------------------------------BIT ARRAY-----------------------------------------------------");

            //BitArray

            BitArray bitArray = new BitArray(new int[] { 100, 35, 65 });
            Console.WriteLine(bitArray.Count);
            Console.WriteLine(bitArray.Length);
            foreach (var b in bitArray)
            {
                Console.WriteLine($"The value '{b}' is in the type of {b.GetType()}");
            }

            Console.WriteLine("--------------------------------HASH TABLE-----------------------------------------------------");

            //HashTable

            Hashtable hashTable = new Hashtable();
            hashTable.Add(1, "Addy");
            hashTable.Add("Nikhitha", 35);

            foreach (DictionaryEntry  h in hashTable)
            {
                Console.WriteLine($"The Key '{h.Key}' has the value as '{h.Value}'");
            }
            Console.WriteLine("--------------------------------------------------");

        }
    }
}
