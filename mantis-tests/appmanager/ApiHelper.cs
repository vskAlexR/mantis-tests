using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;


namespace mantis_tests
{
    public class ApiHelper : HelperBase
    {
        public ApiHelper(AppManager manager) : base(manager)
        {
        }
        public void CreateNewIssue(AccountData account, MantisData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_addAsync(account.Name, account.Password, issue);
        }
        public List<MantisData> GetProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            List<MantisData> projects = new List<MantisData>();
            foreach (Mantis.ProjectData mantisProject in mantisProjects)
            {
                projects.Add(new MantisData() { Name = mantisProject.name, Id = mantisProject.id });
            }
            return projects;
        }

        public void CreateNewProject(AccountData account, MantisData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.name = project.Name;
            client.mc_project_addAsync(account.Name, account.Password, projectData);
        }

        public void DeleteProject(AccountData account, MantisData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_deleteAsync(account.Name, account.Password, project.Id);
        }

        public void IsProjectExist(List<MantisData> oldProjects, AccountData account, MantisData project)
        {
            if (oldProjects.Count() == 0)
            {
                CreateNewProject(account, project);
            }
        }
    }
}