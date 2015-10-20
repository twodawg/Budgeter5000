using Budget5000.Service;
using Budget5000.TransactionForm;
using Microsoft.Practices.ServiceLocation;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Windows;

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

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new AggregateModuleCatalog();
        }

        protected override void ConfigureModuleCatalog()
        {
            Type TransactionFormType = typeof(TransactionFormModule);
            ModuleCatalog.AddModule(new ModuleInfo(TransactionFormType.Name, 
                TransactionFormType.AssemblyQualifiedName));

            Type ServiceType = typeof(ServiceModule);
            ModuleCatalog.AddModule(new ModuleInfo(ServiceType.Name,
                ServiceType.AssemblyQualifiedName));
        }
    }
}
