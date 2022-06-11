using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthBase
    {
        [Test]
        public void CreateProjectTest()
        {
            MantisData project = new MantisData()
            {
                Name = "12311",
                Description = "3344"
            };

            List<MantisData> projects = app.Projects.GetProjectsList();

            app.Projects.CreateProject(project);

            List<MantisData> newProjects = app.Projects.GetProjectsList();

            projects.Add(project);
            projects.Sort();
            newProjects.Sort();

            Assert.AreEqual(projects, newProjects);
        }
    }
}