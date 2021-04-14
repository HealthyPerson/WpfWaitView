using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace HealthyPerson.WpfWaitView.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar_Style1 : UserControl, INotifyPropertyChanged
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



        static CircularProgressBar_Style1()
        {
            try
            {
                Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 300 });
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("1\n" + ex.Message);
            }

            //CircleColorProperty = DependencyProperty.Register("CircleColor", typeof(string),
            //    typeof(CircularProgressBar),
            //    new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnCircleColorChanged)));
        }

        public CircularProgressBar_Style1()
        {
            InitializeComponent();
        }




        //private string previousCircleColor;

        //public static DependencyProperty CircleColorProperty;
        //public string CircleColor
        //{
        //    get => (string)GetValue(CircleColorProperty);
        //    set { SetValue(CircleColorProperty, value); OnPropertyChanged("CircleColor"); }
        //}



        //#region CircleColor

        //private static void OnCircleColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    CircularProgressBar circularProgressBar = (CircularProgressBar)sender;

        //    string oldCircleColor = (string)e.OldValue;
        //    string newCircleColor = (string)e.NewValue;
        //    circularProgressBar.CircleColor = newCircleColor;

        //    circularProgressBar.previousCircleColor = oldCircleColor;
        //    circularProgressBar.OnCircleColorChanged(oldCircleColor, newCircleColor);
        //}

        //private void OnCircleColorChanged(string oldValue, string newValue)
        //{
        //    RoutedPropertyChangedEventArgs<string> args = new RoutedPropertyChangedEventArgs<string>(oldValue, newValue);
        //    args.RoutedEvent = CircularProgressBar.CircleColorChangedEvent;
        //    RaiseEvent(args);
        //}


        //public static readonly RoutedEvent CircleColorChangedEvent = EventManager.RegisterRoutedEvent("CircleColorChanged", RoutingStrategy.Bubble,
        //    typeof(RoutedPropertyChangedEventHandler<string>), typeof(CircularProgressBar));


        //public event RoutedPropertyChangedEventHandler<string> CircleColorChanged
        //{
        //    add { AddHandler(CircleColorChangedEvent, value); }
        //    remove { RemoveHandler(CircleColorChangedEvent, value); }
        //}

        //#endregion CircleColor
    }
}
