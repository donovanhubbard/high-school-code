<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
   <xsl:template match="/">
      <html>
         <head>
            <title>WarCraft 3 Units</title>
         </head>
         <body bgcolor = "black" text = "white">
            
	<font color = "red" size = "64">
	<p align = "center"><i>Donovan is so cool I cant stand it sometimes</i></p>
	<p><p><p align = "center">
	Isnt that cool?
	</p></p></p>
	
	<hr/>
	</font>
	<xsl:apply-templates />
       
         </body>
      </html>
   </xsl:template>

   <xsl:template match="unit">
     <p align = "center"> <xsl:value-of select= "@name" /> </p> 
     <p align="right"><xsl:value-of select="name"/></p>
	<p align="center"><img src="{image}" /></p>
      <p align="left"> Race: <xsl:value-of select="race"/></p>
	<p align="left">HP: <xsl:value-of select="hp"/></p>
	<p align="left">Damage: <xsl:value-of select="damage"/></p>
	<font size="48" color = "red"><u><i>Donovan is Hot</i></u></font>
      <hr />
   </xsl:template>
</xsl:stylesheet>