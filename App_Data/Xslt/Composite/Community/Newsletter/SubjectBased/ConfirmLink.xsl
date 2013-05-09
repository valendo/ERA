<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:in="http://www.composite.net/ns/transformation/input/1.0"
	xmlns:lang="http://www.composite.net/ns/localization/1.0"
	xmlns:f="http://www.composite.net/ns/function/1.0"
	xmlns="http://www.w3.org/1999/xhtml"
	xmlns:m="#MailingListExtensions"
	exclude-result-prefixes="xsl in lang f m">
	<xsl:param name="pageId" select="/in:inputs/in:result[@name='GetPageId']" />
	<xsl:param name="mailingLists" select="/in:inputs/in:result[@name='MailingLists']" />
	<xsl:param name="subscribeEmail" select="/in:inputs/in:result[@name='SubscribeEmail']" />
	<xsl:param name="subscribeName" select="/in:inputs/in:result[@name='SubscribeName']" />
	<xsl:param name="label" select="/in:inputs/in:param[@name='Label']" />
	<xsl:template match="/">
		<html>
			<head>
			</head>
			<body>
				<xsl:if test="$label != ''">
					<span><xsl:value-of select="$label" /> </span>
				</xsl:if>
				<f:function xmlns:f="http://www.composite.net/ns/function/1.0" name="Composite.Community.Newsletter.SubjectBased.ShortLink">
  					<f:param name="href" value="~/page({$pageId})?SubscribeEmail={m:UrlEncode($subscribeEmail)}&amp;MailingLists[]={$mailingLists}&amp;SubscribeName={m:UrlEncode($subscribeName)}&amp;ConfirmEmail={m:UrlEncode(m:Encrypt($subscribeEmail))}" />
				</f:function>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
