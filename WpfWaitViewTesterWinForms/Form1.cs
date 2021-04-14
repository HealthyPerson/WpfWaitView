using HealthyPerson.WpfWaitView;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WpfWaitViewTesterWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ShowWaitViews();
        }


        private void ShowWaitViews()
        {
            WaitViewInstance.Instance.ShowAsync("Простой заголовок, показывающий прогресс выполнения задачи.", this, HealthyPerson.WpfWaitView.Models.Enums.WaitStyle.Style_1, Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.CloseAsync();

            WaitViewInstance.Instance.ShowAsync("xyz", HealthyPerson.WpfWaitView.Models.Enums.WaitStyle.Style_2);
            WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.SetTitle("xyz ...");
            WaitViewInstance.Instance.SetColors(Color.Blue, Color.Aquamarine);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.CloseAsync();

            WaitViewInstance.Instance.ShowAsync(null, this, HealthyPerson.WpfWaitView.Models.Enums.WaitStyle.Style_3);
            WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
            Thread.Sleep(5000);
            WaitViewInstance.Instance.CloseAsync();
        }
    }
}
