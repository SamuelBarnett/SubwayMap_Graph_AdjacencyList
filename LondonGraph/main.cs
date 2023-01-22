using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        SubwayMap Subway = new SubwayMap();
        Subway.InsertStation("Canada");
        Subway.InsertStation("Mexico");
        Subway.InsertStation("US");
        Subway.InsertStation("Netherlands");
        Subway.InsertStation("Russia");

        Subway.InsertConnection("Canada", "Mexico", Colour.BLUE);
        /*Subway.PrintStations();*/
        /*Subway.PrintGraph();*/
        Subway.InsertConnection("Canada", "US", Colour.GREEN);
        Subway.InsertConnection("Russia", "Netherlands", Colour.GREEN);
        Subway.InsertConnection("Canada", "asd", Colour.RED);
        /*Subway.PrintStations();*/
        /*Subway.PrintGraph();*/

        /*Subway.PrintStations();*/
        Subway.PrintGraph();
    }
}
