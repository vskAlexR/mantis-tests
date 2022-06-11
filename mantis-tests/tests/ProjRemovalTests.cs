using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            app.Projects.CreateProjectIfDoesNotExists();

            List<MantisData> projects = app.Projects.GetProjectsList();
            MantisData remove = projects[0];

            app.Projects.RemoveProject(remove);

            List<MantisData> newProjects = app.Projects.GetProjectsList();
            projects.Remove(remove);
            projects.Sort();
            newProjects.Sort();

            Assert.AreEqual(projects, newProjects);
        }
    }
}