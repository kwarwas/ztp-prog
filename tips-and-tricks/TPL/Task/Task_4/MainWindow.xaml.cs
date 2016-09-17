using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Task_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                Title = DateTime.Now.ToString();
            });
        }

        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            await Task.Factory.StartNew(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                Title = DateTime.Now.ToString();
            }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void Button3_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                return DateTime.Now;
            })
            .ContinueWith((data) => Title = data.Result.ToString(), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
