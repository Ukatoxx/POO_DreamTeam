using DreamTeam.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeam.COMMON.Interfaces
{
    public interface IManejadorDefensa:IManejadorGenerico<Defensa>
    {
        //List<Defensa> DefensaRestante(string Nombre);
        List<Defensa> DefensaRestante();
        List<Defensa> DefensaEspecifico(string PosicionEspecifica);
    }
}
