// using UtilityLibraries;
namespace Graph;

[TestClass]
public class Test_InsertConnection
{
    [TestMethod]
    public void TestInsertConnection_BaseCase_CorrectInput()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        // calculates result
        bool result = subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);

        Assert.IsTrue(result);
    }
    [TestMethod]
    public void TestInsertConnection_Empty_or_Vacant()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        subwayMap.InsertStation("Third_Station");
        subwayMap.InsertStation("Fourth_Station");

        // calculates result
        bool result_1 = subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED); // both empty
        bool result_2 = subwayMap.InsertConnection("First_Station", "Third_Station", Colour.RED); // Second empty
        bool result_3 = subwayMap.InsertConnection("Fourth_Station", "Second_Station", Colour.RED); // both vacant
        bool result_4 = subwayMap.InsertConnection("Fourth_Station", "First_Station", Colour.RED); // first empty

        Assert.IsTrue(result_1);
        Assert.IsTrue(result_2);
        Assert.IsTrue(result_3);
        Assert.IsTrue(result_4);

    }
    [TestMethod]
    public void TestInsertConnection_SameStation_DifferentColor()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        // calculates result
        subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);
        bool result = subwayMap.InsertConnection("First_Station", "Second_Station", Colour.BLUE);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestInsertConnection_StationMissing()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        // calculates result
        bool result = subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestInsertConnection_ConnectionExists()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");

        subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);
        // calculates result
        bool result = subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);

        Assert.IsFalse(result);
    }
    [TestMethod]
    // if it is contained in both graphs
    // how to check the connections with just this
    public void TestInsertConnection_Is_UnDirected()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);
        //shows the first station can traverse to the second and second can traverse to the first
        bool result_1 = subwayMap.ShortestRoute("First_Station", "Second_Station");
        bool result_2 = subwayMap.ShortestRoute("Second_Station", "First_Station");
        Assert.IsTrue(result_1);
        Assert.IsTrue(result_2);
    }
}

[TestClass]
public class Test_InsertStation
{
    [TestMethod]
    public void TestInsertStation_Valid_Station()
    {
        SubwayMap subwayMap = new SubwayMap();
        // calculates result
        bool result = subwayMap.InsertStation("First_Station");
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void TestInsertStation_StationExists()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        // calculates result
        bool result = subwayMap.InsertStation("First_Station");
        Assert.IsFalse(result);
    }
}

[TestClass]
public class Test_RemoveConnection
{
    [TestMethod]
    public void TestRemoveConnection_ConnectionExists_CorrectInput()
    {
        // insert connection first
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        // calculates result
        subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);

        bool result = subwayMap.RemoveConnection("First_Station", "Second_Station", Colour.RED);
        Assert.IsTrue(result);

    }
    [TestMethod]
    public void TestRemoveConnection_ConnectionExists_IncorrectWeight()
    {
        // insert connection first
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        // calculates result
        subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);

        bool result = subwayMap.RemoveConnection("First_Station", "Second_Station", Colour.YELLOW);
        Assert.IsFalse(result);
    }
    [TestMethod]

    public void TestRemoveConnection_Nonexistent_Connection()
    {
        // insert connection first
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        // calculates result
        bool result = subwayMap.RemoveConnection("First_Station", "Second_Station", Colour.YELLOW);
        Assert.IsFalse(result);
    }
    [TestMethod]

    public void TestRemoveConnection_Nonexistent_Station()
    {
        // insert connection first
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        // calculates result
        bool result = subwayMap.RemoveConnection("First_Station", "Second_Station", Colour.YELLOW);
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void TestRemoveConnection_ReinsertConnection()
    {
        // checks if you can reinsert the connection, confirms its completely gone.
        // insert connection first
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");
        subwayMap.InsertConnection("First_Station", "Second_Station", Colour.YELLOW);
        // calculates result
        subwayMap.RemoveConnection("First_Station", "Second_Station", Colour.YELLOW);

        bool result = subwayMap.InsertConnection("First_Station", "Second_Station", Colour.YELLOW);

        Assert.IsTrue(result);
    }
}

[TestClass]
public class Test_RemoveStation
{
    [TestMethod]
    public void TestRemoveStation_StationRemoved()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        // calculates result
        bool result = subwayMap.RemoveStation("First_Station");
        Assert.IsTrue(result);
    }
    public void TestRemoveStation_Station_Does_Not_Exist()
    {
        SubwayMap subwayMap = new SubwayMap();
        // calculates result
        bool result = subwayMap.RemoveStation("First_Station");
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void TestRemoveStation_ConnectionsRemoved()
    {
        // make a station 
        // make a connection
        // remove one station
        // if remove connection returns false then there is no connection and the connections were already removed by remove station.
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("First_Station");
        subwayMap.InsertStation("Second_Station");

        subwayMap.InsertConnection("First_Station", "Second_Station", Colour.RED);

        subwayMap.RemoveStation("First_Station");
        // make sure both stations still exist.
        subwayMap.InsertStation("First_Station");
        bool result = subwayMap.RemoveConnection("First_Station", "Second_Station", Colour.RED);
        Assert.IsFalse(result);
    }
}

[TestClass]
public class Test_ShortestRoute
{
    [TestMethod]
    public void TestShortestRoute_ValidPath()
    {
        SubwayMap subwayMap = new SubwayMap();

        subwayMap.InsertStation("1");
        subwayMap.InsertStation("2");
        subwayMap.InsertStation("3");
        subwayMap.InsertStation("4");
        subwayMap.InsertStation("5");

        subwayMap.InsertConnection("1", "2", Colour.RED);
        subwayMap.InsertConnection("2", "3", Colour.RED);
        subwayMap.InsertConnection("3", "4", Colour.RED);
        subwayMap.InsertConnection("4", "5", Colour.RED);

        bool result = subwayMap.ShortestRoute("1", "5");
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void TestShortestRoute_SameStation()
    {
        SubwayMap subwayMap = new SubwayMap();

        subwayMap.InsertStation("1");
        subwayMap.InsertStation("2");
        subwayMap.InsertConnection("1", "2", Colour.RED);

        bool result = subwayMap.ShortestRoute("1", "1");

        Assert.IsFalse(result);
    }
    [TestMethod]
    public void TestShortestRoute_Station_NonExistent()
    {
        SubwayMap subwayMap = new SubwayMap();

        subwayMap.InsertStation("1");
        subwayMap.InsertStation("2");
        subwayMap.InsertConnection("1", "2", Colour.RED);

        bool result = subwayMap.ShortestRoute("1", "3");

        Assert.IsFalse(result);
    }
    [TestMethod]
    public void TestShortestRoute_Stations_Not_connected()
    {
        SubwayMap subwayMap = new SubwayMap();

        subwayMap.InsertStation("1");
        subwayMap.InsertStation("2");
        subwayMap.InsertStation("3");
        subwayMap.InsertStation("4");
        subwayMap.InsertStation("5");
        // 2 and 3 not connected so 1 and 5 are not
        subwayMap.InsertConnection("1", "2", Colour.RED);
        subwayMap.InsertConnection("3", "4", Colour.RED);
        subwayMap.InsertConnection("4", "5", Colour.RED);

        bool result = subwayMap.ShortestRoute("1", "5");
        Assert.IsFalse(result);
    }
}