<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:in="http://www.composite.net/ns/transformation/input/1.0" xmlns:lang="http://www.composite.net/ns/localization/1.0" xmlns:f="http://www.composite.net/ns/function/1.0" xmlns="http://www.w3.org/1999/xhtml" exclude-result-prefixes="xsl in lang f">
	<xsl:param name="height" select="/in:inputs/in:param[@name='Height']" />
	<xsl:template match="/">
		<html>
			<head>
				
			</head>
			<body>
				<div style="width:100%;height:{$height}px;">&#160;</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>