using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrancaCuadrosdeMando
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] LocalByName1 = Process.GetProcessesByName("4GLCuadroDeMandoRevisionDeAjustesGarum");
            Process[] LocalByName2 = Process.GetProcessesByName("4GLCuadroDeMandoRevisionDeFicherosGarum");
            Process[] LocalByName3 = Process.GetProcessesByName("4GLCuadroDeMandoAutomat");
            Process[] LocalByName4 = Process.GetProcessesByName("TcptoComPaneldeControl");

            foreach (Process proc in LocalByName1)
            {

                proc.Kill();

            }
            foreach (Process proc in LocalByName2)
            {

                proc.Kill();

            }
            foreach (Process proc in LocalByName3)
            {

                proc.Kill();

            }
            foreach (Process proc in LocalByName4)
            {

                proc.Kill();

            }

            Thread.Sleep(5000);
            System.Diagnostics.Process.Start(@"c:\garumtools\4GLCuadrodeMando-RevisionDeAjustesGarum\4GLCuadroDeMandoRevisionDeAjustesGarum.exe");
            System.Diagnostics.Process.Start(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\4GLCuadroDeMandoRevisionDeFicherosGarum.exe");
            System.Diagnostics.Process.Start(@"c:\garumtools\4GLCuadrodeMando-Automat\4GLCuadroDeMandoAutomat.exe");
            System.Diagnostics.Process.Start(@"c:\garumtools\4GLCuadrodeMando-Sondas\TcptoComPaneldeControl.exe");


        }
    }
}
