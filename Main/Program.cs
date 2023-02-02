using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class SubwayGraph
    {
        public static void Main()
        {
            // SubwayMap Subway = new SubwayMap();
            // Subway.InsertStation("Canada");
            // Subway.InsertStation("Mexico");
            // Subway.InsertStation("US");
            // Subway.InsertStation("Netherlands");
            // Subway.InsertStation("Russia");

            // // Subway.InsertConnection("Canada", "US", Colour.GREEN);
            // // Subway.InsertConnection("Canada", "US", Colour.RED);
            // // // Subway.InsertConnection("Canada", "Mexico", Colour.BLUE);
            // // Subway.InsertConnection("US", "Mexico", Colour.YELLOW);

            // // // Subway.InsertConnection("Mexico", "US", Colour.YELLOW);
            // // Subway.InsertConnection("Canada", "US", Colour.YELLOW);
            // // Subway.InsertConnection("Canada", "Netherlands", Colour.RED);
            // // Subway.InsertConnection("Canada", "Russia", Colour.BLUE);
            // // Subway.InsertConnection("Russia", "Netherlands", Colour.BLUE);
            // // Subway.InsertConnection("Canada", "Netherlands", Colour.YELLOW);
            // // Subway.InsertConnection("Netherlands", "Russia", Colour.GREEN);

            // Subway.InsertConnection("Canada", "Russia", Colour.GREEN);
            // Subway.InsertConnection("Russia", "Netherlands", Colour.GREEN);
            // Subway.InsertConnection("Netherlands", "Mexico", Colour.GREEN);

            // Subway.ShortestRoute("Canada","Mexico");
            // Subway.RemoveConnection("Canada", "US", Colour.BLUE);
            
            // Subway.RemoveStation("Mexico");

            // Subway.PrintGraph();
            //main subway map
            SubwayMap hamiltonSubway = new SubwayMap();
            //Blue line
            hamiltonSubway.InsertStation("Ancaster");
            hamiltonSubway.InsertStation("Garner Rd E");
            hamiltonSubway.InsertStation("Rymal at Garth");
            hamiltonSubway.InsertStation("Rymal at Upper James");
            hamiltonSubway.InsertStation("Rymal at Upper Wellington");
            hamiltonSubway.InsertStation("Rymal at Upper Sherman");
            hamiltonSubway.InsertStation("Rymal at Upper Ottawa");
            hamiltonSubway.InsertStation("Rymal at Highland");
            hamiltonSubway.InsertStation("Elfrida");
            //Blue line connections
            hamiltonSubway.InsertConnection("Ancaster", "Garner Rd E", Colour.BLUE);
            hamiltonSubway.InsertConnection("Garner Rd E", "Rymal at Garth", Colour.BLUE);
            hamiltonSubway.InsertConnection("Rymal at Garth", "Rymal at Upper James", Colour.BLUE);
            hamiltonSubway.InsertConnection("Rymal at Upper James", "Rymal at Upper Wellington", Colour.BLUE);
            hamiltonSubway.InsertConnection("Rymal at Upper Wellington", "Rymal at Upper Sherman", Colour.BLUE);
            hamiltonSubway.InsertConnection("Rymal at Upper Sherman", "Rymal at Upper Ottawa", Colour.BLUE);
            hamiltonSubway.InsertConnection("Rymal at Upper Ottawa", "Rymal at Highland", Colour.BLUE);
            hamiltonSubway.InsertConnection("Rymal at Highland", "Elfrida", Colour.BLUE);
            //White line
            //hamiltonSubway.InsertStation("Ancaster"); - from here on I made an insert connection for stations that were already inserted, just so I can see all the stations
            //in that line at once, but because I commented it out it doesn't do anything
            hamiltonSubway.InsertStation("Dundas");
            hamiltonSubway.InsertStation("Cootes at Main");
            hamiltonSubway.InsertStation("Main at GO");
            hamiltonSubway.InsertStation("Main at Barton");
            hamiltonSubway.InsertStation("Main at Burlington");
            hamiltonSubway.InsertStation("Main at Kenilworth");
            hamiltonSubway.InsertStation("Main at Parkdale");
            hamiltonSubway.InsertStation("Upper Centennial at Queenston");
            //White line connections
            hamiltonSubway.InsertConnection("Ancaster", "Dundas", Colour.WHITE);
            hamiltonSubway.InsertConnection("Dundas", "Cootes at Main", Colour.WHITE);
            hamiltonSubway.InsertConnection("Cootes at Main", "Main at GO", Colour.WHITE);
            hamiltonSubway.InsertConnection("Main at GO", "Main at Barton", Colour.WHITE);
            hamiltonSubway.InsertConnection("Main at Barton", "Main at Burlington", Colour.WHITE);
            hamiltonSubway.InsertConnection("Main at Burlington", "Main at Kenilworth", Colour.WHITE);
            hamiltonSubway.InsertConnection("Main at Kenilworth", "Main at Parkdale", Colour.WHITE);
            hamiltonSubway.InsertConnection("Main at Parkdale", "Upper Centennial at Queenston", Colour.WHITE);

            //Yellow line
            hamiltonSubway.InsertStation("Queen Elizabeth Way");
            hamiltonSubway.InsertStation("Confederation");
            hamiltonSubway.InsertStation("Upper Centennial at C.N.R.");
            //hamiltonSubway.InsertStation("Upper Centennial at Queenston");
            hamiltonSubway.InsertStation("Upper Centennial at King");
            hamiltonSubway.InsertStation("Punchbowl");
            hamiltonSubway.InsertStation("Upper Centennial at Green Mountain");
            hamiltonSubway.InsertStation("Upper Centennial at Mud");
            //hamiltonSubway.InsertStation("Elfrida");
            hamiltonSubway.InsertStation("Binbrook"); //funny name hehe
            //Yellow line connections
            hamiltonSubway.InsertConnection("Queen Elizabeth Way", "Confederation", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Confederation", "Upper Centennial at C.N.R.", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Upper Centennial at C.N.R.", "Upper Centennial at Queenston", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Upper Centennial at Queenston", "Upper Centennial at King", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Upper Centennial at King", "Punchbowl", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Punchbowl", "Upper Centennial at Green Mountain", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Upper Centennial at Green Mountain", "Upper Centennial at Mud", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Upper Centennial at Mud", "Elfrida", Colour.YELLOW);
            hamiltonSubway.InsertConnection("Elfrida", "Binbrook", Colour.YELLOW);

            //Orange line
            hamiltonSubway.InsertStation("Airport");
            //hamiltonSubway.InsertStation("Rymal at Upper James");
            hamiltonSubway.InsertStation("Upper James at 5th St");
            //hamiltonSubway.InsertStation("Main at GO");
            hamiltonSubway.InsertStation("West Harbour");
            //Orange line connections
            hamiltonSubway.InsertConnection("Airport", "Rymal at Upper James", Colour.ORANGE);
            hamiltonSubway.InsertConnection("Rymal at Upper James", "Upper James at 5th St", Colour.ORANGE);
            hamiltonSubway.InsertConnection("Upper James at 5th St", "Main at GO", Colour.ORANGE);
            hamiltonSubway.InsertConnection("Main at GO", "West Harbour", Colour.ORANGE);

            //Green line (GO train)
            hamiltonSubway.InsertStation("Aldershot");
            //hamiltonSubway.InsertStation("West Harbour");
            //hamiltonSubway.InsertStation("Confederation");
            //Green line connections
            hamiltonSubway.InsertConnection("Aldershot", "West Harbour", Colour.GREEN);
            hamiltonSubway.InsertConnection("West Harbour", "Confederation", Colour.GREEN);

            // hamiltonSubway.RemoveStation("Rymal at Upper James");
            hamiltonSubway.ShortestRoute("Ancaster","Rymal at Upper Sherman");

            // hamiltonSubway.PrintGraph();
            Console.ReadLine();
        }
    }
}

