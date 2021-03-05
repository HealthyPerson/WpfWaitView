using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfWaitView.ViewModels;

namespace WpfWaitView.Views
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
