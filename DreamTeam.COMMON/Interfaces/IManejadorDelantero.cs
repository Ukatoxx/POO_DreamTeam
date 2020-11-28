using DreamTeam.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeam.COMMON.Interfaces
{
    public interface IManejadorDelantero:IManejadorGenerico<Delantero>
    {
        //List<Delantero> DelanteroRestante(string Nombre);
        List<Delantero> DelanteroRestante();
        List<Delantero> DelanteroEspecifico(string PosicionEspecifica);
    }
}
