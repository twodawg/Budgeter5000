using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using Budget5000.Service.Service;
using OxyPlot;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Budget5000.Graph.ViewModels
{
    public class IncomeGraphViewModel : BindableBase
    {
        public IncomeGraphViewModel(IGraphService graphService,
            ITransactionService transactionService)
        {
            _GraphService = graphService;
            _TransactionService = transactionService;
            Initialize();
        }
        // Public Methods

        // Private Methods
        void Initialize()
        {
            IncomePlot = _GraphService.WorkingPlotModel;
            _TransactionService.Updated += _TransactionService_Updated;

            DrawGraph.Draw(IncomePlot, _TransactionService.WorkingTransactions);
        }
        void _TransactionService_Updated(object sender, ObservableCollection<Transaction> e)
        {
            DrawGraph.Draw(IncomePlot, e);
        }

        // Properties
        PlotModel _IncomePlot;
        public PlotModel IncomePlot
        {
            get { return _IncomePlot; }
            set
            {
                SetProperty(ref _IncomePlot, value);
            }
        }

        // Private fields
        IGraphService _GraphService;
        ITransactionService _TransactionService;
    }
}
