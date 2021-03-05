using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWaitViewTester
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowWaitViews();
        }


        private void ShowWaitViews()
        {
            WpfWaitView.WaitViewInstance.Instance.ShowAsync("Простой заголовок, показывающий прогресс выполнения задачи.", this, Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WpfWaitView.WaitViewInstance.Instance.CloseAsync();

            WpfWaitView.WaitViewInstance.Instance.ShowAsync("xyz");
            WpfWaitView.WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WpfWaitView.WaitViewInstance.Instance.SetTitle("xyz ...");
            WpfWaitView.WaitViewInstance.Instance.SetColors(Color.Blue, Color.Aquamarine);
            Thread.Sleep(5000);
            WpfWaitView.WaitViewInstance.Instance.CloseAsync();


            WpfWaitView.WaitViewInstance.Instance.ShowAsync(null, this);
            WpfWaitView.WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WpfWaitView.WaitViewInstance.Instance.CloseAsync();
        }
    }
}
