using StudentServiceLib;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Student std;
        [TestInitialize]
        public void init()
        {
            std = new Student();
        }

        private List<Student> students;

        public void init1()
        {
            students = new List<Student>();
        }
        

        [TestMethod]
        [DataRow("Dung", 18, 8, 'A')]
        [DataRow("Nam", 18, 7, 'B')]
        [DataRow("Duong", 18, 5, 'C')]
        [DataRow("Duy", 18, 3.4, 'E')]
        public void TestMultiplecases_letterScore(String name, int age, double score, char expect)
        {
            std.Name = name;
            std.Age = age;
            std.Score = score;
            char letter = std.getLetterScore();
            Assert.AreEqual(expect, letter);
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException))]
        [DataRow(-1)]
        [DataRow(11)]
        [DataRow(5)]
        public void exceptionShouldThrow_ifScoreOutOfRange(double score)
        {          
            std.Score = score;
        }

        [TestMethod]
        [DataRow(1, "Dung", 18)]
        [DataRow(2, "Duong", 18)]
        [DataRow(31, "Hung", 18)]
        [DataRow(1, "Tung", 18)]
        public void testAddStudent(int id, String name, int age)
        {
            std = new Student();
            std.Id = id;
            std.Name = name;
            std.Age = age;

            students.Add(std);
        }
    }
}