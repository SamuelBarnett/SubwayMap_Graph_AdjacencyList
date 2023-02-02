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
    public void TestRemoveConnection_ConnectionExists_CorrectWeight()
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
}

[TestClass]
public class Test_RemoveStation
{
    [TestMethod]
    public void TestRemoveStation()
    {
    }
}

[TestClass]
public class Test_ShortestRoute
{
    [TestMethod]
    public void TestShortestRoute()
    {

    }
}