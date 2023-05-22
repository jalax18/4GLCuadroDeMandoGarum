using System;
using System.Collections.Generic;
using System.Text;

namespace _4GLCuadroDeMandoRevisionDeAjustesGarum.Model
{
    public class EstudioAjusteResponse
    {

        public int Id { get; set; }
        public string surtidor { get; set; }
        public string Manguera { get; set; }
        public string Nombre_Producto { get; set; }
        public decimal LitrosLec { get; set; }
        public decimal Litrosvta { get; set; }
        public decimal Diferencia { get; set; }
        public DateTime? Fecha_estudio { get; set; }
        public DateTime? Fecha_Ajustes { get; set; }
        public string Nombre_Estacion { get; set; }
        public decimal Contador_inicial { get; set; }
        public decimal Contador_Final { get; set; }
        public string Tipo_contador_inicial { get; set; }
        public string Tipo_contador_Final { get; set; }
        public UserResponse User { get; set; }
        public EstacionResponse Estacion { get; set; }

    }
}
