using BootStrapper.FlickerConsole.OnStart;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BootStrapper.FlickerConsole
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BootStrap _bootstrap;

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrap = new BootStrap();
            _bootstrap.Initialize();
        }
    }
}
