﻿using Simulation.Logging;
using System.Windows;

namespace Simulator.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            LogManager.EnableInfoLogging();
#endif
            base.OnStartup(e);
        }
    }
}
