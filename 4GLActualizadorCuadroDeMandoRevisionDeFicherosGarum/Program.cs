using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//4GLActualizadorCuadroDeMandoRevisionDeFicherosGarum

namespace _4GLActualizadorCuadroDeMandoRevisionDeFicherosGarum
{
    class Program
    {
        private static void Main(string[] args)
        {
            Process[] LocalByName = Process.GetProcessesByName("4GLCuadroDeMandoRevisionDeFicherosGarum");

            foreach (Process proc in LocalByName)
            {

                  proc.Kill();

            }

            string directorioorigen = @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum";
            string directoriobackup = @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\Backup" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            string directoriodedescarga = @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp\";
            if (!Directory.Exists(directoriobackup)) // si no existe lo creo y copio el contenido de todo el directorio de control incidencias
            {
                Directory.CreateDirectory(directoriobackup);
            }

            if (Directory.Exists(directorioorigen) && Directory.Exists(directoriodedescarga)) //compruebo qeu existen el directorio de origen y el de descarga 
            {

                string[] fileEntries = Directory.GetFiles(directorioorigen);

                foreach (string fileName in fileEntries)
                {
                    string ficherosource = fileName;
                    string ficherodestino = directoriobackup + @"/" + fileName.Replace(@"\", "").Substring(50, fileName.Replace(@"\", "").Length - 50);
                    try
                    {
                        File.Copy(ficherosource, ficherodestino);
                    }
                    catch (Exception)
                    {

                    }


                }
                string[] fileEntries1 = Directory.GetFiles(directoriodedescarga);

                foreach (string fileName in fileEntries1)
                {
                    string ficherosource = fileName;
                    string ficherodestino = directorioorigen + @"\" + fileName.Replace(@"\", "").Substring(66, fileName.Replace(@"\", "").Length - 66);
                    try
                    {
                        File.Copy(ficherosource, ficherodestino, true);
                    }
                    catch (Exception)
                    {

                    }


                }

            }

            try
            {
                Thread.Sleep(5000);
                System.Diagnostics.Process.Start(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\4GLCuadroDeMandoRevisionDeFicherosGarum.exe");


            }
            catch (Exception)
            {


            }
        }
    }
}
