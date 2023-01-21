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
                next = null;
                connection = null;
                line = Colour.NONE;
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
        /// <param> string: the name of the station(vertex) </param>
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
                Station temp;
                // undirected meaning you must connect A to B and B to A.
                // A to B
                if (S.ContainsKey(name1) && S.ContainsKey(name2))
                {
                    temp = S[name1];
                    while (temp.E.next != null)
                    {
                        if (temp.E.next.connection.Equals(name2))
                        {
                            return false;
                        }
                    }
                    // B to A
                    // checks the 2nd vertex(station) for matching
                    temp = S[name2];
                    while (temp.E.next != null)
                    {
                        if (temp.E.next.connection.Equals(name1))
                        {
                            return false;
                        }
                    }

                    // move both linked lists move down by one.---
                    // Enter new node for vertex 1
                    while (S[name1].E.next != null)
                    {
                        S[name1].E = S[name1].E.next;
                    }
                    // Puts a new node in the first position in the first vertex(station)
                    S[name1].E = new Node(S[name2], c, S[name1].E.next);

                    // Enter new node for vertex 2
                    while (S[name2].E.next != null)
                    {
                        S[name2].E = S[name2].E.next;
                    }
                    // Puts a new node in the first position in the second vertex(station)
                    S[name2].E = new Node(S[name1], c, S[name2].E.next);
                    // -------------------------------------------
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
    }
}


