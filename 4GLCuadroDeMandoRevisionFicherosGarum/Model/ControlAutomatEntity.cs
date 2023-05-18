using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 4GLCuadroDeMandoGarum.Model
{
    public class ControlAutomatEntity
    {
        public int id { get; set; }
        public string producto { get; set; }
        public string litros { get; set; }
        public string precio { get; set; }
        public string descuento { get; set; }
        public string importe { get; set; }
        public DateTime ultimaMedicion { get; set; }
        public DateTime ultimaOperacion { get; set; }
        public string estacion { get; set; }
        public int idEstacion { get; set; }

        public int horasError { get; set; }
        public int externaVenta { get; set; }

        public int mm4 { get; set; }

        public string versionApp { get; set; }



    }
}
