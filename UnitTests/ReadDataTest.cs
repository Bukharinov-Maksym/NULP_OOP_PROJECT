namespace UnitTests
{
    [TestClass]
    public class ReadDataTest
    {
        [TestMethod]
        public void ReadDataMethodTest()
        {
            var path = Directory.GetCurrentDirectory() + "\\ReadDataTest.txt";
            var animals = new Animal[File.ReadLines(path).Count()];
            TasksMethods.ReadFromFile(animals, path);
            var actualName = animals[0].Name;
            const string expectedName = "HORSE_NAME1";
            Assert.AreEqual(expectedName, actualName);
        }
    }
}