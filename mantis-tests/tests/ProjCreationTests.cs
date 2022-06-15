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
                Name = GenerateRandomString(10),
                Description = "1234"
            };

            List<MantisData> projects = app.Projects.GetProjectsList();

            app.Projects.CreateProject(project);

            List<MantisData> newProjects = app.Projects.GetProjectsList();

            projects.Add(project);
            projects.Sort();
            newProjects.Sort();

            Assert.AreEqual(projects, newProjects);
        }
        [Test]
        public void CreateNewProjectAPI()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
                
            };
            MantisData project = new MantisData()
            {
                Name = GenerateRandomString(10)
            };

            List<MantisData> oldProjects = app.Api.GetProjects(account);

            app.Api.CreateNewProject(account, project);

            Assert.AreEqual(oldProjects.Count + 1, app.Api.GetProjects(account).Count());

            List<MantisData> newProjects = app.Api.GetProjects(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}