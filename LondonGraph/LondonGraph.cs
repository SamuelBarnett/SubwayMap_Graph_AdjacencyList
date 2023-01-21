using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonGraph
{
    public enum Colour { RED, YELLOW, GREEN, BLUE } // For example
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
                Node.next = null;
                Node.connection = null;
                Node.line = null;
            }
            // maybe switch the properies to have {get; set;} and use that value instead.
            public Node(Station connection, Colour c, Node next)
            {
                Node.next = next;
                Node.connection = connection;
                Node.line = c;
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
                Station.name = name;
            }
        }
        private Dictionary<string, Station> S; // Dictionary of stations
        // Adjacency list.
        public SubwayMap() { }
        public void InsertStation(string name) { }
        public bool RemoveStation(string name) { }
        public bool InsertConnection(string name1, string name2, Colour c)
        {
            // undirected meaning you must connect A to B and B to A.
        }
        public bool RemoveConnection(string name1, string name2, Colour c) { }
        public void ShortestRoute(string name1, string name2) { }
    }
}


