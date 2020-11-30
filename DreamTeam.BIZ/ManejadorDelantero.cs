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
        public List<Delantero> ListarAlturaBaja2 => repositorio.ReadAlturaBaja2;
        public List<Delantero> ListarEdad => repositorio.ReadEdad;

        public List<Delantero> ListarAlturaBaja5 => throw new NotImplementedException();

        public List<Delantero> ListarAlturaBaja3 => throw new NotImplementedException();

        public List<Delantero> ListarAlturaBaja => throw new NotImplementedException();

        public List<Delantero> ListarPresupuestoBajo => throw new NotImplementedException();

        public List<Delantero> ListarPresupuestoBajo5 => throw new NotImplementedException();

        public List<Delantero> ListarPresupuestoBajo3 => throw new NotImplementedException();

        public List<Delantero> ListarPresupuestoBajo2 => repositorio.ReadPresupuestoBajo2;

        public List<Delantero> ListarPresupuestoAlto => throw new NotImplementedException();

        public List<Delantero> ListarPresupuestoAlto5 => throw new NotImplementedException();

        public List<Delantero> ListarPresupuestoAlto3 => throw new NotImplementedException();

        public List<Delantero> ListarPresupuestoAlto2 => repositorio.ReadPresupuestoAlto2;

        public List<Delantero> ListarEdadMed4 => throw new NotImplementedException();

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
