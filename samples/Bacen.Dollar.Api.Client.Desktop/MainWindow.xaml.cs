using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bacen.Dollar.Api.Client.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBacenDollarClient _client;

        public MainWindow(IBacenDollarClient client)
        {
            _client = client;
            InitializeComponent();
            Task.Run(() => GetDollarQuotation());
        }

        private async void GetDollarQuotation()
        {
            var dollarQuotes = await _client
                .PeriodicDollarQuotationAsync(
                    new DateTime(2023, 3, 20),
                    DateTime.Today.Date)
                .ConfigureAwait(true);

            this.Dispatcher.Invoke(() =>
            {
                DolarQuotationDG.ItemsSource = dollarQuotes;
            });
        }
    }
}
