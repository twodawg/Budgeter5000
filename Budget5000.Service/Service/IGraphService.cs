using OxyPlot;

namespace Budget5000.Service.Service
{
    public interface IGraphService
    {
        PlotModel WorkingPlotModel { get; set; }
    }
}