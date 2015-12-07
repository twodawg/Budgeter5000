using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.Service.Service
{
    public class GraphService : IGraphService
    {
        public PlotModel WorkingPlotModel { get; set; }

        public GraphService()
        {
            WorkingPlotModel = new PlotModel();
        }
    }
}
