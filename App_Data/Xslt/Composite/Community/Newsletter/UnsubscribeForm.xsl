<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:in="http://www.composite.net/ns/transformation/input/1.0"
				xmlns:lang="http://www.composite.net/ns/localization/1.0"
				xmlns:f="http://www.composite.net/ns/function/1.0"
				xmlns="http://www.w3.org/1999/xhtml"
				exclude-result-prefixes="xsl in lang f">
	<xsl:param name="mailingListId" select="/in:inputs/in:result[@name='MailingListId']" />
	<xsl:param name="unsubscribeButton" select="/in:inputs/in:result[@name='UnsubscribeButton']" />
	<xsl:param name="mailingListDefinition" select="/in:inputs/in:result[@name='GetMailingListDefinitionsXml']/*[@Id=$mailingListId and @Unsubscribe='true']" />
	<xsl:template match="/">
		<html>
			<head>
				<link rel="stylesheet" type="text/css" href="~/Frontend/Composite/Community/Newsletter/Styles.css" />
			</head>
			<body>
				<asp:form xmlns:asp="http://www.composite.net/ns/asp.net/controls">
					<div id="UnsubscribeeForm" class="NewsletterForm">
						<h1>
							<xsl:choose>
								<xsl:when test="count($mailingListDefinition) = 0">
									<lang:string key="Resource, Resources.Newsletter.UnsubscribeFromAll" />
								</xsl:when>
								<xsl:otherwise>
									<lang:string key="Resource, Resources.Newsletter.Unsubscribe" />
								</xsl:otherwise>
							</xsl:choose>
						</h1>
						<xsl:if test="not($unsubscribeButton = '')">
							<!--Form submitted-->
							<xsl:choose>
								<xsl:when test="count($mailingListDefinition) = 0">
									<f:function name="Composite.Community.Newsletter.UnsubscribeEmail">
										<f:param name="email" value="{/in:inputs/in:result[@name='UnsubscribeEmail']}" />
									</f:function>
								</xsl:when>
								<xsl:otherwise>
									<f:function name="Composite.Community.Newsletter.Unsubscribe">
										<f:param name="memberEmail" value="{/in:inputs/in:result[@name='UnsubscribeEmail']}" />
										<f:param name="mailingListId" value="{$mailingListId}" />
									</f:function>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:if>
						<fieldset class="Fields">
							<label>
								<lang:string key="Resource, Resources.Newsletter.MemberEmail" />
							</label>
							<input name="UnsubscribeEmail" value="{/in:inputs/in:result[@name='UnsubscribeEmail']}" />
							<br />
							<xsl:if test="count($mailingListDefinition) != 0">
								<label>
									<lang:string key="Resource, Resources.Newsletter.MailingList" />
								</label>
								<div class="Checkbox">
									<label>
										<xsl:value-of select="/in:inputs/in:result[@name='GetMailingListDefinitionsXml']/MailingList[@Id=$mailingListId]/@Title" />
									</label>
									<label class="Description">
										<xsl:value-of select="/in:inputs/in:result[@name='GetMailingListDefinitionsXml']/MailingList[@Id=$mailingListId]/@Description" />
									</label>
								</div>
								<br />
							</xsl:if>
						</fieldset>
						<fieldset class="Buttons">
							<xsl:variable name="unsubscribeButtonLabel">
								<xsl:text><lang:string key="Resource, Resources.Newsletter.Unsubscribe" /></xsl:text>
							</xsl:variable>
							<input name="UnsubscribeButton" type="submit" class="Submit" value="{$unsubscribeButtonLabel}" />
						</fieldset>
					</div>
				</asp:form>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>