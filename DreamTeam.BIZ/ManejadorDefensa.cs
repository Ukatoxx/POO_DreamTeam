using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.BIZ
{
    public class ManejadorDefensa : IManejadorDefensa
    {
        IRepositorio<Defensa> repositorio;
        public ManejadorDefensa(IRepositorio<Defensa> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Defensa> Listar => repositorio.Read;
        public List<Defensa> ListarAltura => repositorio.ReadAltura;

        public bool Agregar(Defensa entidad)
        {
            return repositorio.Create(entidad);
        }

        public Defensa BuscarPorId(string Id)
        {
            return Listar.Where(e => e.Id == Id).SingleOrDefault();
        }

        public List<Defensa> DefensaEspecifico(string PosicionEspecifica)
        {
            return Listar.Where(e => e.PosicionEspecifica == PosicionEspecifica).ToList();
        }

        public List<Defensa> DefensaRestante()
        {
            //return Listar.Where(e => e.Nombre == Nombre).ToList();
            return Listar.ToList();
        }

        public bool Eliminar(string Id)
        {
            return repositorio.Delete(Id);
        }

        public bool Modificar(Defensa entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
