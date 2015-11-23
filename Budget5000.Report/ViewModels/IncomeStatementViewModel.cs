using System;
using Prism.Commands;
using Prism.Mvvm;
using System.Xml.Xsl;
using Fonet;
using System.Diagnostics;
using Fonet.Render.Pdf;
using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Budget5000.Report.ViewModels
{
    public class IncomeStatementViewModel : BindableBase
    {
        private ITransactionService _TransactionService;

        public IncomeStatementViewModel(ITransactionService transactionService)
        {
            _TransactionService = transactionService;
            PrintIncomeReport = new DelegateCommand(OnPrintIncomeReport);
        }

        private void OnPrintIncomeReport()
        {
            var incomeStatement = BuildIncomeStatement();

            var reportLocation = CreateReport(incomeStatement);

            Process.Start(reportLocation);
        }

        private string CreateReport(IncomeStatement incomeStatement)
        {
            string reportLocation = BuildFilePath("IncomeStatement.pdf");
            var incomeStatementXml = new XmlSerializer(typeof(IncomeStatement));

            // https://social.msdn.microsoft.com/Forums/en-US/85dc00be-9784-4c00-b7d9-8bb509c195b0/creating-xmlreader-from-a-memorystream-c?forum=xmlandnetfx
            XmlReader reportDataXmlReader;

            using (var reportDataMemoryStream = new MemoryStream())
            {
                incomeStatementXml.Serialize(reportDataMemoryStream, incomeStatement);
#if DEBUG
                SaveToFile(reportDataMemoryStream);
#endif
                // reset to 0
                reportDataMemoryStream.Position = 0;
                reportDataXmlReader = XmlReader.Create(reportDataMemoryStream);

                string foxslPath = @"Templates\IncomeReport.xsl";
                //string foxslPath = @"Templates\hello.fo";
                var xslt = new XslCompiledTransform();
                xslt.Load(foxslPath);

                using (var foReportMemoryStream = new MemoryStream())
                {
                    // Ready for the FO engine to generate PDF from
                    xslt.Transform(reportDataXmlReader, null, foReportMemoryStream);
                    var options = new PdfRendererOptions();
                    options.Author = "Michael Twohey";
                    options.Title = "Income Statement";
                    options.Subject = "Bugeter 5000";
                    //options.EnableModify = false;
                    //options.EnableAdd = false;
                    //options.EnableCopy = false;
                    //options.EnablePrinting = true;
                    //options.OwnerPassword = "slough";
                    // https://fonet.codeplex.com
                    FonetDriver driver = FonetDriver.Make();
                    driver.OnError += new FonetDriver.FonetEventHandler(FonetError);
                    driver.Options = options;
                    try
                    {
                        using (var fileStream = new FileStream(reportLocation, FileMode.Create))
                        {
                            foReportMemoryStream.Position = 0;
                            driver.Render(foReportMemoryStream, fileStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + ex.InnerException);
                    }
                }
            }
            return reportLocation;
        }

        private void SaveToFile(MemoryStream reportDataMemoryStream)
        {
            reportDataMemoryStream.Position = 0;
            string xml = new StreamReader(reportDataMemoryStream).ReadToEnd();
            XmlDocument oXML = new XmlDocument();
            oXML.LoadXml(xml);
            oXML.Save(BuildFilePath("IncomeStatementReport.xml"));
        }

        private IncomeStatement BuildIncomeStatement()
        {
            var incomeStatement = new IncomeStatement();
            incomeStatement.Transactions = _TransactionService.WorkingTransactions;
            return incomeStatement;
        }

        public DelegateCommand PrintIncomeReport { get; set; }

        public void FonetError(object Driver, FonetEventArgs e)
        {
            const string LogName = "Application";
            // Insert into Event Log
            EventLog Log = new EventLog();
            Log.Source = LogName;
            Log.WriteEntry(e.GetMessage(), EventLogEntryType.Error);
        }
        private static string BuildFilePath(string filename)
        {
            string folders = String.Format("{0}\\Budget 5000",
                            Environment.GetFolderPath(Environment.SpecialFolder.Personal));

            if (!Directory.Exists(folders))
            {
                Directory.CreateDirectory(folders);
            }

            return String.Format("{0}\\{1}", folders, filename);
        }
    }
}
