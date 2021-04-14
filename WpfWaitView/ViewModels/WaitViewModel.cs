using HealthyPerson.WpfWaitView.Models;
using HealthyPerson.WpfWaitView.Models.Enums;
using HealthyPerson.WpfWaitView.UserControls;
using System.ComponentModel;

namespace HealthyPerson.WpfWaitView.ViewModels
{
    public class WaitViewModel : INotifyPropertyChanged
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



        private WaitViewOptions waitOpts { get; }

        public WaitViewModel(WaitViewOptions _waitOpts)
        {
            waitOpts = _waitOpts;
            SetContent();
        }


        public string Title
        {
            get => waitOpts.stTitle;
            set { waitOpts.stTitle = value; OnPropertyChanged("Title"); }
        }


        public string ProgressCircleColor
        {
            get => waitOpts.CircleColor;
            set { waitOpts.CircleColor = value; OnPropertyChanged("ProgressCircleColor"); }
        }

        public string ProgressHeaderCircleColor
        {
            get => waitOpts.HeaderCircleColor;
            set { waitOpts.HeaderCircleColor = value; OnPropertyChanged("ProgressHeaderCircleColor"); }
        }

        public WaitStyle WaitStyle
        {
            get => waitOpts.WaitStyle;
            set { waitOpts.WaitStyle = value; OnPropertyChanged("WaitStyle"); SetContent(); }
        }


        private object _fwElement;
        public object fwElement
        {
            get { return _fwElement; }
            set { _fwElement = value; OnPropertyChanged("fwElement"); }
        }


        private object _fwElementSub;
        public object fwElementSub
        {
            get { return _fwElementSub; }
            set { _fwElementSub = value; OnPropertyChanged("fwElementSub"); }
        }


        private void SetContent()
        {
            if (WaitStyle == WaitStyle.Style_1)
            {
                fwElement = new WaitContentView_Style1();
                fwElementSub = new CircularProgressBar_Style1();
            }
            else if (WaitStyle == WaitStyle.Style_2)
            {
                fwElement = new WaitContentView_Style1();
                fwElementSub = new CircularProgressBar_Style2();
            }
            else if (WaitStyle == WaitStyle.Style_3)
            {
                fwElement = new WaitContentView_Style2();
                fwElementSub = new CircularProgressBar_Style1();
            }
            else if (WaitStyle == WaitStyle.Style_4)
            {
                fwElement = new WaitContentView_Style2();
                fwElementSub = new CircularProgressBar_Style2();
            }
        }

    }
}
