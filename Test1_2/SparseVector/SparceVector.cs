namespace SparseVector;

public class SparceVector
{
    private VectorElement? head;

    private VectorElement? tail;

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
        if (IsNull())
        {
            head = new VectorElement(name, value);
            tail = head;
        }
        if (name > tail.CellName)
        {
            tail.Add(new VectorElement(name, value));
            tail = tail.Next;
            logicalLength = name + 1;
            return;
        }
        if (name < head.CellName)
        {
            var tempElmement = head;
            head = new VectorElement(name, value);
            head.Add(tempElmement);
        }
        var currentElement = head;
        while (currentElement != null)
        {
            if (currentElement.CellName == name)
            {
                currentElement.Value = value;
                if (value == 0)
                {
                    DeleteElement(currentElement);
                }
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

    public static SparceVector Addition(SparceVector first, SparceVector second)
    {
        var newVector = new SparceVector();
        var firstElement = first.head;
        var secondElement = second.head;
        while (firstElement != null || secondElement != null)
        {
            if (firstElement.CellName == secondElement.CellName)
            {
                newVector[firstElement.CellName] = firstElement.Value + secondElement.Value;
                firstElement = firstElement.Next;
                secondElement = secondElement.Next;
                continue;
            }
            if (firstElement.CellName > secondElement.CellName)
            {
                newVector[secondElement.CellName] = secondElement.Value;
                secondElement = secondElement.Next;
                continue;
            }
            if (secondElement.CellName > firstElement.CellName)
            {
                newVector[firstElement.CellName] = firstElement.Value;
                firstElement = firstElement.Next;
            }
        }
        return newVector;
    } 

    public static SparceVector Subtraction(SparceVector first, SparceVector second)
    {
        var newVector = new SparceVector();
        var firstElement = first.head;
        var secondElement = second.head;
        while (firstElement != null || secondElement != null)
        {
            if (firstElement.CellName == secondElement.CellName)
            {
                newVector[firstElement.CellName] = firstElement.Value - secondElement.Value;
                firstElement = firstElement.Next;
                secondElement = secondElement.Next;
                continue;
            }
            if (firstElement.CellName > secondElement.CellName)
            {
                newVector[secondElement.CellName] = -secondElement.Value;
                secondElement = secondElement.Next;
                continue;
            }
            if (secondElement.CellName > firstElement.CellName)
            {
                newVector[firstElement.CellName] = firstElement.Value;
                firstElement = firstElement.Next;
            }
        }
        return newVector;
    }

    public static int ScalarProduct(SparceVector first, SparceVector second)
    {
        var scalarProduct = 0;
        var firstElement = first.head;
        var secondElement = second.head;
        while (firstElement != null || secondElement != null)
        {
            if (firstElement.CellName == secondElement.CellName)
            {
                scalarProduct += firstElement.Value * secondElement.Value;
                firstElement = firstElement.Next;
                secondElement = secondElement.Next;
                continue;
            }
            if (firstElement.CellName > secondElement.CellName)
            {
                secondElement = secondElement.Next;
                continue;
            }
            if (secondElement.CellName > firstElement.CellName)
            {
                firstElement = firstElement.Next;
            }
        }
        return scalarProduct;
    }

    private void DeleteElement(VectorElement vectorElement)
    {
        if (vectorElement == head)
        {
            if (vectorElement.Next != null)
            {
                head = vectorElement.Next;
                vectorElement.Next.Previous = null;
                vectorElement.Next = null;
            }
            else
            {
                head = null;
            }
        }
        vectorElement.Previous = vectorElement.Next;
        vectorElement.Next = null;
        vectorElement.Previous = null;
    }

    public void PrintVector()
    {
        if (IsNull())
        {
            Console.WriteLine("Вектор из нулей");
        }
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
