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

            IncomePlot.InvalidatePlot(true);
        }

        private void AddSeries(ObservableCollection<Transaction> transactions)
        {
            // Income
            foreach (var data in transactions.Where(q => q.AccountID >= 400 && q.AccountID < 500))
            {
                var barSeries = new LinearBarSeries
                {
                    StrokeThickness = 1,
                    FillColor = OxyColors.Green,
                    Title = data.Description,
                };
                barSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.TimeStamp),
                    double.Parse(data.Amount.ToString())));
                IncomePlot.Series.Add(barSeries);
            }
            // Expense
            foreach (var data in transactions.Where(q => q.AccountID >= 500))
            {
                var barSeries = new LinearBarSeries
                {
                    StrokeThickness = 1,
                    FillColor = OxyColors.IndianRed,
                    Title = data.Description,
                };

                barSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.TimeStamp), 
                    double.Parse((-data.Amount).ToString())));
                IncomePlot.Series.Add(barSeries);
            }
        }

        private void AddAxis(ObservableCollection<Transaction> transactions)
        {
            var dateAxis = new DateTimeAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Angle = -45,
            };
            IncomePlot.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Amount"
            };
            IncomePlot.Axes.Add(valueAxis);
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

        private IGraphService _GraphService;
        private ITransactionService _TransactionService;
    }
}
