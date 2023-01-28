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
        // public bool RemoveStation(string name)
        // {
        // }

        /// <summary>
        /// Inserts an edge that connects to two vertexes in an undirected graph.
        /// </summary>
        /// <param name="name1"> string: the first name of the station(vertex) </param>
        /// <param name="name2"> string: the second name of the station(vertex) </param>
        /// <param name="c"> value representing the color of the edge </param>
        /// <returns> true or false <returns>
        public bool InsertConnection(string name1, string name2, Colour c)
        {
            if (!(S.ContainsKey(name1) && S.ContainsKey(name2)))
            {
                Console.WriteLine("error");
                return false;
            }

            // if there is no station of course there is going to be no other line with a different color
            // cases:
            // station 1 is empty and station 2 has stuff in it - 1
            // station 2 is empty and station 1 has stuff in it - 2
            // both stations are empty - 3
            // both stations have stuff -- only one where you would have to check colors - 4
            // switch to case statemnt later
            // 3
            if (S[name1].E.line.Equals(Colour.NONE) && S[name2].E.line.Equals(Colour.NONE))
            {
                Node toAdd = new Node(S[name1], c, null);
                S[name2].E = toAdd;

                toAdd = new Node(S[name2], c, null);
                S[name1].E = toAdd;
                return true;
            }
            // 2
            if (S[name1].E.line.Equals(Colour.NONE) && (!S[name2].E.line.Equals(Colour.NONE)))
            {
                Node toAdd = new Node(S[name1], c, S[name2].E);
                S[name2].E = toAdd;

                toAdd = new Node(S[name2], c, null);
                S[name1].E = toAdd;
                return true;
            }
            // 1
            if ((!S[name1].E.line.Equals(Colour.NONE)) && S[name2].E.line.Equals(Colour.NONE))
            {

                Node toAdd = new Node(S[name1], c, null);
                S[name2].E = toAdd;
                toAdd = new Node(S[name2], c, S[name1].E);
                S[name1].E = toAdd;
                return true;
            }
            // if name 1 is empty initialize new list in station 1
            // search through station 2 to see if 
            //4
            if (!(S[name1].E.line.Equals(Colour.NONE) && S[name1].E.line.Equals(Colour.NONE)))
            {
                Node temp = S[name1].E;

                // cant do this if name1 is null
                while (temp.next != null)
                {
                    // first find the connection, then find if any other colors match
                    if (temp.next.connection.Equals(S[name2]))
                    {
                        // temp.next == station 2
                        // find if that connection that does exist is unique
                        // if connection with the same color exists
                        // loop through station 2 and check this
                        Node temp2 = S[name2].E;
                        while (temp2 != null)
                        {
                            if (temp2.connection.Equals(S[name1]))
                            {
                                if (temp2.line == c)
                                {
                                    Console.WriteLine("station exists");
                                    return false;
                                }
                            }
                            temp2 = temp2.next;
                        }
                    }
                    temp = temp.next;
                }
                Node toAdd = new Node(S[name1], c, S[name2].E);
                S[name2].E = toAdd;
                toAdd = new Node(S[name2], c, S[name1].E);
                S[name1].E = toAdd;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Removes an edge that connects to two vertexes in an undirected graph.
        /// </summary>
        /// <param name="name1"> string: the first name of the station(vertex) </param>
        /// <param name="name2"> string: the second name of the station(vertex) </param>
        /// <param name="c"> value representing the color of the edge </param>
        /// <returns> true or false <returns>
        public bool RemoveConnection(string name1, string name2, Colour c)
        {
            if (!(S.ContainsKey(name1) && S.ContainsKey(name2)))
            {
                Console.WriteLine("Station does not exist");
                return false;
            }
            Node c_1_location = S[name1].E;
            Node temp = S[name1].E; //temp value for the header of the list containing station 1
            bool s_1_exists = false, s_2_exists = false, s_1_colour = false, s_2_colour = false; //bool used in if statement to know whether a connection/colour exists

            // Checks location of nodes ========================================
            while (temp.next != null)
            {
                if (temp.next.connection.Equals(S[name2])) //checks to see if connection between stations exists, if so where, make sure colours match!!!!!
                {
                    s_1_exists = true;
                    //check to see if colours match
                    if (temp.line.Equals(c))
                    {
                        s_1_colour = true;
                        c_1_location = temp; //connection location for station 1               
                        break;
                    }
                }
                temp = temp.next;
            }
            if (s_1_exists != true)
            {
                Console.WriteLine("Connection between station A -> B doesn't exist");
                return false;
            }
            Node c_2_location = S[name2].E;
            temp = S[name2].E; //temp value for the header of the list containing station 2
            while (temp.next != null)
            {
                if (temp.next.connection.Equals(S[name1])) //checks to see if connection between exists, if so where 
                {
                    s_2_exists = true;
                    //check to see if colours match
                    if (temp.line.Equals(c))
                    {
                        s_2_colour = true;
                        c_2_location = temp; //connection location for station 2              
                        break;
                    }
                }
                temp = temp.next;
            }
            if (s_2_exists != true)
            {
                Console.WriteLine("Connection between B -> A doesn't exist");
                return false;
            }
            // =========================================

            if (!(s_1_colour == true && s_2_colour == true))
            {
                Console.WriteLine("Colour between the connection doesn't match");
                return false;
            }

            //check to see if the node is found at the head
            if (S[name1].E.Equals(c_1_location))
            {
                if (S[name1].E.next.Equals(null)) //check to see if it's the only element in the linked list
                {
                    S[name1].E = null;//set header to null
                }
                else //more than one item in the list
                {
                    //create temp node, make header equal to next node 
                    temp = S[name1].E.next;
                    S[name1].E = temp;
                }
            }
            else
            {
                //loop to get node before located node
                temp = S[name1].E;
                while (!temp.next.Equals(c_1_location))//loop while the next station is not equal location of the station
                {
                    temp = temp.next;
                }

                //check to see if it's at the end of the list
                if (temp.next.next.Equals(null))
                {
                    temp.next = null; //makes pointer to connection we want to delete is null
                }
                else
                {
                    //create reference from temp to the next from the location, locations next becomes null
                    temp.next = temp.next.next;
                    c_1_location = null;
                }
            }

            //check to see if the node is found at the head (for the second station!!!!!!!!!)
            if (S[name2].E.Equals(c_2_location))
            {
                if (S[name2].E.next.Equals(null)) //check to see if it's the only element in the linked list
                {
                    S[name2].E = null;//set header to null
                    return true;
                }
                else //more than one item in the list
                {
                    //create temp node, make header equal to next node 
                    temp = S[name2].E.next;
                    S[name2].E = temp;
                    return true;
                }
            }
            else
            {
                //loop to get node before located node
                temp = S[name2].E;
                while (!temp.next.Equals(c_2_location))//loop while the next station is not equal location of the station
                {
                    temp = temp.next;
                }

                //check to see if it's at the end of the list
                if (temp.next.next.Equals(null))
                {
                    temp.next = null; //makes pointer to connection we want to delete is null
                    return true;
                }
                else
                {
                    //create reference from temp to the next from the location, locations next becomes null
                    temp.next = temp.next.next;
                    c_2_location = null;
                    return true;
                }
            }
        }
        /// <summary>
        /// Finds the shortest path between two vertexes in a graph using breath-first
        /// </summary>
        /// <param name="name1"> string: the first name of the station(vertex) </param>
        /// <param name="name2"> string: the second name of the station(vertex) </param>
        /// <returns> void <returns>
        public void ShortestRoute(string name1, string name2)
        {
            // uses breath first to search. through
            Station toAdd;
            Queue<Station> Q = new Queue<Station>();
            Q.Enqueue(S[name1]);
            Node temp = S[name1].E;

            while (Q.Count != 0)
            {
                S[name1].visited = true;
                S[name1] = Q.Dequeue();

                Console.WriteLine(S[name1].name);

                while (temp.next != null)
                {
                    toAdd = temp.connection;
                    //if not visited
                    if (!toAdd.visited)
                    {
                        toAdd.visited = true;
                        Q.Enqueue(toAdd);
                    }
                    temp = temp.next;
                }
            }


        }

        public int getCount(string name1)
        {
            int count = 0;
            Node temp = S[name1].E;
            while (temp.next != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }
        public void PrintStations()
        {
            foreach (var station in S)
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
                    Console.WriteLine("[{0}]({1})", temp.connection.name, temp.line);
                    temp = temp.next;
                }
            }
        }
    }
}


