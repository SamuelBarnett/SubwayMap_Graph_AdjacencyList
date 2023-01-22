using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonGraph
{
    /// Copy and paste this for comments:
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""> </param>
    /// <returns> <returns>
    public enum Colour { RED, YELLOW, GREEN, BLUE, NONE } // For example
    public class SubwayMap
    {
        private class Node
        {
            //edge
            public Station connection; // Adjacent station (connection)
            public Colour line; // Colour of its subway line
            public Node next; // Link to the next adjacent station (Node)
            public Node()
            {
                this.next = null;
                this.connection = null;
                this.line = Colour.NONE;
            }
            // maybe switch the properies to have {get; set;} and use that value instead.
            public Node(Station connection, Colour c, Node next)
            {
                this.connection = connection;
                this.next = next;
                this.line = c;
            }
        }
        // vertex
        private class Station
        {
            public string name; // Name of the subway station
            public bool visited; // Used for the breadth-first search
            public Node E; // Header node for a linked list of adjacent stations
            public Station(string name)
            {
                this.name = name;
                this.E = new Node();
                this.visited = false;
            }
        }
        private Dictionary<string, Station> S; // Dictionary of stations
        // Adjacency list.
        public SubwayMap()
        {
            S = new Dictionary<string, Station>();
        }
        /// <summary>
        /// Inserts a station(vertex) into the adjacency dictionary for the graph.
        /// </summary>
        /// <param name="name"> string: the name of the station(vertex) </param>
        /// <returns> void <returns>
        public void InsertStation(string name)
        {
            if (!S.ContainsKey(name))
            {
                Station addStation = new Station(name);
                S.Add(name, addStation);
            }
            else
            {
                Console.WriteLine("Station with the same name already exists");
            }
        }
        /// <summary>
        /// Inserts a station(vertex) into the adjacency dictionary for the graph.
        /// </summary>
        /// <param name="name"> string: the name of the station(vertex) </param>
        /// <returns> true or false <returns>
        public bool RemoveStation(string name)
        {
        }

        /// <summary>
        /// Inserts an edge that connects to two vertexes in an undirected graph.
        /// </summary>
        /// <param name="name1"> string: the first name of the station(vertex) </param>
        /// <param name="name2"> string: the second name of the station(vertex) </param>
        /// <param name="c"> value representing the color of the edge </param>
        /// <returns> true or false <returns>
        public bool InsertConnection(string name1, string name2, Colour c)
        {
            {
                if (S.ContainsKey(name1) && S.ContainsKey(name2))
                {
                    Node temp = S[name1].E;
                    while (temp.next != null)
                    {
                        if (temp.next.connection.Equals(name2))
                        {
                            Console.WriteLine("station exists");
                            return false;
                        }
                    }
                    // B to A
                    // checks the 2nd vertex(station) for matching
                    temp = S[name2].E;
                    while (temp.next != null)
                    {
                        if (temp.next.connection.Equals(name1))
                        {
                            Console.WriteLine("station exists");
                            return false;
                        }
                    }

                    if (S[name1].E.line.Equals(Colour.NONE))
                    {
                        Node toAdd = new Node(S[name2], c, null);
                        S[name1].E = toAdd;
                    }
                    else
                    {
                        Node toAdd = new Node(S[name2], c, S[name1].E);
                        S[name1].E = toAdd;
                    }

                    if (S[name2].E.line.Equals(Colour.NONE))
                    {
                        Node toAdd = new Node(S[name1], c, null);
                        S[name2].E = toAdd;
                    }
                    else
                    {
                        Node toAdd = new Node(S[name1], c, S[name2].E);
                        S[name2].E = toAdd;
                    }

                    return true;
                }

                return false;
            }
        }
        /// <summary>
        /// Removes an edge that connects to two vertexes in an undirected graph.
        /// </summary>
        /// <param name="name1"> string: the first name of the station(vertex) </param>
        /// <param name="name2"> string: the second name of the station(vertex) </param>
        /// <param name="c"> value representing the color of the edge </param>
        /// <returns> true or false <returns>
        public bool RemoveConnection(string name1, string name2, Colour c) { }
        /// <summary>
        /// Finds the shortest path between two vertexes in a graph using breath-first
        /// </summary>
        /// <param name="name1"> string: the first name of the station(vertex) </param>
        /// <param name="name2"> string: the second name of the station(vertex) </param>
        /// <returns> void <returns>
        public void ShortestRoute(string name1, string name2) { }
        public void PrintStations()
        {
            foreach ( var station in S)
            {
                Console.WriteLine("name: {0}", station.Value.name);
            }
        }

        public void PrintGraph()
        {
            foreach (var station in S)
            {
                Console.WriteLine("Station: {0}", station.Value.name);
                Node temp = station.Value.E;
                while (temp != null && temp.connection != null)
                {
                    Console.WriteLine("edges: {0}", temp.connection.name);
                    temp = temp.next;   
                }
            }
        }
    }
}


