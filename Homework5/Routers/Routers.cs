namespace Routers;

public class RoutersTopology
{
    public readonly Router root; 
    public class Router
    {
        public Router(int name)
        {
            Name = name;
            RelatedRouters = new List<Router>();
            Bandwidths = new List<int>();
        }

        public int Name { get; set; }

        public List<Router> RelatedRouters { get; set; }

        public List<int> Bandwidths { get; set; }
    }

    public void CreateConnection(string connections)
    {

    }

    public bool IsConnected(Router root)
    {
        return false;
    }
}
