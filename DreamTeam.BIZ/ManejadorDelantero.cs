using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.BIZ
{
    public class ManejadorDelantero : IManejadorDelantero
    {
        IRepositorio<Delantero> repositorio;
        public ManejadorDelantero(IRepositorio<Delantero> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Delantero> Listar => repositorio.Read;
        public List<Delantero> ListarAltura => repositorio.ReadAltura;
        public List<Delantero> ListarEdad => repositorio.ReadEdad;

        public bool Agregar(Delantero entidad)
        {
            return repositorio.Create(entidad);
        }

        public Delantero BuscarPorId(string Id)
        {
            return Listar.Where(e => e.Id == Id).SingleOrDefault();
        }

        public List<Delantero> DelanteroEspecifico(string PosicionEspecifica)
        {
            return Listar.Where(e => e.PosicionEspecifica == PosicionEspecifica).ToList();
        }

        public List<Delantero> DelanteroRestante()
        {
            //return Listar.Where(e => e.Nombre == Nombre).ToList();
            return Listar.ToList();
        }

        public bool Eliminar(string Id)
        {
            return repositorio.Delete(Id);
        }

        public bool Modificar(Delantero entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
