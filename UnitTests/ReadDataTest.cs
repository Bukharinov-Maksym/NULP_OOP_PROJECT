namespace UnitTests
{
    [TestClass]
    public class ReadDataTest
    {
        [TestMethod]
        public void ReadDataMethodTest()
        {
            var countLines = File.ReadAllLines("C:\\Users\\Sonnenaufgang\\source\\repos\\NULP_OOP_PROJECT\\Files\\data.txt");
            var animals = new Animal[countLines.Length];
            TasksMethods.ReadFromFile(animals, "C:\\Users\\Sonnenaufgang\\source\\repos\\NULP_OOP_PROJECT\\Files\\data.txt");
            var actualName = animals[0].Name;
            const string expectedName = "HORSE_NAME1";
            Assert.AreEqual(expectedName, actualName);
        }
    }
}