using System;
using Prism.Commands;
using Prism.Mvvm;
using System.Xml.Xsl;
using Fonet;
using System.Diagnostics;
using Fonet.Render.Pdf;

namespace Budget5000.Report.ViewModels
{
    public class IncomeStatementViewModel : BindableBase
    {
        public IncomeStatementViewModel()
        {
            PrintIncomeReport = new DelegateCommand(OnPrintIncomeReport);
        }

        private void OnPrintIncomeReport()
        {
            var options = new PdfRendererOptions();
            options.Author = "Michael Twohey";
            options.Title = "Income Statement";
            options.Subject = "Bugeter 5000";
            //options.EnableModify = false;
            //options.EnableAdd = false;
            //options.EnableCopy = false;
            //options.EnablePrinting = true;
            //options.OwnerPassword = "slough";

            string foxslPath = @"Templates\hello.fo";
            //string foxslPath = @"Templates\IncomeReport.xsl";
            string outputPath = "Report.pdf";

            var driver = FonetDriver.Make();
            driver.OnError += new FonetDriver.FonetEventHandler(FonetError);
            driver.Options = options;
            driver.Render(foxslPath, outputPath);

            Process.Start(outputPath);
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
    }
}
