using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// Copy and paste this for comments:
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""> </param>
    /// <returns> <returns>
    public enum Colour { RED, YELLOW, GREEN, BLUE, ORANGE, WHITE, NONE } // For example

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
            public Station Parent;
            public Station(string name)
            {
                this.name = name;
                this.E = new Node();
                this.visited = false;
                this.Parent = null;
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
        /// Removes a station(vertex) in the graph.
        /// </summary>
        /// <param name="name"> string: the name of the station(vertex) </param>
        /// <returns> true or false <returns>
        // algorithm 
        public bool RemoveStation(string name)
        {
            //check to see if station ectually exists
            if (!(S.ContainsKey(name)))
            {
                Console.WriteLine("One or both stations do not exist.");
                return false;
            }

            //loop through every connection the station has and remove them
            Node temp = S[name].E;

            while (temp != null)
            {
                //this uses the name, the name of the connection of temp, and the line colour of temp all at the header
                //I previosuly used temp.connection.line, but I ran into an error where if the connections line is different, then it would loop infinitely
                RemoveConnection(name, temp.connection.name, temp.line);
                temp = S[name].E;
            }

            //remove the station from the dictionary
            S.Remove(name);

            return true;
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
            if (!(S.ContainsKey(name1) && S.ContainsKey(name2)))
            {
                Console.WriteLine("One or both stations do not exist.");
                return false;
            }
            // switch statement not used as values are not constants
            // cases:
            // station 1 is empty and station 2 has stuff in it - 1
            // station 2 is empty and station 1 has stuff in it - 2
            // both stations are empty - 3
            // both stations have stuff -- only one where you would have to check colors - 4
            //case 1
            if ((!S[name1].E.line.Equals(Colour.NONE)) && S[name2].E.line.Equals(Colour.NONE))
            {

                Node toAdd = new Node(S[name1], c, null);
                S[name2].E = toAdd;
                toAdd = new Node(S[name2], c, S[name1].E);
                S[name1].E = toAdd;
                return true;
            }
             // case 2
            if (S[name1].E.line.Equals(Colour.NONE) && (!S[name2].E.line.Equals(Colour.NONE)))
            {
                Node toAdd = new Node(S[name1], c, S[name2].E);
                S[name2].E = toAdd;

                toAdd = new Node(S[name2], c, null);
                S[name1].E = toAdd;
                return true;
            }
            // case 3
            if (S[name1].E.line.Equals(Colour.NONE) && S[name2].E.line.Equals(Colour.NONE))
            {
                Node toAdd = new Node(S[name1], c, null);
                S[name2].E = toAdd;

                toAdd = new Node(S[name2], c, null);
                S[name1].E = toAdd;
                return true;
            }
            //4
            if (!(S[name1].E.line.Equals(Colour.NONE) && S[name1].E.line.Equals(Colour.NONE)))
            {
                Node temp = S[name1].E;

                // cant do this if name1 is null
                while (temp != null)
                {
                    // first find the connection, then find if any other colors match
                    if (temp.connection.Equals(S[name2]))
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
            while (temp != null)
            {
                if (temp.connection.Equals(S[name2])) //checks to see if connection between stations exists, if so where, make sure colours match!!!!!
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
            //has to be temp != null, not temp.next, since it won't work if there's only one node in the header, or the node we want is at the end of the list
            while (temp != null)
            {
                /*had a problem here where when I did temp.next.connection it wouldn't remove it, in the case we were testing the connection towards
                mexico and the us, where mexico was the second connection in the list, since it started as temp.next it would check the second item instead of the first,
                and because we store c_2_location as temp, c_2_location was storing the first item in the list (in this case Canada) so it would delete
                Canada from the list but not Mexico.*/
                if (temp.connection.Equals(S[name1])) //checks to see if connection between exists, if so where 
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
                if (S[name1].E.next == null) //check to see if it's the only element in the linked list
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
                if (temp.next.next == null)
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
                if (S[name2].E.next == null) //check to see if it's the only element in the linked list
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
                if (temp.next.next == null)
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
        public bool ShortestRoute(string name1, string name2)
        {
            // check if stations exist
            if (!(S.ContainsKey(name1) && S.ContainsKey(name2)))
            {
                Console.WriteLine("Station does not exist");
                return false;
            }
            // initializing values
            Station toAdd = S[name1];
            Station Parent;
            Node stationNode;
            //making new queue
            Queue<Station> Q = new Queue<Station>();
            Q.Enqueue(toAdd);
            // temporary station, temporary node.
            toAdd.visited = true;
            // dequeue back to dictionary at worst case
            while (Q.Count != 0)
            {
                // pops the head off the queue.
                Parent = toAdd = Q.Dequeue();
                // store value of head to not reference original node.
                stationNode = toAdd.E;
                // loops through queued stations nodes.
                while (stationNode != null)
                {
                    // prepares to add stations first connection to queue
                    toAdd = stationNode.connection;
                    // only allows to be added to queue if not visited
                    if (!toAdd.visited)
                    {
                        // adds new station to the queue that is in the
                        toAdd.visited = true;
                        // assigns the node that was dequeued as the parent.
                        toAdd.Parent = Parent;
                        // adds the new child node to queue
                        Q.Enqueue(toAdd);
                        // if we found the destination station(name2), clear the queue so it doesn't continue and break.
                        if (toAdd == S[name2])
                        {
                            Q.Clear();
                            break;
                        }
                    }
                    stationNode = stationNode.next;
                }
            }
            // tracks back along parent to write out the names of the shortest path
            while (toAdd != null)
            {
                Console.WriteLine(toAdd.name + "->");
                toAdd = toAdd.Parent;
            }
            return true;
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


