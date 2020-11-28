using DreamTeam.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeam.COMMON.Interfaces
{
    public interface IManejadorMediocampo:IManejadorGenerico<Mediocampo>
    {
        //List<Mediocampo> MediocampoRestante(string Nombre);
        List<Mediocampo> MediocampoRestante();
        List<Mediocampo> MediocampoEspecifico(string PosicionEspecifica);
    }
}
