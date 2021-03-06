﻿using Budget5000.Infrastructure.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace Budget5000.Graph.ViewModels
{
    public static class DrawGraph
    {
        public static void Draw(PlotModel IncomePlot,
            ObservableCollection<Transaction> transactions)
        {
            ClearGraph(IncomePlot);

            AddAxis(IncomePlot, transactions);

            AddSeries(IncomePlot, transactions);

            IncomePlot.InvalidatePlot(true);
        }
        static void ClearGraph(PlotModel IncomePlot)
        {
            IncomePlot.Axes.Clear();
            IncomePlot.Series.Clear();
        }
        static void AddAxis(PlotModel IncomePlot,
            ObservableCollection<Transaction> transactions)
        {
            var dateAxis = new DateTimeAxis
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Angle = -45
            };
            IncomePlot.Axes.Add(dateAxis);
            var valueAxis = new LinearAxis
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Amount"
            };
            IncomePlot.Axes.Add(valueAxis);
        }
        static void AddSeries(PlotModel IncomePlot,
            ObservableCollection<Transaction> transactions)
        {
            // Income
            foreach (var data in transactions.Where(q => q.AccountID >= 400 &&
            q.AccountID < 500))
            {
                SetPlotData(IncomePlot, data, OxyColors.Green, 1);
            }
            // Expense
            foreach (var data in transactions.Where(q => q.AccountID >= 500))
            {
                SetPlotData(IncomePlot, data, OxyColors.IndianRed, -1);
            }
        }
        

        private static void SetPlotData(PlotModel IncomePlot, 
            Transaction data, OxyColor barColor, int number)
        {
            var barSeries = new LinearBarSeries
            {
                StrokeThickness = 1,
                FillColor = barColor,
                Title = data.Description
            };
            barSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.TimeStamp),
                double.Parse((number * data.Amount).ToString())));
            IncomePlot.Series.Add(barSeries);
        }
    }
}
