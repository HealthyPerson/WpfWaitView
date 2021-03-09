using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace HealthyManSoftware.WpfWaitView.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CircularProgressBar_Style2.xaml
    /// </summary>
    public partial class CircularProgressBar_Style2 : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(/*[CallerMemberName]*/ string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        static CircularProgressBar_Style2()
        {
            try
            {
                Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 300 });
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("2\n" + ex.Message);
            }
        }


        public CircularProgressBar_Style2()
        {
            InitializeComponent();
        }
    }
}
