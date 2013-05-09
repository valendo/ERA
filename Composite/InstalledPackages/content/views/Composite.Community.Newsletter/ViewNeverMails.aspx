<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNeverMails.aspx.cs" Inherits="Composite_InstalledPackages_content_views_ViewNeverMails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>View Never Me Mails</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:ListView ID="lvEmails" runat="server">
			<LayoutTemplate>
				<ul>
					<asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
				</ul>
			</LayoutTemplate>
			<ItemTemplate>
				<li>
					<%#Eval("Email")%></li>
			</ItemTemplate>
			<EmptyDataTemplate><p>No data</p></EmptyDataTemplate>
		</asp:ListView>
	</div>
	</form>
</body>
</html>
