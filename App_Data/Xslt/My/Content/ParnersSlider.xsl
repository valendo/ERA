<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:in="http://www.composite.net/ns/transformation/input/1.0"
	xmlns:lang="http://www.composite.net/ns/localization/1.0"
	xmlns:f="http://www.composite.net/ns/function/1.0"
	xmlns="http://www.w3.org/1999/xhtml"
	exclude-result-prefixes="xsl in lang f">
	
	<xsl:variable name="partners" select="/in:inputs/in:result[@name='GetPartnerXml']/Partner" />

	<xsl:template match="/">
		<html>
			<head>
				<!-- markup placed here will be shown in the head section of the rendered page -->
			</head>

			<body>
				<br/>
				<marquee behavior="scroll" scrollamount="10" direction="left" width="100%" onmouseover="this.setAttribute('scrollamount', 0, 0);" onmouseout="this.setAttribute('scrollamount', 6, 0);">
				<xsl:for-each select="$partners">
					<a style="display:inline;" href="{@Url}" target="_blank"><img height="40px" src="~/media({@Logo})" /></a>
					<span>&#160;&#160;</span>
				</xsl:for-each>
					
				</marquee>
			</body>
		</html>
	</xsl:template>

</xsl:stylesheet>
