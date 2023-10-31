namespace MapFilterFold;

/// <summary>
/// Class for three methods - Map, Filter and Fold
/// </summary>
public class CustomMethods
{
    /// <summary>
    /// A method that applies the derived function to all elements of the list.
    /// </summary>
    /// <typeparam name="T">The initial type of items in the list.</typeparam>
    /// <typeparam name="TNew">New type of items in the list.</typeparam>
    /// <param name="originalList">Initial list.</param>
    /// <param name="function">The function we want to apply to all the items in the list.</param>
    /// <returns>A new list where a function has been applied to each element.</returns>
    /// <exception cref="ArgumentNullException">Original list or function were null.</exception>
    public static List<TNew> Map<T, TNew>(List<T> originalList, Func<T, TNew> function) 
    {
        if (originalList == null)
        {
            throw new ArgumentNullException(nameof(originalList));
        }
        if (function == null)
        {
            throw new ArgumentNullException(nameof(function));
        }
        var newList = new List<TNew>();
        foreach (var item in originalList)
        {
            newList.Add(function(item));
        }
        return newList;
    }

    /// <summary>
    /// The method by which we can select elements from the list by the value of the function.
    /// </summary>
    /// <typeparam name="T">The initial type of items in the list.</typeparam>
    /// <param name="originalList">Initial list.</param>
    /// <param name="function">The function with which we want to select items from the list.</param>
    /// <returns>List of selected items.</returns>
    /// <exception cref="ArgumentNullException">Original list or function were null.</exception>
    public static List<T> Filter<T>(List<T> originalList, Func<T, bool> function)
    {
        if (originalList == null)
        {
            throw new ArgumentNullException(nameof(originalList));
        }
        if (function == null)
        {
            throw new ArgumentNullException(nameof(function));
        }
        var newList = new List<T>();
        foreach (var item in originalList)
        {
            if (function(item))
            {
                newList.Add(item);
            }
        }
        return newList;
    }

    /// <summary>
    /// The method by which we get the accumulator, gradually applying the function of the element and the accumulator.
    /// </summary>
    /// <typeparam name="T">The initial type of items in the list.</typeparam>
    /// <typeparam name="TAccumulator">Type of accumulator.</typeparam>
    /// <param name="originalList">Initital list.</param>
    /// <param name="accumulator">Initial value of accumulator.</param>
    /// <param name="function">The function we want to apply to the items in the list and accumulator.</param>
    /// <returns>Accumulator's value.</returns>
    /// <exception cref="ArgumentNullException">Original list, accumulator or function were null.</exception>
    public static TAccumulator Fold<T, TAccumulator>(List<T> originalList, TAccumulator accumulator, Func<TAccumulator, T, TAccumulator> function)
    {
        if (originalList == null)
        {
            throw new ArgumentNullException(nameof(originalList));
        }
        if (accumulator == null)
        {
            throw new ArgumentNullException(nameof(accumulator));
        }
        if (function == null)
        {
            throw new ArgumentNullException(nameof(function));
        }
        foreach (var item in originalList)
        {
            accumulator = function(accumulator, item);
        }
        return accumulator;
    }
}