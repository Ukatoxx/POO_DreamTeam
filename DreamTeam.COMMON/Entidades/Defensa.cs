using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeam.COMMON.Entidades
{
    public class Defensa:Base
    {
        public string Nombre { get; set; }
        public string PosicionEspecifica { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public string PieHabil { get; set; }
        public int Edad { get; set; }
        public int Precio { get; set; }
        public int Sueldo { get; set; }
        public int HabilidadBalon { get; set; }
        public int DefensaVal { get; set; }
        public int MentalVal { get; set; }
        public int PaseVal { get; set; }
        public int FisicoVal { get; set; }
        public int TirosVal { get; set; }
        public int PorteroVal { get; set; }
    }
}
