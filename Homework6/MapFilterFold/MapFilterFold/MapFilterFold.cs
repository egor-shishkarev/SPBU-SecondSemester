// <copyright file = "Program.cs" author = "Egor Shishkarev">
// Copyright (c) Egor Shishkarev. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace MapFilterFold;

/// <summary>
/// Class for three methods - Map, Filter and Fold
/// </summary>
public class CustomMethods
{
    /// <summary>
    /// Applies the specified function to all elements of the list.
    /// </summary>
    /// <typeparam name="InputType">Type of input elements in list.</typeparam>
    /// <typeparam name="OutputType">Type of output elements in list.</typeparam>
    /// <param name="listOfElements">The list in which we want to apply the function.</param>
    /// <param name="function">The function, which we want to apply to elements in list.</param>
    /// <returns>List after applying the function.</returns>
    /// <exception cref="ArgumentNullException">List of elements or function were null.</exception>
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

    /// <summary>
    /// Selects elements from a list based on a specified function.
    /// </summary>
    /// <typeparam name="InputType">Type of input elements in list.</typeparam>
    /// <param name="listOfElements">The list, where we want to select elements.</param>
    /// <param name="function">The function with which we select elements from the list.</param>
    /// <returns>List of elements, selected by function</returns>
    /// <exception cref="ArgumentNullException">List of elements or function were null.</exception>
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

    /// <summary>
    /// Selects the current element of the list and executes the function on it and the accumulator.
    /// </summary>
    /// <typeparam name="InputType">Type of input elements in list.</typeparam>
    /// <typeparam name="AccumulatorType">Type of accumulator.</typeparam>
    /// <param name="listOfElements">The list in which we want to apply the function.</param>
    /// <param name="initialValue">Initial accumulator value.</param>
    /// <param name="function">The function, which we want to apply to elements in list and accumulator.</param>
    /// <returns>Value of accumualtor after applying the function to all elements of the list.</returns>
    /// <exception cref="ArgumentNullException">List of elements or function were null.</exception>
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