using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonGraph
{
    class SubwayGraph
    {
        public static void Main()
        {
            SubwayMap Subway = new SubwayMap();
            Subway.InsertStation("Canada");
            Subway.InsertStation("Mexico");
            Subway.InsertStation("US");
            Subway.InsertStation("Netherlands");
            Subway.InsertStation("Russia");

            Subway.InsertConnection("Canada", "US", Colour.GREEN);
            Subway.InsertConnection("Canada", "US", Colour.RED);
            Subway.InsertConnection("Canada", "US", Colour.BLUE);
            Subway.InsertConnection("Mexico", "US", Colour.YELLOW);
            Subway.InsertConnection("Canada", "US", Colour.YELLOW);
            // Subway.RemoveConnection("Canada", "US", Colour.BLUE);

            Subway.RemoveStation("Mexico");

            Subway.PrintGraph();
        }
    }
}

