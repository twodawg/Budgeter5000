<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:fo="http://www.w3.org/1999/XSL/Format"
                xmlns:ms="urn:schemas-microsoft-com:xslt">
  <xsl:template name="Transaction">
    <fo:block>
      <fo:table table-layout="fixed">
        <fo:table-column column-width="2cm"/>
        <fo:table-column column-width="2cm"/>
        <fo:table-column column-width="2cm"/>
        <fo:table-column column-width="2cm"/>
        <fo:table-column column-width="2cm"/>
        <fo:table-header>
          <fo:table-row background-color="#A3A6BE">
            <fo:table-cell>
              <fo:block>
                Time stamp
              </fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block>
                Account #
              </fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block>
                Description
              </fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block>
                Amount
              </fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block>
                Type
              </fo:block>
            </fo:table-cell>
          </fo:table-row>
        </fo:table-header>
        <fo:table-body>
          <xsl:for-each select="//Transactions/Transaction">
            <fo:table-row>
              <fo:table-cell>
                <fo:block>
                  <xsl:value-of select="ms:format-date(TimeStamp,'MMM dd, yyyy')"/>
                </fo:block>
              </fo:table-cell>
              <fo:table-cell>
                <fo:block>
                  <xsl:value-of select="AccountID"/>
                </fo:block>
              </fo:table-cell>
              <fo:table-cell>
                <fo:block>
                  <xsl:value-of select="Description"/>
                </fo:block>
              </fo:table-cell>
              <fo:table-cell>
                <fo:block>
                  <xsl:value-of select="Amount"/>
                </fo:block>
              </fo:table-cell>
              <fo:table-cell>
                <fo:block>
                  <xsl:value-of select="Type"/>
                </fo:block>
              </fo:table-cell>
            </fo:table-row>
          </xsl:for-each>
        </fo:table-body>
      </fo:table>
    </fo:block>
  </xsl:template>
</xsl:stylesheet>
