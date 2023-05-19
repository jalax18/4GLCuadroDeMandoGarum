using _4GLCuadroDeMandoRevisionDeFicherosGarum.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4GLCuadroDeMandoRevisionDeFicherosGarum.Model
{
   public class FicheroGarumResponse
    {

        public int Id { get; set; }
        public DateTime? Fecha_Estudio { get; set; }
        public DateTime? Fecha_Fichero { get; set; }
        public string Nombre_Estacion { get; set; }
        public string Nombre_Fichero { get; set; }
        public string TPV { get; set; }
        public string Serie { get; set; }
        public string Descripcion { get; set; }
        public string Estacionid { get; set; }

        public UserResponse User { get; set; }
        public EstacionResponse Estacion { get; set; }
        //public int UserId { get; set; }
       // public int EstacionId { get; set; }
    }
}
