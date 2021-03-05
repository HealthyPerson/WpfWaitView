using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WpfWaitView.Models;

namespace WpfWaitView.ViewModels
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


    }
}
