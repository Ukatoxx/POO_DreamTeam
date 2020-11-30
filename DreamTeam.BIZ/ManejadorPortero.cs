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
        public List<Portero> ListarAltura => repositorio.ReadAltura;
        public List<Portero> ListarEdad => repositorio.ReadEdad;

        public List<Portero> PresupuestoBajo => repositorio.ReadPresupuestoBajo;

        public List<Portero> ListarAlturaBaja5 => throw new NotImplementedException();

        public List<Portero> ListarAlturaBaja3 => throw new NotImplementedException();

        public List<Portero> ListarAlturaBaja2 => throw new NotImplementedException();

        public List<Portero> ListarAlturaBaja => repositorio.ReadAlturaBaja;

        public List<Portero> ListarPresupuestoBajo => repositorio.ReadPresupuestoBajo;

        public List<Portero> ListarPresupuestoBajo5 => throw new NotImplementedException();

        public List<Portero> ListarPresupuestoBajo3 => throw new NotImplementedException();

        public List<Portero> ListarPresupuestoBajo2 => throw new NotImplementedException();

        public List<Portero> ListarPresupuestoAlto => repositorio.ReadPresupuestoAlto;

        public List<Portero> ListarPresupuestoAlto5 => throw new NotImplementedException();

        public List<Portero> ListarPresupuestoAlto3 => throw new NotImplementedException();

        public List<Portero> ListarPresupuestoAlto2 => throw new NotImplementedException();

        public List<Portero> ListarEdadMed4 => throw new NotImplementedException();

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
