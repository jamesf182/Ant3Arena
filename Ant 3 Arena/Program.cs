using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Ant_3_Arena
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = Startup.ConfigureServices();

            var mainForm = serviceProvider.GetRequiredService<AntArena>();
            Application.Run(mainForm);
        }
	}
}
