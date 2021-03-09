﻿using HealthyManSoftware.WpfWaitView;
using System.Drawing;
using System.Threading;
using System.Windows;

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
            WaitViewInstance.Instance.ShowAsync("Простой заголовок, показывающий прогресс выполнения задачи.", this, HealthyManSoftware.WpfWaitView.Models.Enums.WaitStyle.Style_1, Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.CloseAsync();

            WaitViewInstance.Instance.ShowAsync("xyz", HealthyManSoftware.WpfWaitView.Models.Enums.WaitStyle.Style_2);
            WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.SetTitle("xyz ...");
            WaitViewInstance.Instance.SetColors(Color.Blue, Color.Aquamarine);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.CloseAsync();

            WaitViewInstance.Instance.ShowAsync(null, this, HealthyManSoftware.WpfWaitView.Models.Enums.WaitStyle.Style_3);
            WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.CloseAsync();
        }
    }
}
