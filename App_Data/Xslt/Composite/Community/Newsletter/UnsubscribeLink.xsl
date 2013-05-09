<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:in="http://www.composite.net/ns/transformation/input/1.0" xmlns:lang="http://www.composite.net/ns/localization/1.0" xmlns:f="http://www.composite.net/ns/function/1.0" xmlns="http://www.w3.org/1999/xhtml" exclude-result-prefixes="xsl in lang f msxsl csharp" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:csharp="http://c1.composite.net/sample/csharp">
	<xsl:param name="unsubscribePage" select="/in:inputs/in:param[@name='UnsubscribePage']" />
	<xsl:param name="mailingListId" select="/in:inputs/in:param[@name='MailingListId']" />
	<xsl:param name="unsubscribeEmail" select="/in:inputs/in:param[@name='UnsubscribeEmail']" />
	<xsl:param name="text" select="/in:inputs/in:param[@name='Text']" />
	<msxsl:script implements-prefix="csharp" language="C#">
	<msxsl:assembly name="System.Web" />
	<msxsl:using namespace="System.Web" />
	public String UrlEncodeUnicode( string source )
	{
		return HttpUtility.UrlEncode( source );
	}
	</msxsl:script>
	<xsl:template match="/">
		<html>
			<head></head>
			<body>
				<a href="~/Renderers/Page.aspx?pageId={$unsubscribePage}&amp;MailingListId={$mailingListId}&amp;UnsubscribeEmail={csharp:UrlEncodeUnicode($unsubscribeEmail)}">
					<xsl:value-of select="$text" />
				</a>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>