using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(AppManager manager) : base(manager)
        {
        }

        internal void CreateProjectIfDoesNotExists()
        {
            if (GetProjectsCount() == 0)
            {
                MantisData project = new MantisData()
                {
                    Name = "123",
                    Description = "321"
                };

                CreateProject(project);
            }
        }

        public List<MantisData> GetProjectsList()
        {
            manager.Navigation.GoToProjectManagementTab();
            List<MantisData> projects = new List<MantisData>();

            var rows = GetProjectsTable();
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.CssSelector("td"));
                projects.Add(new MantisData()
                {
                    Name = cells[0].Text,
                    Description = cells[4].Text
                });
            }

            return projects;
        }

        public int GetProjectsCount()
        {
            manager.Navigation.GoToProjectManagementTab();
            var rows = GetProjectsTable();

            return rows.Count;
        }

        public IReadOnlyCollection<IWebElement> GetProjectsTable()
        {
            var tables = driver.FindElements(By.ClassName("table"));
            var projectsTable = tables[0].FindElement(By.XPath($"//*/tbody"));
            var rows = projectsTable.FindElements(By.CssSelector("tr"));
            return rows;
        }

        public void CreateProject(MantisData project)
        {
            manager.Navigation.GoToProjectCreationPage();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void SelectProjectByName(MantisData project)
        {
            manager.Navigation.GoToProjectManagementTab();
            var projectEditUrls = driver.FindElements(By.XPath($"(//a[text()='{project.Name}'])"));
            driver.Navigate().GoToUrl(projectEditUrls[1].GetAttribute("href"));
        }

        public void RemoveProject(MantisData project)
        {
            SelectProjectByName(project);
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
    }
}