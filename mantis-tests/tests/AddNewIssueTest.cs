using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
	[TestFixture]
	public class AddNewIssue : TestBase
	{
		[Test]
		public void AddNewIssueTest()
		{
			AccountData account = new AccountData()
			{
				Name = "administrator",
				Password = "root"
			};
			MantisData project = new MantisData()
			{
				Id = "1"
			};
			IssueData issueData = new IssueData()
			{
				Summary = "some short text",
				Description = "some long text",
				Category = "General"
			};

			app.Api.CreateNewIssue(account, project, issueData);
		}
	}
}