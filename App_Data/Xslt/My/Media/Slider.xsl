<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:in="http://www.composite.net/ns/transformation/input/1.0"
	xmlns:lang="http://www.composite.net/ns/localization/1.0"
	xmlns:f="http://www.composite.net/ns/function/1.0"
	xmlns="http://www.w3.org/1999/xhtml"
	exclude-result-prefixes="xsl in lang f">
	
	<xsl:variable name="slider" select="/in:inputs/in:result[@name='GetSliderXml']/Slider" />
	
	<xsl:template match="/">
		<html>
			<head>
				<!-- markup placed here will be shown in the head section of the rendered page -->
			</head>
			<body>
				<div class="wrapper">
					<div class="slider">
						<ul class="items">
							<xsl:for-each select="$slider">
								<li><a href="#"><img src="~/media({@Image})" /></a></li>
							</xsl:for-each>
						</ul>
					</div>
				</div>
			</body>
		</html>
	</xsl:template>

</xsl:stylesheet>
