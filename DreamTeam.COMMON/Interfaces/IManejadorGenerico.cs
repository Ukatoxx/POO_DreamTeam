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
        List<T> ListarEdad { get; }
        List<T> ListarAltura { get; }
        List<T> ListarAlturaBaja5 { get; }
        List<T> ListarAlturaBaja3 { get; }
        List<T> ListarAlturaBaja2 { get; }
        List<T> ListarAlturaBaja { get; }
        List<T> ListarPresupuestoBajo { get; }
        List<T> ListarPresupuestoBajo5 { get; }
        List<T> ListarPresupuestoBajo3 { get; }
        List<T> ListarPresupuestoBajo2 { get; }
        List<T> ListarPresupuestoAlto { get; }
        List<T> ListarPresupuestoAlto5 { get; }
        List<T> ListarPresupuestoAlto3 { get; }
        List<T> ListarPresupuestoAlto2 { get; }
        List<T> ListarEdadMed4 { get; }
        bool Eliminar(string Id);
        bool Modificar(T entidad);
        T BuscarPorId(string Id);
    }
}
