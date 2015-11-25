<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:fo="http://www.w3.org/1999/XSL/Format"
                xmlns:xalan="http://xml.apache.org/xalan"
                xmlns:tns="tns:tns"
                xmlns:ms="urn:schemas-microsoft-com:xslt">
  <xsl:import href="Transaction.xsl"/>
  <xsl:template match="IncomeStatement">
    <fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format" font-family="Arial" font-size="8pt" line-height="1.2">
      <fo:layout-master-set>
        <fo:simple-page-master master-name="first"
        page-height="29.7cm"
        page-width="21cm"
        margin-top="0.1in" margin-bottom="0in" margin-left="0.62in" margin-right="0.5in">
          <fo:region-body region-name="xsl-region-body" margin-top="0.6in" margin-bottom="0.5in"/>
          <fo:region-before region-name="xsl-region-before" extent="1.0in"/>
          <fo:region-after region-name="xsl-region-after" extent=".5in"/>
        </fo:simple-page-master>
        <fo:simple-page-master master-name="landscape"
          page-width="29.7cm"
          page-height="21cm"
          margin-top="0.1in" margin-bottom="0in" margin-left="0.62in" margin-right="0.5in">
          <fo:region-body margin-top="0.5in" margin-bottom="0.5in"/>
          <fo:region-before extent="1.0in"/>
          <fo:region-after extent=".5in"/>
        </fo:simple-page-master>
      </fo:layout-master-set>
      <fo:page-sequence master-reference="first">
        <!-- HEADER -->
        <fo:static-content flow-name="xsl-region-before">
          <fo:block font-weight="normal" text-align="right">
            <fo:external-graphic src="url(Assets/logo.png)" height="8mm"/>            
          </fo:block>          
        </fo:static-content>
        <!--FOOTER-->
        <fo:static-content flow-name="xsl-region-after">
          <fo:block font-weight="normal" text-align="right">
            Income Report
          </fo:block>
        </fo:static-content>
        <!--BODY-->
        <fo:flow flow-name="xsl-region-body">
          <fo:block>
            All Income and Expense Transactions
          </fo:block>
          <xsl:call-template name="Transaction"/>          
        </fo:flow>
      </fo:page-sequence>
    </fo:root>
  </xsl:template>
</xsl:stylesheet>
