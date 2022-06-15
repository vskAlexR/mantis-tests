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
        [Test]
        public void ProjectsRemovalApi()
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

            List<MantisData> oldProjects = app.Api.GetProjects(account); ;
            MantisData toBeRemoved = oldProjects[0];

            app.Api.IsProjectExist(oldProjects, account, project);

            app.Projects.RemoveProject(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Api.GetProjects(account).Count());

            List<MantisData> newProjects = app.Api.GetProjects(account);

            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);

            foreach (MantisData newProject in newProjects)
            {
                Assert.AreNotEqual(newProject.Id, toBeRemoved.Id);
            }
        }
    }
}