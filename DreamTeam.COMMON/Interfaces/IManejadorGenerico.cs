using DreamTeam.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeam.COMMON.Interfaces
{
    public interface IManejadorGenerico<T> where T:Base
    {
        bool Agregar(T entidad);
        List<T> Listar { get; }
        List<T> ListarAltura { get; }
        bool Eliminar(string Id);
        bool Modificar(T entidad);
        T BuscarPorId(string Id);
    }
}
