namespace SparseVector;

public class SparceVector
{
    public VectorElement? head;

    public VectorElement? tail;

    public int logicalLength = 0;

    public SparceVector()
    {
    }

    public SparceVector(int[] arrayOfElements)
    {
        logicalLength = arrayOfElements.Length;
        for (int i = 0; i < arrayOfElements.Length; ++i)
        {
            if (arrayOfElements[i] != 0)
            {
                if (head == null)
                {
                    head = new VectorElement(i, arrayOfElements[i]);
                    tail = head;
                    continue;
                }
                tail.Add(new VectorElement(i, arrayOfElements[i]));
                tail = tail.Next;
            }
        }
    }
    

    public int this[int name]
    {
        get
        {
            return GetValue(name);
        }
        set
        {
            ChangeValue(name, value);
        }
    }

    public void ChangeValue(int name, int value)
    {
        if (name < 0)
        {
            throw new ArgumentOutOfRangeException("Index can't be less than zero!");
        }
        if (name > tail.CellName)
        {
            tail.Add(new VectorElement(name, value));
            tail = tail.Next;
            return;
        }
        if (name < head.CellName)
        {
            var tempElmement = head;
            head = new VectorElement(name, value);
            head.Add(tempElmement);
        }
        if (IsNull())
        {
            head = new VectorElement(name, value);
            tail = head;
        }
        var currentElement = head;
        while (currentElement != null)
        {
            if (currentElement.CellName == name)
            {
                currentElement.Value = value;
                return;
            }
            else if (currentElement.CellName < name && (currentElement.Next != null && currentElement.Next.CellName > name))
            {
                var tempElement = currentElement.Next;
                var newElement = new VectorElement(name, value);
                currentElement.Add(newElement);
                newElement.Add(tempElement);
                
            }
            currentElement = currentElement.Next;
        }
    }
    public void PrintVector()
    {
        VectorElement currentElement = head;
        while (currentElement != null)
        {
            Console.WriteLine($"{currentElement.CellName} {currentElement.Value}");
            currentElement = currentElement.Next;
        }
    }

    public int GetValue(int name)
    {
        var currentElement = head;
        while (currentElement != null)
        {
            if (currentElement.CellName == name)
            {
                return currentElement.Value;
            }
            currentElement = currentElement.Next;
        }
        return 0;
    }

    public bool IsNull()
    {
        return head == null;
    }

    public class VectorElement
    {
        public int CellName = 0;

        public int Value = 0;

        public VectorElement? Next = null;

        public VectorElement? Previous = null;
        public VectorElement() 
        {
        }

        public VectorElement(int name, int value)
        {
            CellName = name;
            Value = value;
        }

        public void Add(VectorElement nextElement)
        {
            Next = nextElement;
            nextElement.Previous = this;
        }
    }
}

/*Реализовать разреженный вектор с методами сложения, вычитания, 
 * скалярного умножения и проверки на нулевой вектор. Разреженным 
 * называется вектор, который может быть очень большим, но 
 * подавляющее большинство его элементов — нули 
 * (и за счёт этого его можно — и нужно — эффективно хранить в памяти).*/