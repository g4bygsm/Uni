using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoWayList list = new TwoWayList();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddFirst(5);


            Console.WriteLine("Normal:");
            list.Print();
            
            list.AddBetween(10, 15);

            Console.WriteLine("Normal:");
            list.Print();

            Console.WriteLine("Reverse:");
            list.PrintReverse();

            Console.WriteLine("\nRemove element 5:");
            list.Remove(5);

            Console.WriteLine("Normal:");
            list.Print();

            Console.WriteLine("Reverse:");
            list.PrintReverse();
        }
    }

    class TwoWayList
    {
        class Element
        {
            public int Data;
            public Element Next;
            public Element Prev;

            public Element(int data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Element first;
        private Element last;

        public TwoWayList()
        {
            first = null;
            last = null;
        }

        public void AddBetween(int before, int data)
        {
            Element current = first;

            while (current != null)
            {
                if (current.Data == before)
                {
                    Element newElement = new Element(data);

                    newElement.Next = current.Next;
                    newElement.Prev = current;

                    if (current.Next != null)
                    {
                        current.Next.Prev = newElement;
                    }
                    else
                    {
                        last = newElement;
                    }

                    current.Next = newElement;

                    return;
                }
                current = current.Next;
            }
        }

        public void AddFirst(int data)
        {
            Element newElement = new Element(data);

            if (first == null)
            {
                first = last = newElement;
            }
            else
            {
                newElement.Next = first;
                first.Prev = newElement;
                first = newElement;
            }
        }

        public void AddLast(int data)
        {
            Element newElement = new Element(data);

            if (first == null)
            {
                first = last = newElement;
            }
            else
            {
                last.Next = newElement;
                newElement.Prev = last;
                last = newElement;
            }
        }

        public bool Remove(int data)
        {
            Element current = first;

            while (current != null)
            {
                if (current.Data == data)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        first = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        last = current.Prev;
                    }

                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Print()
        {
            Element current = first;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void PrintReverse()
        {
            Element current = last;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Prev;
            }
            Console.WriteLine();
        }
    }
}