<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" />
	<xsl:template match="/">
		<HTML>
			<Head>
				<Body>
					<h1>
						<xsl:value-of select="//BillingTable/Heading" />
					</h1>
					<table border="1" width="100%">
						<xsl:for-each select="//data/record">
							<tr>
								<td>
									<xsl:value-of select="name" />
								</td>
								<td>
									<xsl:value-of select="hours" />
								</td>
								<td>
									<xsl:value-of select="description" />
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</Body>
			</Head>
		</HTML>
	</xsl:template>
</xsl:stylesheet>