<%@ Page Language="C#" AutoEventWireup="true" CodeFile="statistics.aspx.cs" Inherits="Composite_InstalledPackages_content_views_newsletter_statistics" %>

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:ui="http://www.w3.org/1999/xhtml"
xmlns:control="http://www.composite.net/ns/uicontrol">
<control:httpheaders runat="server" />
<head>
	<title>Composite.Community.Newsletter</title>
	<control:styleloader runat="server" />
	<control:scriptloader type="sub" runat="server" />
	<link rel="stylesheet" type="text/css" href="statistics.css.aspx" />
</head>
<body id="root">
	<form id="Form1" runat="server">
	<asp:ScriptManager ID="SM1" runat="server" ScriptMode="Debug">
		<Scripts>
			<asp:ScriptReference Name="MicrosoftAjaxWebForms.js" Path="../../../../scripts/aspnetajax/MicrosoftAjaxWebForms.js" />
			<asp:ScriptReference Name="MicrosoftAjax.js" Path="../../../../scripts/aspnetajax/MicrosoftAjax.js" />
			<asp:ScriptReference Name="MicrosoftAjaxTimer.js" Path="../../../../scripts/aspnetajax/MicrosoftAjaxTimer.js" />
		</Scripts>
	</asp:ScriptManager>
	<ui:page id="page" image="${icon:report}">
		<ui:toolbar>
			<ui:toolbarbody>
				<ui:toolbargroup>
					<aspui:toolbarbutton id="ToolBarButton1" autopostback="true" text="Refresh" imageurl="${icon:refresh}"
						runat="server" onclick="ContentChanged" />
				</ui:toolbargroup>
			</ui:toolbarbody>
		</ui:toolbar>
		<ui:scrollbox id="scrollbox">
			<div id="ContentUpdatePanel">
				<asp:PlaceHolder ID="Holder" runat="server" />
			</div>
		</ui:scrollbox>
	</ui:page>
	</form>
</body>
</html>
