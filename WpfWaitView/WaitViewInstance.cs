using HealthyPerson.WpfWaitView.Models;
using HealthyPerson.WpfWaitView.Models.Enums;
using HealthyPerson.WpfWaitView.ViewModels;
using HealthyPerson.WpfWaitView.Views;
using System;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace HealthyPerson.WpfWaitView
{
    public class WaitViewInstance
    {
        #region Коснтруктор

        private WaitViewInstance()
        {

        }

        #endregion Коснтруктор


        #region Синглтон
        static object _lock = new object();
        static WaitViewInstance _instance;

        /// <summary>
        /// Единственный экземпляр класса доступа к методам класса. Singleton.
        /// </summary>
        public static WaitViewInstance Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new WaitViewInstance();

                    return _instance;
                }
            }

        }
        #endregion Синглтон


        #region Поля

        object _viewLock = new object();
        Thread _thread = null;

        private WaitView _view;

        private int _counter;

        #endregion Поля


        #region Методы

        #region Служебные

        private void Show(object waitViewOptions)
        {
            try
            {
                WaitViewOptions waitOpts = null;
                if (!(waitViewOptions is WaitViewOptions))
                {
                    return;
                }
                else
                {
                    waitOpts = waitViewOptions as WaitViewOptions;
                }


                _view = new WaitView(new WaitViewModel(waitOpts));

                if ((waitOpts.Owner == null && waitOpts.OwnerForm == null) || waitOpts.OwnerHandler == IntPtr.Zero)
                {
                    _view.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    _view.ShowInTaskbar = true;
                    _view.Topmost = true;
                }
                else
                {
                    _view.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
                 
                    if (waitOpts.Owner != null && waitOpts.Owner.Dispatcher.Thread == _view.Dispatcher.Thread)
                    {
                        _view.Owner = waitOpts.Owner;
                    }
                    else
                    {
                        Services.WindowHelper.SetOwnerWindowMultithread(Services.WindowHelper.GetHandler(_view), waitOpts.OwnerHandler);
                    }

                    double Left = waitOpts.OwnerLeft + waitOpts.OwnerWidht / 2.0 - _view.Width / 2.0;
                    if (Left < 0) Left = waitOpts.OwnerLeft;

                    double Top = waitOpts.OwnerTop + waitOpts.OwnerHeight / 2.0 - _view.Height / 2.0;
                    if (Top < 0) Top = waitOpts.OwnerTop;

                    _view.Left = Left;
                    _view.Top = Top;
                }

                _view.ShowDialog();
            }
            catch (ThreadAbortException)
            { 
            }
            catch (ThreadInterruptedException)
            {
            }
        }


        internal bool IsAlive
        {
            get
            {
                return this._thread != null && this._thread.IsAlive;
            }
        }

        #endregion Служебные


        #region Перегрузки ShowAsync и CloseAsync

        /// <summary>
        /// Показывает окно ожидания из параллельного потока (асинхронно).
        /// </summary>
        /// <param name="_stTitle">Заголовок окна, отображающийся посередине.</param>
        public void ShowAsync(string _stTitle)
        {
            lock (_viewLock)
            {
                _counter++;
                if (_thread != null && _thread.IsAlive)
                    return;
                ParameterizedThreadStart ts = new ParameterizedThreadStart(Show);
                _thread = new Thread(ts);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Name = "WpfWaitView";
                _thread.IsBackground = true;
                WaitViewOptions waitOpts = new WaitViewOptions() { stTitle = _stTitle, Owner = null, OwnerForm = null, WaitStyle = WaitStyle.Style_1 };
                _thread.Start(waitOpts);
            }
        }

        /// <summary>
        /// Показывает окно ожидания из параллельного потока (асинхронно).
        /// </summary>
        /// <param name="_stTitle">Заголовок окна, отображающийся посередине.</param>
        /// <param name="_WaitStyle">Стиль окна ожидания.</param>
        public void ShowAsync(string _stTitle, WaitStyle _WaitStyle)
        {
            lock (_viewLock)
            {
                _counter++;
                if (_thread != null && _thread.IsAlive)
                    return;
                ParameterizedThreadStart ts = new ParameterizedThreadStart(Show);
                _thread = new Thread(ts);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Name = "WpfWaitView";
                _thread.IsBackground = true;
                WaitViewOptions waitOpts = new WaitViewOptions() { stTitle = _stTitle, Owner = null, OwnerForm = null, WaitStyle = _WaitStyle };
                _thread.Start(waitOpts);
            }
        }

        /// <summary>
        /// Показывает окно ожидания из параллельного потока (асинхронно).
        /// </summary>
        /// <param name="_stTitle">Заголовок окна, отображающийся посередине.</param>
        /// <param name="_Owner">Родительское окно.</param>
        /// <param name="_WaitStyle">Стиль окна ожидания.</param>
        public void ShowAsync(string _stTitle, Window _Owner, WaitStyle _WaitStyle)
        {
            lock (_viewLock)
            {
                _counter++;
                if (_thread != null && _thread.IsAlive)
                    return;

                IntPtr Handler = IntPtr.Zero;
                double Left, Top, Width, Height;
                Left = Top = Width = Height = 0;
                if (_Owner != null)
                {
                    Handler = Services.WindowHelper.GetHandler(_Owner);
                    Left = _Owner.Left;
                    Top = _Owner.Top;
                    Width = _Owner.Width;
                    Height = _Owner.Height;
                }

                ParameterizedThreadStart ts = new ParameterizedThreadStart(Show);
                _thread = new Thread(ts);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Name = "WpfWaitView";
                _thread.IsBackground = true;
                WaitViewOptions waitOpts = new WaitViewOptions()
                { 
                    stTitle = _stTitle, 
                    Owner = _Owner, 
                    OwnerHandler = Handler, 
                    OwnerLeft = Left, 
                    OwnerTop = Top, 
                    OwnerWidht = Width, 
                    OwnerHeight = Height, 
                    WaitStyle= _WaitStyle
                };
                _thread.Start(waitOpts);
            }
        }


        /// <summary>
        /// Показывает окно ожидания из параллельного потока (асинхронно).
        /// </summary>
        /// <param name="_stTitle">Заголовок окна, отображающийся посередине.</param>
        /// <param name="_Owner">Родительская форма.</param>
        /// <param name="_WaitStyle">Стиль окна ожидания.</param>
        public void ShowAsync(string _stTitle, Form _Owner, WaitStyle _WaitStyle)
        {
            lock (_viewLock)
            {
                _counter++;
                if (_thread != null && _thread.IsAlive)
                    return;

                IntPtr Handler = IntPtr.Zero;
                double Left, Top, Width, Height;
                Left = Top = Width = Height = 0;
                if (_Owner != null)
                {
                    Handler = _Owner.Handle;// Services.WindowHelper.GetHandler(_Owner);
                    Left = _Owner.Left;
                    Top = _Owner.Top;
                    Width = _Owner.Width;
                    Height = _Owner.Height;
                }

                ParameterizedThreadStart ts = new ParameterizedThreadStart(Show);
                _thread = new Thread(ts);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Name = "WpfWaitView";
                _thread.IsBackground = true;
                WaitViewOptions waitOpts = new WaitViewOptions()
                {
                    stTitle = _stTitle,
                    OwnerForm = _Owner,
                    OwnerHandler = Handler,
                    OwnerLeft = Left,
                    OwnerTop = Top,
                    OwnerWidht = Width,
                    OwnerHeight = Height,
                    WaitStyle = _WaitStyle
                };
                _thread.Start(waitOpts);
            }
        }


        /// <summary>
        /// Показывает окно ожидания из параллельного потока (асинхронно).
        /// </summary>
        /// <param name="_stTitle">Заголовок окна, отображающийся посередине.</param>
        /// <param name="_Owner">Родительское окно.</param>
        /// <param name="_WaitStyle">Стиль окна ожидания.</param>
        /// <param name="_HeaderCircleColor">Цвет первого кружочка.</param>
        /// <param name="_CircleColor">Цвет всех остальных кружочков.</param>
        public void ShowAsync(string _stTitle, Window _Owner, WaitStyle _WaitStyle, Color _HeaderCircleColor, Color _CircleColor)
        {
            lock (_viewLock)
            {
                _counter++;
                if (_thread != null && _thread.IsAlive)
                    return;

                IntPtr Handler = IntPtr.Zero;
                double Left, Top, Width, Height;
                Left = Top = Width = Height = 0;
                if (_Owner != null)
                {
                    Handler = Services.WindowHelper.GetHandler(_Owner);
                    Left = _Owner.Left;
                    Top = _Owner.Top;
                    Width = _Owner.Width;
                    Height = _Owner.Height;
                }

                ParameterizedThreadStart ts = new ParameterizedThreadStart(Show);
                _thread = new Thread(ts);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Name = "WpfWaitView";
                _thread.IsBackground = true;
                WaitViewOptions waitOpts = new WaitViewOptions()
                {
                    stTitle = _stTitle,
                    Owner = _Owner,
                    OwnerHandler = Handler,
                    OwnerLeft = Left,
                    OwnerTop = Top,
                    OwnerWidht = Width,
                    OwnerHeight = Height,
                    WaitStyle = _WaitStyle,
                    CircleColor = _CircleColor.Name,
                    HeaderCircleColor = _HeaderCircleColor.Name
                };
                _thread.Start(waitOpts);
            }
        }


        /// <summary>
        /// Показывает окно ожидания из параллельного потока (асинхронно).
        /// </summary>
        /// <param name="_stTitle">Заголовок окна, отображающийся посередине.</param>
        /// <param name="_Owner">Родительская форма.</param>
        /// <param name="_WaitStyle">Стиль окна ожидания.</param>
        /// <param name="_HeaderCircleColor">Цвет первого кружочка.</param>
        /// <param name="_CircleColor">Цвет всех остальных кружочков.</param>
        public void ShowAsync(string _stTitle, Form _Owner, WaitStyle _WaitStyle, Color _HeaderCircleColor, Color _CircleColor)
        {
            lock (_viewLock)
            {
                _counter++;
                if (_thread != null && _thread.IsAlive)
                    return;

                IntPtr Handler = IntPtr.Zero;
                double Left, Top, Width, Height;
                Left = Top = Width = Height = 0;
                if (_Owner != null)
                {
                    Handler = _Owner.Handle;// Services.WindowHelper.GetHandler(_Owner);
                    Left = _Owner.Left;
                    Top = _Owner.Top;
                    Width = _Owner.Width;
                    Height = _Owner.Height;
                }

                ParameterizedThreadStart ts = new ParameterizedThreadStart(Show);
                _thread = new Thread(ts);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Name = "WpfWaitView";
                _thread.IsBackground = true;
                WaitViewOptions waitOpts = new WaitViewOptions()
                {
                    stTitle = _stTitle,
                    OwnerForm = _Owner,
                    OwnerHandler = Handler,
                    OwnerLeft = Left,
                    OwnerTop = Top,
                    OwnerWidht = Width,
                    OwnerHeight = Height,
                    WaitStyle = _WaitStyle,
                    CircleColor = _CircleColor.Name,
                    HeaderCircleColor = _HeaderCircleColor.Name
                };
                _thread.Start(waitOpts);
            }
        }



        /// <summary>
        /// Показывает окно ожидания из параллельного потока (асинхронно).
        /// </summary>
        /// <param name="_waitOpts">Набор настроек для отображения окна.</param>
        public void ShowAsync(WaitViewOptions _waitOpts)
        {
            lock (_viewLock)
            {
                _counter++;
                if (_thread != null && _thread.IsAlive)
                    return;

                WaitViewOptions waitOpts = _waitOpts;

                ParameterizedThreadStart ts = new ParameterizedThreadStart(Show);
                _thread = new Thread(ts);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Name = "WpfWaitView";
                _thread.IsBackground = true;
                _thread.Start(waitOpts);
            }
        }


        public void CloseAsync()
        {
            lock (_viewLock)
            {
                _counter--;

                if (_counter > 0 || !_thread.IsAlive
                    || ((this._thread.ThreadState & ThreadState.Running) != ThreadState.Running))
                {
                    return;
                }

                while (_view == null)// || (_view != null && System.Windows.PresentationSource.FromVisual(_view) as HwndSource != null))
                {
                    Thread.Sleep(100);
                }

                //Invoke
                _view.Dispatcher.BeginInvoke((Action)_view.Close);
                _view = null;

                this._thread.Join();
            }
        }

        #endregion Перегрузки ShowAsync и CloseAsync


        #region Изменение свойств

        public void SetTitle(string stNewTitle)
        {
            if (!IsAlive) return;

            while (_view == null)
            {
                Thread.Sleep(100);
            }

            if (_view.Dispatcher.Thread == Thread.CurrentThread)
            {
                (_view.DataContext as WaitViewModel).Title = stNewTitle;
            }
            else
            {
                _view.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { (_view.DataContext as WaitViewModel).Title = stNewTitle; });
            }
        }


        public void SetColors(Color HeaderCircleColor, Color CircleColor)
        {
            if (!IsAlive) return;

            while (_view == null)
            {
                Thread.Sleep(100);
            }

            if (_view.Dispatcher.Thread == Thread.CurrentThread)
            {
                (_view.DataContext as WaitViewModel).ProgressCircleColor = CircleColor.Name;
                (_view.DataContext as WaitViewModel).ProgressHeaderCircleColor = HeaderCircleColor.Name;
            }
            else
            {
                _view.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { (_view.DataContext as WaitViewModel).ProgressCircleColor = CircleColor.Name; });
                _view.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { (_view.DataContext as WaitViewModel).ProgressHeaderCircleColor = HeaderCircleColor.Name; });
            }
        }

        #endregion Изменение свойств

        #endregion Методы

    }
}
