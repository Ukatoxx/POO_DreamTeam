using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.BIZ
{
    public class ManejadorPortero : IManejadorPortero
    {
        IRepositorio<Portero> repositorio;
        public ManejadorPortero(IRepositorio<Portero> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Portero> Listar => repositorio.Read;

        public bool Agregar(Portero entidad)
        {
            return repositorio.Create(entidad);
        }

        public Portero BuscarPorId(string Id)
        {
            return Listar.Where(e => e.Id == Id).SingleOrDefault();
        }

        public bool Eliminar(string Id)
        {
            return repositorio.Delete(Id);
        }

        public bool Modificar(Portero entidad)
        {
            return repositorio.Update(entidad);
        }

        public List<Portero> PorteroRestante()
        {
            //return Listar.Where(e => e.Nombre == Nombre).ToList();
            return Listar.ToList();
        }
    }
}
