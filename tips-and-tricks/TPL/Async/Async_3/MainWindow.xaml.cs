using System;
using System.Threading.Tasks;
using System.Windows;

namespace Async_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Button1_Click(object sender, RoutedEventArgs e)
        {
            Task.Delay(TimeSpan.FromSeconds(10)).Wait();
            Title = DateTime.Now.ToString();
        }

        async void Button2_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            Title = DateTime.Now.ToString();
        }
    }
}
