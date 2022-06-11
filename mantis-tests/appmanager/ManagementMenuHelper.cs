using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        static string baseURL = "http://localhost/mantisbt-2.25.4/";
        public static string ManagementPage = baseURL + "manage_overview_page.php";
        public static string ProjectManagementTab = baseURL + "manage_proj_page.php";
        public static string ProjectCreationPage = baseURL + "manage_proj_create_page.php";
        public static string LoginPage = baseURL + "login_page.php";

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