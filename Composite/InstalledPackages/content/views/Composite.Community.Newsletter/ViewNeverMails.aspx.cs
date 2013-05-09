using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Composite.Data;
using Composite.Community.Newsletter.Data.Types;

public partial class Composite_InstalledPackages_content_views_ViewNeverMails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		using (DataConnection conn = new DataConnection())
		{
			var items = conn.Get<INeverMail>().ToList();
			ListView lvEmails = (ListView)this.FindControl("lvEmails");
			if (lvEmails != null)
			{
				lvEmails.DataSource = items;
				lvEmails.DataBind();
			}
		}
    }
}