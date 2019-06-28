//=========================================================================
// File: HiddenForm             Creator: Tudor Mironovici   tcm26@njit.edu
//
// Purpose: Have a caps lock activity icon in the notification tray.
//=========================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Management.Instrumentation;
using System.Collections.Specialized;
using System.Threading;
using System.IO;

namespace Caps_Lock_LED
{
    public partial class HiddenForm : Form
    {
        //---Global Variables---
        NotifyIcon capslockIcon;
        Icon capslockOn;
        Icon capslockOff;
        Thread capslockWorker;
        //----------------------

        public HiddenForm()
        {
            //--------------------------------------------
            // Since this program runs only in the
            // notification tray, we can hide the window.
            //--------------------------------------------
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //------------------------
            // Injects icons for use.
            //------------------------
            capslockOn = new Icon("capslockOn.ico");
            capslockOff = new Icon("capslockOff.ico");
            capslockIcon = new NotifyIcon();
            capslockIcon.Icon = capslockOff;
            capslockIcon.Visible = true;

            //------------------------------------------
            // Makes a "quit" menu option, just in case
            // the program needs to be shut down.
            //------------------------------------------
            MenuItem quitMenuItem = new MenuItem("Quit");
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(quitMenuItem);
            capslockIcon.ContextMenu = contextMenu;
            quitMenuItem.Click += QuitMenuItem_Click;
            capslockWorker = new Thread(new ThreadStart(capslockActivityThread));
            capslockWorker.Start();
        }

        //-----------------------------------
        // Properly closes down the program.
        //-----------------------------------
        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            capslockWorker.Abort();
            capslockIcon.Dispose();
            this.Close();
        }

        //----------------------------------------------------
        // Checks the status of the Caps Lock key and changed
        // the status icon to reflect the key's status.
        //----------------------------------------------------
        private void capslockActivityThread()
        {
            try
            {
                while (true)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock))
                    {
                        capslockIcon.Icon = capslockOn;
                    }
                    else
                    {
                        capslockIcon.Icon = capslockOff;
                    }
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException e)
            {

            }
        }

        private void HiddenForm_Load(object sender, EventArgs e)
        {

        }
    }
}