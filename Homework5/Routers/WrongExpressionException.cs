// <copyright file = "WrongExpressionException.cs" author = "Egor Shishkarev">
// Copyright (c) Egor Shishkarev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Exception for error - incorrect expression of connection.
/// </summary>
public class WrongExpressionException: Exception
{
    public WrongExpressionException() { }

    public WrongExpressionException(string message) : base(message) { }
}
