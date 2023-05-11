namespace UnitTests
{
    [TestClass]
    public class FilesDirectoryCreationTest
    {
        [TestMethod]
        public void DataFileExistingCheck()
        {
            var path = Directory.GetCurrentDirectory() + "\\Files";
            if (Directory.Exists(path)) Directory.Delete(path);
            TasksMethods.FilesDirectoryEnsureCreated(path);
            var actual = Directory.Exists(path);
            const bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}