using HealthyManSoftware.WpfWaitView.ViewModels;
using System.Windows;

namespace HealthyManSoftware.WpfWaitView.Views
{


    /// <summary>
    /// Логика взаимодействия для WaitView.xaml
    /// </summary>
    public partial class WaitView : Window
    {
        WaitViewModel vmWait;

        public WaitView(WaitViewModel _vmWait)
        {
            vmWait = _vmWait;
            
            InitializeComponent();

            DataContext = vmWait;
        }

    }
}
