using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job testJob;

        [TestInitialize]
        public void CreateNewJob()
        {
            testJob = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestSettingJobId()
        {

            Job job2 = new Job();
            Assert.AreEqual(1, testJob.Id);
            Assert.IsFalse(testJob.Equals(job2));
            Assert.IsTrue(job2.Id - testJob.Id == 1);
        }

        [TestMethod]
        public void TestJobsConstructorSetsAllFields()
        {

            Assert.AreEqual("Product tester", testJob.Name);
            Assert.AreEqual("ACME", testJob.EmployerName.Value);
            Assert.AreEqual("Desert", testJob.EmployerLocation.Value);
            Assert.AreEqual("Quality control", testJob.JobType.Value);
            Assert.AreEqual("Persistence", testJob.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {

            Job job2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsFalse(testJob.Equals(job2));

        }

        [TestMethod]
        public void TestJobsToStringReturnNewLines()
        {

            //Regex rgx = new Regex(@"^\n(.*)$\n");
            //Assert.IsTrue(rgx.IsMatch(testJob.ToString()));

            Assert.IsTrue(testJob.ToString().StartsWith("/n"));
            Assert.IsTrue(testJob.ToString().EndsWith("/n"));
        }

        [TestMethod]
        public void TestJobsToStringFormat()
        {

            string actual = testJob.ToString();
            Assert.IsTrue(actual.Contains("ID:") && actual.Contains("Name: ") && actual.Contains("Employer: ")
                && actual.Contains("Location: ") && actual.Contains("Position Type: ") && actual.Contains("Core Compentency: "));
        }

        [TestMethod]
        public void TestJobsToStringEmptyField()
        {
            Job job2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency());
            string actual = job2.ToString();
            //Assert.IsTrue(actual.EndsWith("Data not available/n"));
            Assert.IsTrue(actual.Contains("Core Compentency: Data not available"));
        }

        [TestMethod]
        public void TestJobsNonExist()
        {
            Job nullJob = new Job();
            Assert.AreEqual("OOPS! This job does not seem to exist.", nullJob.ToString());
        }

    }
}
