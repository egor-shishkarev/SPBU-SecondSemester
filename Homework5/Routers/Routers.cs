// <copyright file = "Routers.cs" author = "Egor Shishkarev">
// Copyright (c) Egor Shishkarev. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Class of Routers Topology.
/// </summary>
public class RoutersTopology
{
    /// <summary>
    /// Class of Router - vertices in a graph of connections.
    /// </summary>
    public class Router
    {
        /// <summary>
        /// Constructor for instance of Router Class.
        /// </summary>
        /// <param name="name">Integer number - name of Router.</param>
        public Router(int name)
        {
            Name = name;
            RelatedRouters = new Dictionary<int, (int bandwidth, Router router)>();
        }

        /// <summary>
        /// Integer number - name of Router.
        /// </summary>
        public int Name { get; set; }

        /// <summary>
        /// Dictionary of Related Routers and the throughput values ​​between routers.
        /// </summary>
        public Dictionary<int, (int bandwidth, Router router)> RelatedRouters { get; set; }
    }

    /// <summary>
    /// Creates optimal connection between Routers, based on bandwidth.
    /// </summary>
    /// <param name="connections">Array of connections.</param>
    /// <exception cref="WrongExpressionException">Wrong pattern of connection.</exception>
    /// <exception cref="DisconnectedGraphException">Vertices in graph was not connected.</exception>
    public static void CreateOptimalConfiguration(string[] connections, string filePath)
    {
        var listOfRouters = new List<Router>();
        for (int i = 0; i < connections.Length; ++i)
        {
            (var router, int[] numbersOfRelatedRouters, int[] bandwidth) = ParseString.ParseConfiguration(connections[i]);
            if (!IsInList(listOfRouters, router.Name))
            {
                listOfRouters.Add(router);
            }
            else
            {
                router = FindRouter(listOfRouters, router.Name);
            }
            foreach (var number in numbersOfRelatedRouters)
            {
                if (!IsInList(listOfRouters, number))
                {
                    listOfRouters.Add(new Router(number));
                }
            }
            for (int j = 0; j < numbersOfRelatedRouters.Length; ++j)
            {
                ConnectRouters(router, router.Name, FindRouter(listOfRouters, numbersOfRelatedRouters[j]), numbersOfRelatedRouters[j], bandwidth[j]);
            }
        }
        listOfRouters.Sort(CompareByName);
        if (!IsConnected(listOfRouters))
        {
            throw new DisconnectedGraphException("Router network is not connected!");
        }
        var topologyResult = FindOptimalConfiguration(listOfRouters);
        WriteTopologyInFile(topologyResult, filePath);
    }

    private static int CompareByName(Router firstRouter, Router secondRouter)
    {
        if (firstRouter.Name > secondRouter.Name)
        {
            return 1;
        }
        return -1;
    }

    /// <summary>
    /// Additional function to sorting Routers for writing in file.
    /// </summary>
    /// <param name="firstPair">First pair of Routers to compare.</param>
    /// <param name="secondPair">Second pair of Routers to compare.</param>
    /// <returns>1 -- if first pair preced second, -1 -- otherwise.</returns>
    private static int ComparePairByName((Router, Router) firstPair, (Router, Router) secondPair)
    {
        var firstFirstRouter = firstPair.Item1;
        var firstSecondRouter = firstPair.Item2;
        var secondFirstRouter = secondPair.Item1;
        var secondSecondRouter = secondPair.Item2;

        if (firstFirstRouter.Name > secondFirstRouter.Name)
        {
            return CompareByName(firstFirstRouter, secondFirstRouter);
        }
        if (firstFirstRouter.Name == secondFirstRouter.Name || firstSecondRouter.Name > secondSecondRouter.Name)
        {
            return CompareByName(firstFirstRouter, secondFirstRouter);
        }
        return -1;
    }

    /// <summary>
    /// Check if Router with such name locacted in List.
    /// </summary>
    /// <param name="listOfRouters">List of Routers, where we want to check current Router.</param>
    /// <param name="name">Name of Router, that we want to check.</param>
    /// <returns>True -- if Router in List, False -- otherwise.</returns>
    private static bool IsInList(List<Router> listOfRouters, int name)
    {
        foreach(var router in listOfRouters)
        {
            if (router.Name == name)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Finds Router in List.
    /// </summary>
    /// <param name="listOfRouters">List of Routers, where we want find current Router.</param>
    /// <param name="name">Name of Router, that we want to find.</param>
    /// <returns>Router with needed name.</returns>
    private static Router FindRouter(List<Router> listOfRouters, int name)
    {
        foreach (var router in listOfRouters)
        {
            if (router.Name == name)
            {
                return router;
            }
        }
        return new Router(-1);
    }

    /// <summary>
    /// Adding Routers to Related Routers each other.
    /// </summary>
    /// <param name="firstRouter">First Router.</param>
    /// <param name="firstName">Name of first Router.</param>
    /// <param name="secondRouter">Second Router.</param>
    /// <param name="secondName">Name of second Router.</param>
    /// <param name="bandwidth">Bandwidth between first and second Router.</param>
    private static void ConnectRouters(Router firstRouter, int firstName, Router secondRouter, int secondName, int bandwidth)
    {
        firstRouter.RelatedRouters.Add(secondName, (bandwidth, secondRouter));
        secondRouter.RelatedRouters.Add(firstName, (bandwidth, firstRouter));
    }

    /// <summary>
    /// Check if the graph of Routers is connected.
    /// </summary>
    /// <param name="listOfRouters">List of Routers in graph.</param>
    /// <returns>True -- if graph is connected, False -- otherwise.</returns>
    public static bool IsConnected(List<Router> listOfRouters)
    {
        var visitedRouters = new List<int> { listOfRouters[0].Name };
        var currentRouter = listOfRouters[0];
        FindNotVisitedRouters(currentRouter, visitedRouters);
        if (visitedRouters.Count == listOfRouters.Count)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Additional method to check the connectedness of the graph.
    /// </summary>
    /// <param name="router">Current Router.</param>
    /// <param name="visitedRouters">List of visited Routers.</param>
    private static void FindNotVisitedRouters(Router router, List<int> visitedRouters)
    {
        foreach (var key in router.RelatedRouters.Keys)
        {
            if (!visitedRouters.Contains(key))
            {
                visitedRouters.Add(key);
                FindNotVisitedRouters(router.RelatedRouters[key].router, visitedRouters);
            }
        }
    }

    /// <summary>
    /// Method that find optimal configuration in graph.
    /// </summary>
    /// <param name="listOfRouters">List of Routers.</param>
    /// <returns>List of pairs of Routers, that contains in optimal configuration. </returns>
    public static List<(Router ancestor, Router child)> FindOptimalConfiguration(List<Router> listOfRouters)
    {
        var currentRouter = listOfRouters[0];
        var traversalList = new List<Router>() { currentRouter };
        var listOfRibs = new List<(Router, Router)>() { };
        while (traversalList.Count != listOfRouters.Count)
        {
            (var ancestorRouter, var newRouterToAdd) = FindRouterWithMaxBandwidth(traversalList);
            listOfRibs.Add((ancestorRouter, newRouterToAdd));
        }
        return listOfRibs;
    }

    /// <summary>
    /// Method, that find max bandwidth in List of Routers.
    /// </summary>
    /// <param name="travesalList">List of Routers, where we want to find max bandwidth.</param>
    /// <returns>Pair of Routers - rib in graph.</returns>
    private static (Router, Router) FindRouterWithMaxBandwidth(List<Router> travesalList)
    {
        var maxBandwidth = int.MinValue;
        Router optimalRouter = travesalList[0];
        Router ancestorRouter = travesalList[0];
        foreach (var router in travesalList)
        {
            foreach (var key in router.RelatedRouters.Keys)
            {
                if (router.RelatedRouters[key].bandwidth > maxBandwidth && !IsInList(travesalList, router.RelatedRouters[key].router.Name))
                {
                    maxBandwidth = router.RelatedRouters[key].bandwidth;
                    optimalRouter = router.RelatedRouters[key].router;
                    ancestorRouter = router;
                }
            }
        }
        travesalList.Add(optimalRouter);
        return (ancestorRouter, optimalRouter);
    }

    /// <summary>
    /// Method, that write optimal configuration in file.
    /// </summary>
    /// <param name="topologyResult">Result of algorithm, that find optimal configuration.</param>
    private static void WriteTopologyInFile(List<(Router, Router)> topologyResult, string filePath)
    {
        topologyResult.Sort(ComparePairByName);
        using (StreamWriter file = new(filePath))
        {
            var currentRouterName = -1;
            for (int i = 0; i < topologyResult.Count; ++i)
            {
                if (topologyResult[i].Item1.Name != currentRouterName)
                {
                    file.Write($"{topologyResult[i].Item1.Name}: {topologyResult[i].Item2.Name} ({topologyResult[i].Item1.RelatedRouters[topologyResult[i].Item2.Name].bandwidth})");
                    currentRouterName = topologyResult[i].Item1.Name;
                } else
                {
                    file.Write($", {topologyResult[i].Item2.Name} ({topologyResult[i].Item1.RelatedRouters[topologyResult[i].Item2.Name].bandwidth})");
                }
                if (i < topologyResult.Count - 1 && topologyResult[i + 1].Item1.Name != currentRouterName)
                {
                    file.Write('\n');
                }
            }
        }
    }
}
