using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace Entrega2_Equipo1
{
    class Program
    {
		[STAThread]
		static void Main(string[] args)
        {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainWindow mainWindow = new MainWindow();
			Application.Run(mainWindow);

		}
    }
}
