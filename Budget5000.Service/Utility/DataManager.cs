using Budget5000.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Budget5000.Service.Utility
{
    public class DataManager
    {
        string Folder;
        string File;
        string HomeDirectory;

        public DataManager()
        {
            Folder = "\\Budget 5000";
            File = "\\Transations.xml";
            HomeDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal) + Folder;
        }

        public void SaveRecords(ObservableCollection<Transaction> Records)
        {
            using (var filestream = System.IO.File.OpenWrite(HomeDirectory + File))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Transaction>));

                serializer.Serialize(filestream, Records);
            }
        }
        public ObservableCollection<Transaction> LoadRecords()
        {
            var records = new ObservableCollection<Transaction>();
            
            if (!Directory.Exists(HomeDirectory))
            {
                Directory.CreateDirectory(HomeDirectory);
                System.IO.File.Create(HomeDirectory + File);
            }
            else
            {
                using (var filestream = System.IO.File.OpenRead(HomeDirectory + File))
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
