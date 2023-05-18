using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 4GLCuadroDeMandoGarum.Model
{
  public  class VentasResponse
    {
        public string updatedate { get; set; }
        public string producto { get; set; }
        public string litros { get; set; }
        public string precio { get; set; }
        public string descuento { get; set; }
        public string importe { get; set; }
    }
}
