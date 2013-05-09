using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using Composite.Community.Newsletter;
using Composite.Community.Newsletter.Data.Types;
using Composite.Data;
using Composite.Data.Types;
using Composite.C1Console.Security;
using Composite.C1Console.Workflow;
using System.Text.RegularExpressions;
using System.Web;

public partial class Composite_InstalledPackages_content_views_newsletter_statistics : System.Web.UI.Page
{
	private int row = 0;

	protected void ContentChanged(Object sender, EventArgs e)
	{
		
	}

	protected void Page_PreRender(object sender, EventArgs e)
	{
		Guid newsletterId = new Guid(Request.QueryString["newsletterId"]);
		var result = new XElement("div");

		#region Common
		var statistics = new List<KeyValuePair<string, string>>();
		statistics.Add(Text("MembersSent"), DataFacade.GetData<IStatisticsPoints>(p => p.NewsletterId == newsletterId).Count().ToString());
		statistics.Add(Text("MembersOpen"), DataFacade.GetData<IStatisticsPoints>(p => p.NewsletterId == newsletterId && p.Points > 0 ).Count().ToString());
		result.Add(
			new XElement("div",
				new XAttribute("id","Info"),

				GetTable(statistics, Text("Summary"), Text("SummaryDescription"), string.Empty, Text("Members"))));
		#endregion

		Regex remail = new Regex(@"(?<=[\?&;]UnsubscribeEmail=)([^&]*)");

		#region Links
		var allLinks = from l in DataFacade.GetData<IStatisticsLinks>(p => p.NewsletterId == newsletterId).ToDataEnumerable().Cast<IStatisticsLinks>()
					group l by l.Link into lg
					select new { Link = lg.Key, Count = lg.Count(), match = remail.Match(lg.Key)};

		

		var links = allLinks.Where(l => !l.match.Success).Select(l => new {l.Link, l.Count});

		result.Add(GetTable(links, Text("Links"), Text("LinksDescription"), Text("Link"), Text("LinkClicks")));
		#endregion

		#region Domains by active users
		var domainsbyusers = from l in DataFacade.GetData<IStatisticsPoints>(p => p.NewsletterId == newsletterId && p.Points > 0).ToDataEnumerable().Cast<IStatisticsPoints>()
					group l by l.Email.Substring(l.Email.IndexOf('@')+1).Trim() into lg
					select new { Domain = lg.Key, Count = lg.Count() };
		result.Add(GetTable(domainsbyusers.OrderBy(f => f.Count), Text("DomainsByActiveUsers"), Text("DomainsByActiveUsersDescription"), Text("Domain"), Text("CountActiveUsers")));
		#endregion

		#region Domains by links click
		var domainsbyclick = from l in DataFacade.GetData<IStatisticsLinks>(p => p.NewsletterId == newsletterId ).ToDataEnumerable().Cast<IStatisticsLinks>().Where( sl => !remail.Match(sl.Link).Success)
							 group l by l.Email.Substring(l.Email.IndexOf('@')+1).Trim() into lg
							 select new { Domain = lg.Key, Sum = lg.Count() };
		result.Add(GetTable(domainsbyclick.OrderBy(f => f.Sum), Text("DomainsByClicks"), Text("DomainsByClicksDescription"), Text("Domain"), Text("CountClicks")));
		#endregion

		#region Unsubscribed
		var emails = from l in allLinks
					 where l.match.Success
					 select new { Email = HttpUtility.UrlDecode(l.match.Captures[0].Value) };
		result.Add(GetTable(emails, Text("UnsubscribedMembers"), Text("UnsubscribedMembersDescription"), Text("Email")));
		#endregion

		var statisticsLinks = from p in DataFacade.GetData<IStatisticsPoints>()
							  where p.NewsletterId == newsletterId
							  orderby p.Email
							  select new { 
								  p.Email, 
								  Icon = new XElement("img",
									  new XAttribute("src", StatisticsFacade.GetIcon(p.Points.Equals(0) ? "cancel-disabled" : "accept"))
									  ),
								  p.Points };

		result.Add(GetTable(statisticsLinks, Text("MemberActivity"), Text("MemberActivityDescription"), Text("Email"), Text("Opened"), Text("Points")));


		Holder.Controls.Add(new LiteralControl(result.ToString()));
	}

	private string Text(string text)
	{
		return MailingListProviderFacade.GetString(string.Format("Statistics.{0}",text));
	}

	private XElement GetRow<T>(IEnumerable<T> content)
	{
		XElement result = new XElement("tr",
			new XAttribute("class", "row"+(row++)%2));
		var i = 0;
		foreach (var item in content)
		{
			result.Add(
				new XElement("td",
					(i++) == 0 ? new XAttribute("class", "first") : new XAttribute("class", "other"),
					item)
			);
		}

		return result;
		
	}
	private IEnumerable<XElement> GetTable<T>(IEnumerable<T> content)
	{
		return GetTable(content, string.Empty, string.Empty);
	}

	private IEnumerable<XElement> GetTable<T>(IEnumerable<T> content, string caption, string description, params string[] headers)
	{
		row = 0;
		XElement result = new XElement("table", new XAttribute("cellspacing", 0));
		if (!string.IsNullOrEmpty(caption))
		{
			yield return new XElement("h1", caption);
		}
		if (!string.IsNullOrEmpty(description))
		{
			yield return new XElement("p", description);
		}
		if (content.Count()>0)
		{
			if (headers.Length > 0)
			{
				var i = 0;
				result.Add(new XElement("tr",
					headers.Select(
						h => new XElement("th",
							(i++) == 0 ? new XAttribute("class", "first") : new XAttribute("class", "other"),
							h)
					)
				));
			}
			var properties = typeof(T).GetProperties();
			foreach (var item in content)
			{
				result.Add(
					GetRow(properties.Select(p => p.GetValue(item, null)))
				);
			}
			yield return result;
		}
		else
		{
			yield return new XElement("p", Text("Empty"));
		}

	}
}

public static class Extenstion
{
	public static void Add(this List<KeyValuePair<string, string>> list, string key, string value)
	{
		list.Add(new KeyValuePair<string, string>(key, value));
	}
}
