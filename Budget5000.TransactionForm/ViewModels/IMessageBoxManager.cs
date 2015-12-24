using System.Windows;

namespace Budget5000.TransactionForm.ViewModels
{
    public interface IMessageBoxManager
    {
        MessageBoxResult ShowMessageBox(string text, string title, MessageBoxButton buttons);
    }
}
