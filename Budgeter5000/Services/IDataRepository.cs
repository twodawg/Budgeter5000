using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgeter5000.Services
{
    public interface IDataRepository
    {
        List<string> GetFeatures();
        string GetUserEnteredData();
        void SetUserEnteredData(string data);
    }
}
