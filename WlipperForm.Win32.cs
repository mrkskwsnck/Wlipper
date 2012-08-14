using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;

namespace Wlipper
{
    /// <summary>
    /// Embedding low level Win32 functions needed to listening for clipboard changing events.
    /// </summary>
    partial class WlipperForm
    {
        #region Constants

        private enum WM : int
        {
            /// <summary>
            /// The WM_DRAWCLIPBOARD message is sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard viewer window to display the new content of the clipboard.
            /// </summary>
            DRAWCLIPBOARD = 0x0308,

            /// <summary>
            /// The WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed from the chain.
            /// </summary>
            CHANGECBCHAIN = 0x030D
        }

        #endregion

        #region Win32 integration

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWindowView);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWindowRemove, IntPtr hWindowNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWindow, int wMessage, IntPtr wParameter, IntPtr lParameter);

        #endregion

        #region Fields

        IntPtr chainedWindow;

        #endregion

        #region Properties

        private IntPtr ChainedWindow
        {
            get
            {
                return chainedWindow;
            }
            set
            {
                chainedWindow = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add this control to the Clipboard chain to receive notification events.
        /// </summary>
        private void RegisterWindowToChain()
        {
            ChainedWindow = SetClipboardViewer(this.Handle);
        }

        /// <summary>
        /// Remove this from the Clipboard Viewer list.
        /// </summary>
        private void UnregisterWindowFromChain()
        {
            ChangeClipboardChain(this.Handle, ChainedWindow);
        }

        /// <summary>
        /// Process window messages.
        /// <remarks>
        /// This code has been modified from examples found while researching the subject!
        /// </remarks>
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)WM.DRAWCLIPBOARD:
                    MakeItSo();

                    // Each window that receives the WM_DRAWCLIPBOARD message
                    // must call the SendMessage function to pass the message
                    // on to the next window in the clipboard viewer chain.
                    SendMessage(ChainedWindow, m.Msg, m.WParam, m.LParam);

                    break;

                // The WM_CHANGECBCHAIN message is sent to the first window
                // in the clipboard viewer chain when a window is being
                // removed from the chain.
                case (int)WM.CHANGECBCHAIN:
                    // When a clipboard viewer window receives the WM_CHANGECBCHAIN message,
                    // it should call the SendMessage function to pass the message to the
                    // next window in the chain, unless the next window is the window
                    // being removed. In this case, the clipboard viewer should save
                    // the handle specified by the lParam parameter
                    // as the next window in the chain.

                    // wParam is the Handle to the window being removed from
                    // the clipboard viewer chain
                    // Param is the Handle to the next window in the chain
                    // following the window being removed.
                    if (m.WParam == ChainedWindow)
                    {
                        // If wParam is the next clipboard viewer then it
                        // is being removed so update pointer to the next
                        // window in the clipboard chain
                        ChainedWindow = m.LParam;
                    }
                    else
                    {
                        SendMessage(ChainedWindow, m.Msg, m.WParam, m.LParam);
                    }
                    break;

                default:
                    // Just pass the message on.
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion
    }
}
