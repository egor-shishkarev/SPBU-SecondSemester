namespace MapFilterFold;

public class CustomMethods
{
    public static List<OutputType> Map<InputType, OutputType> (List<InputType> listOfElements, Func<InputType, OutputType> function)
    {
        if (listOfElements == null)
        {
            throw new ArgumentNullException(nameof(listOfElements));
        }

        if (function == null)
        {
            throw new ArgumentNullException(nameof(function));
        }

        var newList = new List<OutputType>();

        foreach ( var element in listOfElements )
        {
            newList.Add(function(element));
        }
        return newList;
    }

    public static List<InputType> Filter<InputType> (List<InputType> listOfElements, Func<InputType, bool> function)
    {
        if (listOfElements == null)
        {
            throw new ArgumentNullException(nameof(listOfElements));
        }

        if (function == null)
        {
            throw new ArgumentNullException(nameof(function));
        }

        var newList = new List<InputType>();

        foreach ( var element in listOfElements )
        {
            if (function(element))
            {
                newList.Add(element);
            }
        }
        return newList;
    }

    public static AccumulatorType Fold<InputType, AccumulatorType>(List<InputType> listOfElements, AccumulatorType initialValue, Func<AccumulatorType, InputType, AccumulatorType> function)
    {
        if (listOfElements == null)
        {
            throw new ArgumentNullException(nameof(listOfElements));
        }

        if (function == null)
        {
            throw new ArgumentNullException(nameof(function));
        }

        AccumulatorType accumulator = initialValue;

        foreach ( var element in listOfElements )
        {
            accumulator = function(accumulator, element);
        }

        return accumulator;
    } 
}