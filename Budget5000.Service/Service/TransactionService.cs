using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Budget5000.Service.Service
{
    public class TransactionService : ITransactionService
    {
        public ObservableCollection<Transaction> WorkingTransactions { get; set; }

        public TransactionService()
        {
            WorkingTransactions = LoadRecords();
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            return WorkingTransactions;
        }

        public void SaveTransactions()
        {
            SaveRecords(WorkingTransactions);
        }

        private void SaveRecords(ObservableCollection<Transaction> Records)
        {
            var folder = "\\Budget 5000";
            var file = "\\Transations.xml";
            var homedirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal) + folder;

            using (var filestream = File.OpenWrite(homedirectory + file))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Transaction>));
                
                serializer.Serialize(filestream, Records);
            }
        }

        ObservableCollection<Transaction> LoadRecords()
        {
            var records = new ObservableCollection<Transaction>();

            var folder = "\\Budget 5000";
            var file = "\\Transations.xml";
            var homedirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal) + folder;

            if ( !Directory.Exists( homedirectory ) )
            {
                Directory.CreateDirectory(homedirectory);
                File.Create(homedirectory + file);
            }
            else
            {
                using (var filestream = File.OpenRead(homedirectory + file))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Transaction>));

                    if (filestream.Length > 0)
                    {
                        records = serializer.Deserialize(filestream) as ObservableCollection<Transaction>;
                    }
                }
            }

            return records;
        }
    }
}
