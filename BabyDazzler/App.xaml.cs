﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BabyDazzler.Util;

namespace BabyDazzler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        private MainWindow mw;
        private KeyboardListener KListener = new KeyboardListener();
        delegate void AddShapeDelegate();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mw = new MainWindow();
            mw.Show();

            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);
        }

        void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            mw.WindowCanvas.Dispatcher.BeginInvoke(new AddShapeDelegate( () =>  { mw.AddShape(); }), null);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            KListener.Dispose();
        }
    }
}
