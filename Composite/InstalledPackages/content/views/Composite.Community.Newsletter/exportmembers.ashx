<%@ WebHandler Language="C#" Class="ExportMembers" %>

using System;
using System.Web;
using System.Linq;
using System.Xml.Linq;
using Composite.Core.IO;
using Composite.Community.Newsletter;

public class ExportMembers : IHttpHandler
{

	public void ProcessRequest(HttpContext context)
	{
		var mailingListId = new Guid(context.Request["mailingListId"]);
		var xml = (context.Request["xml"]??"false") == "true";
		var mailingList = MailingListProviderFacade.GetMailingListDefinitions().Where(m => m.Id == mailingListId).First();
		
		XElement table = new XElement("table");
		
		var members = MailingListProviderFacade.GetMemberChunk(mailingListId, int.MaxValue, string.Empty);
		var memberObjectTypes = MailingListProviderFacade.GetAvailableMemberObjectTypes(mailingListId);

		if(xml)
			context.Response.ContentType = "text/xml";
		else
			context.Response.ContentType = "application/vnd.ms-excel";

		context.Response.AddHeader("content-disposition", string.Format("attachment;filename=\"{0}_{1}.{2}\"", PathUtil.CleanFileName(mailingList.Title), Composite.Data.LocalizationScopeManager.CurrentLocalizationScope, xml?"xml":"xls"));

		if (xml)
		{
			table = new XElement("MailingList");
			table.Add(
					members.Select(
							m => new XElement("Member",
								memberObjectTypes.Select(t => new { Type = t, Object = m.GetMemberObject(t) }).Select(
									o => o.Type.GetProperties().Select(p => new XAttribute((memberObjectTypes.Count()>1)? (o.Type.Name + "."):"" + p.Name, p.GetValue(o.Object, null).ToString())
									)
								)
							)
					)

			);
		}
		else
		{
			table.Add(
					new XElement("tr",
						memberObjectTypes.Select(t => t.GetProperties().Select(p => new XElement("th", p.Name)))
					)
			);

			table.Add(
					members.Select(
							m => new XElement("tr",
								memberObjectTypes.Select(t => new { Type = t, Object = m.GetMemberObject(t) }).Select(
									o => o.Type.GetProperties().Select(p => new XElement("td", p.GetValue(o.Object, null).ToString())
									)
								)
							)
					)

			);
		}

		byte[] BOM = { 0xEF, 0xBB, 0xBF }; // The BOM for UTF-8 encoding.
		context.Response.BinaryWrite(BOM);		
		context.Response.Write(table.ToString());
		context.Response.Flush();
	}

	public bool IsReusable
	{
		get
		{
			return false;
		}
	}
}