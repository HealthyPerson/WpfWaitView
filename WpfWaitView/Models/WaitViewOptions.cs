using HealthyPerson.WpfWaitView.Models.Enums;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;

namespace HealthyPerson.WpfWaitView.Models
{
    public class WaitViewOptions : INotifyPropertyChanged
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


        private string _stTitle = "Ожидайте ...";
        public string stTitle
        {
            get { return _stTitle; }
            set { if (!string.IsNullOrEmpty(value)) _stTitle = value; else _stTitle = "Ожидайте ..."; OnPropertyChanged("stTitle"); }
        }


        private WaitStyle _WaitStyle = WaitStyle.Style_1;
        public WaitStyle WaitStyle
        {
            get { return _WaitStyle; }
            set { _WaitStyle = value; OnPropertyChanged("WaitStyle"); }
        }

         

        private string _CircleColor = "Aquamarine";
        public string CircleColor
        {
            get => _CircleColor;
            set { _CircleColor = value; OnPropertyChanged("CircleColor"); }
        }


        private string _HeaderCircleColor = "Blue";
        public string HeaderCircleColor
        {
            get => _HeaderCircleColor;
            set { _HeaderCircleColor = value; OnPropertyChanged("HeaderCircleColor"); }
        }


        private Window _Owner;
        public Window Owner
        {
            get { return _Owner; }
            set { if (value != _Owner) _Owner = value; if (_Owner != null) OwnerForm = null; }
        }


        private Form _OwnerForm;
        public Form OwnerForm
        {
            get { return _OwnerForm; }
            set { if (value != _OwnerForm) _OwnerForm = value; if (_OwnerForm != null) Owner = null; }
        }


        private IntPtr _OwnerHandler;
        public IntPtr OwnerHandler
        {
            get { return _OwnerHandler; }
            set { _OwnerHandler = value; }
        }


        private double _OwnerLeft;
        public double OwnerLeft
        {
            get { return _OwnerLeft; }
            set { _OwnerLeft = value; }
        }


        private double _OwnerTop;
        public double OwnerTop
        {
            get { return _OwnerTop; }
            set { _OwnerTop = value; }
        }


        private double _OwnerWidht;
        public double OwnerWidht
        {
            get { return _OwnerWidht; }
            set { _OwnerWidht = value; }
        }


        private double _OwnerHeight;
        public double OwnerHeight
        {
            get { return _OwnerHeight; }
            set { _OwnerHeight = value; }
        }
       

    }
}
