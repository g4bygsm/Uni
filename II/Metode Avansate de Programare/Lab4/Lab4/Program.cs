namespace Lab4
{
    class Stack
    {
        private int[] elements;
        private int top;
        private int capacity;

        public Stack(int size)
        {
            capacity = size;
            elements = new int[capacity];
            top = -1;
        }
        public void Push(int item)
        {
            if (top == capacity - 1)
            {
                throw new StackOverflowException("full");
            }
            elements[top++] = item;
        }
        public int Pop()
        {
            return elements[top];
        }
        public bool isEmpty()
        {
            return top == -1;
        }
    }
    class Queue
    {
        private int[] elements;
        private int front;
        private int back;
        private int count;
        private int capacity;
        public Queue(int size)
        {
            capacity = size;
            elements = new int[capacity];
            front = 0;
            back = -1;
            count = 0;
        }
        public void Push(int item)
        {
            if (count == capacity)
            {
                throw new InvalidOperationException("full");
            }
            back = (back + 1) % capacity;
            elements[back] = item;
            count++;
        }
        public bool isEmpty()
        {
            return front == 0;
        }
        public int Pop()
        {
            if (isEmpty) throw new InvalidOperationException("empty");
            int item = elements[front];
            front = (front + 1) % capacity;
            count--;
            return item;
        }

    }


        class StackNoDim
        {
            private List<int> elements;

            public StackNoDim()
            {
                elements = new List<int>();
            }

            public void Push(int item)
            {
                elements.Add(item);
            }

            public int Pop()
            {
                if (isEmpty()) throw new InvalidOperationException("empty");

                int index = elements.Count - 1;
                int item = elements[index];
                elements.RemoveAt(index);

                return item;
            }

            public bool isEmpty()
            {
                return elements.Count == 0;
            }
        }

        class QueueNoDim
        {
            private List<int> elements;

            public QueueNoDim()
            {
                elements = new List<int>();
            }

            public void Push(int item)
            {
                elements.Add(item);
            }

            public int Pop()
            {
                if (isEmpty()) throw new InvalidOperationException("empty");

                int item = elements[0];
                elements.RemoveAt(0);

                return item;
            }

            public bool isEmpty()
            {
                return elements.Count == 0;
            }
        }
