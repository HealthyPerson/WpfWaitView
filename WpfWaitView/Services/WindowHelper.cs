using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace HealthyPerson.WpfWaitView.Services
{

    public class WindowHelper
    {
        private const int GWL_HWNDPARENT = -8; // Owner --> not the parent


        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);


        public static void SetOwnerWindowMultithread(IntPtr windowHandleOwned, IntPtr intPtrOwner)
        {
            if (windowHandleOwned != IntPtr.Zero && intPtrOwner != IntPtr.Zero)
            {
                SetWindowLong(windowHandleOwned, GWL_HWNDPARENT, intPtrOwner.ToInt32());
            }
        }

        public static IntPtr GetHandler(Window window)
        {
            var interop = new WindowInteropHelper(window);
            return interop.Handle;
        }
    }
}
