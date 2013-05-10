<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:in="http://www.composite.net/ns/transformation/input/1.0"
xmlns:lang="http://www.composite.net/ns/localization/1.0"
xmlns:f="http://www.composite.net/ns/function/1.0"
xmlns="http://www.w3.org/1999/xhtml"
exclude-result-prefixes="xsl in lang f"
xmlns:msxsl="urn:schemas-microsoft-com:xslt"
xmlns:csharp="http://c1.composite.net/csharp">

	<xsl:param name="mailingLists" select="/in:inputs/in:result[@name='MailingLists']" />
	<xsl:param name="subscribeEmail" select="/in:inputs/in:result[@name='SubscribeEmail']" />
	<xsl:param name="subscribeName" select="/in:inputs/in:result[@name='SubscribeName']" />
	<xsl:param name="subscribeButton" select="/in:inputs/in:result[@name='SubscribeButton']" />
	<xsl:param name="confirmEmailTemplate" select="/in:inputs/in:param[@name='ConfirmEmailTemplate']" />
	<xsl:param name="confirmEmail" select="/in:inputs/in:result[@name='ConfirmEmail']" />
	<xsl:param name="mailingListDefinitions" select="/in:inputs/in:result[@name='GetMailingListDefinitionsXml']/*" />
	<msxsl:script implements-prefix="csharp" language="C#">
		<msxsl:assembly name="Composite.Community.Newsletter.SubjectBased" />
		<msxsl:assembly name="System.Xml.Linq" />
		<msxsl:using namespace="System.Xml.Linq" />
		<msxsl:using namespace="Composite.Community.Newsletter.SubjectBased" /><![CDATA[
    public XPathNodeIterator Subscribe(string memberEmail, string memberName, string mailingLists, string confirmEmailTemplate, string confirmEmail)
    {
	return new XElement("results", MailingListFacade.Subscribe(memberEmail, memberName, mailingLists, confirmEmailTemplate, confirmEmail)).CreateNavigator().Select(".");
    }
   ]]>
	</msxsl:script>
	<xsl:template match="/">
		<html>
			<head>
				<link rel="stylesheet" type="text/css" href="~/Frontend/Composite/Community/Newsletter/Styles.css" />
			</head>
			<body>
				<asp:form xmlns:asp="http://www.composite.net/ns/asp.net/controls">
					<div id="newsletter">
						<div>
							<xsl:choose>
								<xsl:when test="$subscribeButton != '' or $confirmEmail != ''">
									<xsl:variable name="results" select="csharp:Subscribe($subscribeEmail,$subscribeName, $mailingLists, $confirmEmailTemplate, $confirmEmail)" />
									<div class="Error">
										<xsl:for-each select="$results/Error">
											<p>
												<xsl:value-of select="." />
											</p>
										</xsl:for-each>
									</div>
									<div class="Confirm">
										<xsl:for-each select="$results/Confirm">
											<p>
												<xsl:value-of select="." />
											</p>
										</xsl:for-each>
									</div>
									<div class="Success">
										<xsl:for-each select="$results/Success">
											<p>
												<xsl:value-of select="." />
											</p>
										</xsl:for-each>
										<xsl:if test="count($results/Warning) &gt; 0">
											<span class="Warning">
												<lang:string key="Resource, Resources.Newsletter.MemberAlreadySubscribed" />
												<xsl:for-each select="$results/Warning">
													<p>
														<xsl:value-of select="." />
													</p>
												</xsl:for-each>
											</span>
										</xsl:if>
									</div>
									<xsl:if test="count($results/Success) = 0 and count($results/Confirm) = 0">
										<xsl:call-template name="Form" />
									</xsl:if>
								</xsl:when>
								<xsl:otherwise>
									<xsl:call-template name="Form" />
								</xsl:otherwise>
							</xsl:choose>
						</div>
					</div>
				</asp:form>
			</body>
		</html>
	</xsl:template>
	<xsl:template name="Form">
		<label style="display:none;">
			<lang:string key="Resource, Resources.Newsletter.MemberName" />
		</label>
		<input style="display:none;" name="SubscribeName" value="{$subscribeName}" />
		<label style="display:none;">
			<lang:string key="Resource, Resources.Newsletter.MemberEmail" />
		</label>
		<xsl:variable name="EmailText">
			<xsl:text><lang:string key="Resource, Resources.Localization.TypeEmail" /></xsl:text>
		</xsl:variable>
		<div class="wrapper">
			<input class="input" name="SubscribeEmail" value="{$subscribeEmail}" placeholder="{$EmailText}" />
		</div>
		<br />
		<label style="display:none;">
			<lang:string key="Resource, Resources.Newsletter.MailingLists" />
		</label>
		<div class="Checkbox" style="display:none;">
			<xsl:for-each select="$mailingListDefinitions">
				<div>
					<input type="checkbox" name="MailingLists[]" id="id{translate(@Id,'-','')}" value="{@Id}">
						<xsl:if test="contains($mailingLists, @Id) or (count($mailingListDefinitions) = 1)">
							<xsl:attribute name="checked">checked</xsl:attribute>
						</xsl:if>
					</input>
					<label for="d{translate(@Id,'-','')}">
						<xsl:value-of select="@Title" />
					</label>
					<label class="Description">
						<xsl:value-of select="@Description" />
					</label>
				</div>
			</xsl:for-each>
		</div>
		<xsl:variable name="subscribeButtonLabel">
			<xsl:text><lang:string key="Resource, Resources.Localization.Subscribe" /></xsl:text>
		</xsl:variable>
		<input name="SubscribeButton" type="submit" class="Submit" value="{$subscribeButtonLabel}" />
	</xsl:template>
</xsl:stylesheet>