// <copyright file = "DisconnectedGraphException.cs" author = "Egor Shishkarev">
// Copyright (c) Egor Shishkarev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Exception for error - disconnected graph.
/// </summary>
public class DisconnectedGraphException : Exception
{
    public DisconnectedGraphException() { }

    public DisconnectedGraphException(string message) : base(message) { }
}
