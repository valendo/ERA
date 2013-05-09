<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:in="http://www.composite.net/ns/transformation/input/1.0" xmlns:lang="http://www.composite.net/ns/localization/1.0" xmlns:f="http://www.composite.net/ns/function/1.0" xmlns="http://www.w3.org/1999/xhtml" exclude-result-prefixes="xsl in lang f">
	<xsl:variable name="FooterLinks" select="/in:inputs/in:result[@name='GetFooterLinkXml']/FooterLink" />
	<xsl:template match="/">
		<html>
			<head>
				<!-- markup placed here will be shown in the head section of the rendered page -->
			</head>
			<body>
				<h4><lang:string key="Resource, Resources.Localization.AboutUs" xmlns:lang="http://www.composite.net/ns/localization/1.0" /></h4>
				<ul class="list1">
					<xsl:for-each select="$FooterLinks">
						<li>
							<a href="~/Renderers/Page.aspx?pageId={@Page}">
								<xsl:choose>
									<xsl:when test="@Page.MenuTitle!=''">
										<xsl:value-of select="@Page.MenuTitle" />
									</xsl:when>
									<xsl:otherwise>
										<xsl:value-of select="@Page.Title" />
									</xsl:otherwise>
								</xsl:choose>
							</a>
						</li>
					</xsl:for-each>
				</ul>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>