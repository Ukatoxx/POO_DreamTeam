using DreamTeam.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeam.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base
    {
        bool Create(T entidad);
        List<T> Read { get; }
        List<T> ReadEdad { get; }
        List<T> ReadAltura { get; }
        List<T> ReadAlturaBaja { get; }
        List<T> ReadAlturaBaja5 { get; }
        List<T> ReadAlturaBaja3 { get; }
        List<T> ReadAlturaBaja2 { get; }
        List<T> ReadPresupuestoBajo { get; }
        List<T> ReadPresupuestoBajo5 { get; }
        List<T> ReadPresupuestoBajo3 { get; }
        List<T> ReadPresupuestoBajo2 { get; }
        List<T> ReadPresupuestoAlto { get; }
        List<T> ReadPresupuestoAlto5 { get; }
        List<T> ReadPresupuestoAlto3 { get; }
        List<T> ReadPresupuestoAlto2 { get; }
        List<T> ReadEdadMed4 { get; }
        bool Update(T entidadModificada);
        bool Delete(string Id);
        
    }
}
