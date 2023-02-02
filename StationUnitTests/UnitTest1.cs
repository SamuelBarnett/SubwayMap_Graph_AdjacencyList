// using UtilityLibraries;

namespace Graph;

[TestClass]
public class Test_InsertConnection
{
    [TestMethod]
    public void TestInsertConnection_BaseCase_CorrectInput()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("A");
        subwayMap.InsertStation("B");
        bool expected = true;
        // calculates result
        bool result = subwayMap.InsertConnection("A", "B", Colour.RED);
        
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void TestInsertConnection_InCorrectStation()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("A");
        bool expected = false;
        // calculates result
        bool result = subwayMap.InsertConnection("A", "B", Colour.RED);
        
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void TestInsertConnection_DuplicateConnection()
    {
        SubwayMap subwayMap = new SubwayMap();
        subwayMap.InsertStation("A");
        subwayMap.InsertStation("B");
        subwayMap.InsertConnection("A", "B", Colour.RED);
        bool expected = false;
        // calculates result
        bool result = subwayMap.InsertConnection("A", "B", Colour.RED);
        
        Assert.AreEqual(expected, result);
    }
}