<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:output method="html"/>
	<xsl:template match="/invoice">
		<html>
			<head>
				<title>Invoice Information</title>
				<link href="invoice.css" rel="stylesheet" type="text/css" />			
				<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous"/>		
				
			</head>
			<body>
				<h1>Acme Web Programmers Inc</h1>
				<hr/>
				<div class="container-fluid row" id="content">
				<xsl:apply-templates select="info"/>
				<xsl:apply-templates select="client"/>
				</div>				
				<div class="table-responsive">
					<table class="table table-striped">
						<thead class="thead-inverse">
							<tr>
								<th>Date</th>
								<th>Work Performed</th>
								<th>Hours</th>
							</tr>
						</thead>	
					<xsl:apply-templates select="work_record">
						<xsl:sort order="ascending" select="work_date" data-type="text"/>
					</xsl:apply-templates>
					</table>
				
				</div>
				
			</body>
		</html>

	</xsl:template>
	
	<xsl:template name="billInfo" match="info">
		<div class="col">
			<p>Transactions for Invoice Number: <xsl:value-of select="@invoice_number"></xsl:value-of></p>
			<p>Date: <xsl:value-of select="invoice_date"/></p>
		</div>
	</xsl:template>
	
	<xsl:template name="clientInfo" match="client">
		<div class="col">
			<p>Client: <xsl:value-of select="Client_Name"/></p>
			<p>Contact: <xsl:value-of select="Contact_Firstname"/> <xsl:value-of select="Contact_Lastname"/></p>
			<p>Address: <xsl:value-of select="Client_Street"/> - <xsl:value-of select="Client_City"/>, <xsl:value-of select="Client_Province"/> - <xsl:value-of select="Client_Postalcode"/></p>

		</div>
	
	</xsl:template>
	
	<xsl:template name="records" match="work_record">
		<xsl:for-each select=".">
			<tr>
				<td><xsl:value-of select="work_date"/></td>
				<td><xsl:value-of select="work_description"/></td>
				<td><xsl:value-of select="billed_hours"/></td>
			</tr>
		</xsl:for-each>
	</xsl:template>
	


</xsl:stylesheet>
