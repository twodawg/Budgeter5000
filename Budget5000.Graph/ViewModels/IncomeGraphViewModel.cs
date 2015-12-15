using Budget5000.Infrastructure.Interface;
using Budget5000.Service.Service;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Budget5000.Infrastructure.Model;
using System;

namespace Budget5000.Graph.ViewModels
{
    public class IncomeGraphViewModel : BindableBase
    {
        public IncomeGraphViewModel(IGraphService graphService, ITransactionService transactionService)
        {
            _GraphService = graphService;
            _TransactionService = transactionService;

            IncomePlot = _GraphService.WorkingPlotModel;
            _TransactionService.Updated += _TransactionService_Updated;

            DrawGraph(_TransactionService.WorkingTransactions);
        }

        private void _TransactionService_Updated(object sender, ObservableCollection<Transaction> e)
        {
            DrawGraph(e);
        }

        private void DrawGraph(ObservableCollection<Transaction> transactions)
        {
            ClearGraph();

            AddAxis(transactions);

            AddSeries(transactions);
        }

        private void AddSeries(ObservableCollection<Transaction> transactions)
        {
            // Income
            foreach (var data in transactions.Where(q => q.AccountID >= 400 && q.AccountID < 500))
            {
                var lineSeries = new LineSeries
                {
                    StrokeThickness = 2,
                    MarkerSize = 3,
                    MarkerStroke = colors[0],
                    MarkerType = markerTypes[0],
                    Title = data.Description,
                    Smooth = false,
                };
                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.TimeStamp), 
                    double.Parse(data.Amount.ToString())));
                IncomePlot.Series.Add(lineSeries);
            }
            // Expense
            //foreach (var data in transactions.Where(q => q.AccountID >= 500))
            //{
            //    var barSeries = new BarSeries
            //    {
            //        StrokeThickness = 2,
            //        FillColor = colors[0],
            //        Title = data.Description,
            //    };

            //    barSeries.Items.Add(new BarItem(double.Parse((-data.Amount).ToString())));
            //    IncomePlot.Series.Add(barSeries);
            //}
        }

        private void AddAxis(ObservableCollection<Transaction> transactions)
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
                Title = "Amount"
            };
            IncomePlot.Axes.Add(valueAxis);
            var categoryAxis = new CategoryAxis()
            {
                Position = AxisPosition.Bottom,
            };
            IncomePlot.Axes.Add(categoryAxis);
        }

        private void ClearGraph()
        {
            IncomePlot.Axes.Clear();
            IncomePlot.Series.Clear();
            IncomePlot.Annotations.Clear();
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
        private IGraphService _GraphService;
        private ITransactionService _TransactionService;
    }
}
