using DreamTeam.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeam.COMMON.Interfaces
{
    public interface IManejadorPortero:IManejadorGenerico<Portero>
    {
        //List<Portero> PorteroRestante(string Nombre);
        List<Portero> PorteroRestante();
    }
}
