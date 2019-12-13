using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Laptop
    {
        public String Serie { get; set; }
        public String NombreLaptop { get; set; }
        public int IdMarca { get; set; }
        public String Modelo { get; set; }
        public String Procesador { get; set; }
        public String Ram { get; set; }
        public int HDD { get; set; }
        public int IDTeamviewer { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }      
        public DateTime FechaUltimaMantencion { get; set; }
        //public DateTime FechaSiguienteMantencion { get; set; }
        public String Opcional { get; set; }
        public String Comentario { get; set; }
        public String Estado { get; set; }
        public String MAC { get; set; }
        public int IdSistOperativo { get; set; }
        public String Rut_Usuario { get; set; }       
        public Laptop() { }
    }
}
