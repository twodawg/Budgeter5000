using Budget5000.Service;
using Budget5000.TransactionForm;
using Budget5000.TransactionForm.Views;
using Budget5000.TransactionForm.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Budget5000.Graph;
using Budget5000.Report;
using Budget5000.Graph.Views;
using Budget5000.Graph.ViewModels;

namespace Budget5000
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
        
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;

            // Add all of the modules here
            moduleCatalog.AddModule(typeof(ServiceModule));
            moduleCatalog.AddModule(typeof(TransactionFormModule));
            moduleCatalog.AddModule(typeof(GraphModule));
            moduleCatalog.AddModule(typeof(ReportModule));
        }
    }
}
