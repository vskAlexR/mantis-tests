using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public static string ManagementPage = "http://localhost/mantisbt-2.25.4/manage_overview_page.php";
        public static string ProjectManagementTab = "http://localhost/mantisbt-2.25.4/manage_proj_page.php";
        public static string ProjectCreationPage = "http://localhost/mantisbt-2.25.4/manage_proj_create_page.php";
        public static string LoginPage = "http://localhost/mantisbt-2.25.4/login_page.php";

        public ManagementMenuHelper(AppManager manager) : base(manager)
        {
        }

        public void GoToManagementPage()
        {
            driver.Navigate().GoToUrl(ManagementPage);
        }

        public void GoToProjectManagementTab()
        {
            driver.Navigate().GoToUrl(ProjectManagementTab);
        }

        public void GoToProjectCreationPage()
        {
            driver.Navigate().GoToUrl(ProjectCreationPage);
        }

        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(LoginPage);
        }
    }
}