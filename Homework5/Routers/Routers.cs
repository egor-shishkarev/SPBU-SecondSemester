using System.Reflection.Metadata.Ecma335;

namespace Routers;

/// <summary>
/// Class of Routers Topology
/// </summary>
public class RoutersTopology
{
    public class Router
    {
        public Router(int name)
        {
            Name = name;
            RelatedRouters = new Dictionary<int, (int bandwidth, Router router)>();
        }

        public int Name { get; set; }

        public Dictionary<int, (int bandwidth, Router router)> RelatedRouters { get; set; }

    }

    public static void CreateOptimalConfiguration(string[] connections)
    {
        var listOfRouters = new List<Router>();
        for (int i = 0; i < connections.Length; ++i)
        {
            (var router, int[] numbersOfRelatedRouters, int[] bandwidth) = ParseString.ParseConfiguration(connections[i]);
            if (numbersOfRelatedRouters == Array.Empty<int>() || bandwidth == Array.Empty<int>())
            {
                throw new ArgumentException("Connections was incorrect!", nameof(connections));
            }
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
            throw new IOException();
        }
        var topologyResult = FindOptimalConfiguration(listOfRouters);
        WriteTopologyInFile(topologyResult);
    }

    private static int CompareByName(Router firstRouter, Router secondRouter)
    {
        if (firstRouter.Name > secondRouter.Name)
        {
            return 1;
        }
        return -1;
    }

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

    private static void ConnectRouters(Router firstRouter, int firstName, Router secondRouter, int secondName, int bandwidth)
    {
        firstRouter.RelatedRouters.Add(secondName, (bandwidth, secondRouter));
        secondRouter.RelatedRouters.Add(firstName, (bandwidth, firstRouter));
    }

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

    private static void WriteTopologyInFile(List<(Router, Router)> topologyResult)
    {
        topologyResult.Sort(ComparePairByName);
        using (StreamWriter file = new("../../../SolutionResult.txt"))
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
