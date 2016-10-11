using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

internal class Solution
{
    private static void Main()
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int starty = int.Parse(inputs[0]);
        int startx = int.Parse(inputs[1]);

        inputs = Console.ReadLine().Split(' ');
        int endy = int.Parse(inputs[0]);
        int endx = int.Parse(inputs[1]);

        inputs = Console.ReadLine().Split(' ');
        int h = int.Parse(inputs[0]);
        int w = int.Parse(inputs[1]);

        var m = new Map();

        for (int mY = 0; mY < h; mY++)
        {
            var line = Console.ReadLine().ToCharArray();
            for (int mX = 0; mX < w; mX++)
            {
                if (line[mX] == '#')
                    continue;
                if (line[mX] == '.')
                {
                    Node n = new Node(new Point(mX, mY), ".");
                    m.Nodes.Add(n);
                    var northernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX && x.Coordinate.Y == mY - 1 &&
                                new List<string> { "|", "." }.Contains(x.Type));
                    if (northernNode != null)
                    {
                        var l = new Link(n, northernNode);
                        n.Links.Add(l);
                        northernNode.Links.Add(l);
                        n.Neighbors.Add(northernNode);
                        northernNode.Neighbors.Add(n);
                    }

                    Node westernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX - 1 && x.Coordinate.Y == mY &&
                                new List<string> { "-", "." }.Contains(x.Type));
                    if (westernNode != null)
                    {
                        var l = new Link(n, westernNode);
                        n.Links.Add(l);
                        westernNode.Links.Add(l);
                        n.Neighbors.Add(westernNode);
                        westernNode.Neighbors.Add(n);
                    }
                }
                else if (line[mX] == '+')
                {
                    Node n = new Node(new Point(mX, mY), "+");
                    m.Nodes.Add(n);
                    var northernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX && x.Coordinate.Y == mY - 1 &&
                                new List<string> { "|", "+", "X" }.Contains(x.Type));
                    if (northernNode != null)
                    {
                        var l = new Link(n, northernNode);
                        n.Links.Add(l);
                        northernNode.Links.Add(l);
                        n.Neighbors.Add(northernNode);
                        northernNode.Neighbors.Add(n);
                    }

                    Node westernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX - 1 && x.Coordinate.Y == mY &&
                                new List<string> { "-", "+", "X" }.Contains(x.Type));
                    if (westernNode != null)
                    {
                        var l = new Link(n, westernNode);
                        n.Links.Add(l);
                        westernNode.Links.Add(l);
                        n.Neighbors.Add(westernNode);
                        westernNode.Neighbors.Add(n);
                    }
                }
                else if (line[mX] == '|')
                {
                    Node n = new Node(new Point(mX, mY), "|");
                    m.Nodes.Add(n);
                    var northernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX && x.Coordinate.Y == mY - 1 &&
                                new List<string> { ".", "+" }.Contains(x.Type));
                    if (northernNode != null)
                    {
                        var l = new Link(n, northernNode);
                        n.Links.Add(l);
                        northernNode.Links.Add(l);
                        n.Neighbors.Add(northernNode);
                        northernNode.Neighbors.Add(n);
                    }
                }
                else if (line[mX] == '-')
                {
                    Node n = new Node(new Point(mX, mY), "-");
                    m.Nodes.Add(n);

                    Node westernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX - 1 && x.Coordinate.Y == mY &&
                                new List<string> { "+", "." }.Contains(x.Type));
                    if (westernNode != null)
                    {
                        var l = new Link(n, westernNode);
                        n.Links.Add(l);
                        westernNode.Links.Add(l);
                        n.Neighbors.Add(westernNode);
                        westernNode.Neighbors.Add(n);
                    }
                }
                else if (line[mX] == 'X')
                {
                    Node n1 = new Node(new Point(mX, mY), "X");
                    m.Nodes.Add(n1);
                    var northernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX && x.Coordinate.Y == mY - 1 &&
                                new List<string> { "+", "X" }.Contains(x.Type));
                    if (northernNode != null)
                    {
                        var l = new Link(n1, northernNode);
                        n1.Links.Add(l);
                        northernNode.Links.Add(l);
                        n1.Neighbors.Add(northernNode);
                        northernNode.Neighbors.Add(n1);
                    }

                    Node westernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX - 1 && x.Coordinate.Y == mY &&
                                new List<string> { "+", "X" }.Contains(x.Type));
                    if (westernNode != null)
                    {
                        var l = new Link(n1, westernNode);
                        n1.Links.Add(l);
                        westernNode.Links.Add(l);
                        n1.Neighbors.Add(westernNode);
                        westernNode.Neighbors.Add(n1);
                    }

                    Node n2 = new Node(new Point(mX, mY), ".");
                    m.Nodes.Add(n2);
                    northernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX && x.Coordinate.Y == mY - 1 &&
                                new List<string> { "." }.Contains(x.Type));
                    if (northernNode != null)
                    {
                        var l = new Link(n2, northernNode);
                        n2.Links.Add(l);
                        northernNode.Links.Add(l);
                        n2.Neighbors.Add(northernNode);
                        northernNode.Neighbors.Add(n2);
                    }

                    westernNode =
                        m.Nodes.Find(
                            x =>
                                x.Coordinate.X == mX - 1 && x.Coordinate.Y == mY &&
                                new List<string> { "." }.Contains(x.Type));
                    if (westernNode != null)
                    {
                        var l = new Link(n2, westernNode);
                        n2.Links.Add(l);
                        westernNode.Links.Add(l);
                        n2.Neighbors.Add(westernNode);
                        westernNode.Neighbors.Add(n2);
                    }
                }
            }
        }

        BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch();
        breadthFirstSearch.CalculateDistances(m.Nodes.Find(x=>x.Coordinate.X==startx && x.Coordinate.Y==starty));
        NodeDistance exitNode=breadthFirstSearch.NodeDistances.First(x => x.Node.Coordinate.X == endx && x.Node.Coordinate.Y == endy);

        Console.WriteLine(exitNode.Distance);
    }
}

public class Node
{
    public Point Coordinate { get; }

    public List<Link> Links { get; }

    public List<Node> Neighbors { get; }

    public string Type { get; }

    public Node(Point coordinate, string type)
    {
        Coordinate = coordinate;
        Type = type;
        Links = new List<Link>();
        Neighbors = new List<Node>();
    }

    public override string ToString()
    {
        return Coordinate.ToString();
    }
}

public class Link
{
    public ReadOnlyCollection<Node> Nodes { get; }

    public Link(Node n1, Node n2)
    {
        Nodes = new ReadOnlyCollection<Node>(new List<Node> { n1, n2 });
    }

    public override string ToString()
    {
        return $"{Nodes[0]} {Nodes[1]}";
    }
}

public class Map
{
    public List<Node> Nodes { get; }

    public Node this[int n] => Nodes[n];

    public Map()
    {
        Nodes = new List<Node>();
    }
}

public class NodeDistance
{
    public Node Node { get; }

    public int Distance { get; set; }

    public List<Node> NodesOnPath { get; set; }

    public NodeDistance(Node node)
    {
        NodesOnPath = new List<Node>();
        Node = node;
    }
}

public class BreadthFirstSearch
{
    private List<NodeDistance> nodeDistances;

    private class BfsNodeDistance : NodeDistance
    {
        public Node PredecessorNode { get; set; }

        public BfsNodeDistance(Node node) : base(node)
        {}

        #region Overrides of Object

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
        /// </summary>
        /// <returns>
        /// Eine Zeichenfolge, die das aktuelle Objekt darstellt.
        /// </returns>
        public override string ToString()
        {
            return Node.ToString();
        }

        #endregion
    }

    public IEnumerable<NodeDistance> NodeDistances => nodeDistances.OrderBy(nd => nd.Distance);

    public void CalculateDistances(Node start)
    {
        nodeDistances = new List<NodeDistance>();

        Queue<BfsNodeDistance> queue = new Queue<BfsNodeDistance>();
        HashSet<Node> visitedNodes = new HashSet<Node>();

        queue.Enqueue(new BfsNodeDistance(start) { PredecessorNode = null, Distance = 0 });

        while (queue.Any())
        {
            BfsNodeDistance bfsNode = queue.Dequeue();
            visitedNodes.Add(bfsNode.Node);

            foreach (Node neighbor in bfsNode.Node.Neighbors)
            {
                if (!visitedNodes.Contains(neighbor) &&
                    queue.All(nq => nq.Node != neighbor))
                {
                    BfsNodeDistance bfsNodeDistance = new BfsNodeDistance(neighbor)
                    {
                        PredecessorNode = bfsNode.Node,
                        Distance = bfsNode.Distance + 1
                    };
                    bfsNodeDistance.NodesOnPath.AddRange(bfsNode.NodesOnPath);
                    bfsNodeDistance.NodesOnPath.Add(bfsNode.Node);

                    queue.Enqueue(bfsNodeDistance);
                }
            }

            nodeDistances.Add(new NodeDistance(bfsNode.Node)
            {
                Distance = bfsNode.Distance,
                NodesOnPath = bfsNode.NodesOnPath
            });
        }
    }
}