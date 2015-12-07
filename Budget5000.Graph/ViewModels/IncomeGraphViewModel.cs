using Budget5000.Service.Service;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace Budget5000.Graph.ViewModels
{
    public class IncomeGraphViewModel : BindableBase
    {
        public IncomeGraphViewModel(IGraphService graphService)
        {
            _graphService = graphService;
            IncomePlot = _graphService.WorkingPlotModel;

            SetUpModel();

            LoadData();
        }

        private PlotModel _IncomePlot;
        public PlotModel IncomePlot
        {
            get { return _IncomePlot; }
            set
            {
                SetProperty(ref _IncomePlot, value);
            }
        }

        private void SetUpModel()
        {            
            var dateAxis = new DateTimeAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
            };
            IncomePlot.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Value"
            };
            IncomePlot.Axes.Add(valueAxis);
        }
        private void LoadData()
        {
            List<Measurement> measurements = Data.GetData();


            var dataPerDetector = measurements.GroupBy(m => m.DetectorId).ToList();


            foreach (var data in dataPerDetector)
            {
                var lineSerie = new LineSeries
                {
                    StrokeThickness = 2,
                    MarkerSize = 3,
                    MarkerStroke = colors[data.Key],
                    MarkerType = markerTypes[data.Key],
                    Title = string.Format("Detector {0}", data.Key),
                    Smooth = false,
                };


                data.ToList().ForEach(d => lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(d.DateTime), d.Value)));
                IncomePlot.Series.Add(lineSerie);
            }

        }
        private readonly List<OxyColor> colors = new List<OxyColor>
                                             {
                                                 OxyColors.Green,
                                                 OxyColors.IndianRed,
                                                 OxyColors.Coral,
                                                 OxyColors.Chartreuse,
                                                 OxyColors.Azure
                                             };


        private readonly List<MarkerType> markerTypes = new List<MarkerType>
                                                    {
                                                        MarkerType.Plus,
                                                        MarkerType.Star,
                                                        MarkerType.Diamond,
                                                        MarkerType.Triangle,
                                                        MarkerType.Cross
                                                    };
        private IGraphService _graphService;
    }
}
