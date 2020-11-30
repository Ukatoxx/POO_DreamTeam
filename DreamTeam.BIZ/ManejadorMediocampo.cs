using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.BIZ
{
    public class ManejadorMediocampo : IManejadorMediocampo
    {
        IRepositorio<Mediocampo> repositorio;
        public ManejadorMediocampo(IRepositorio<Mediocampo> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Mediocampo> Listar => repositorio.Read;
        public List<Mediocampo> ListarAltura => repositorio.ReadAltura;
        public List<Mediocampo> ListarAlturaBaja3 => repositorio.ReadAlturaBaja3;
        public List<Mediocampo> ListarEdad => repositorio.ReadEdad;


        public List<Mediocampo> ListarAlturaBaja5 => throw new NotImplementedException();

        public List<Mediocampo> ListarAlturaBaja2 => throw new NotImplementedException();

        public List<Mediocampo> ListarAlturaBaja => throw new NotImplementedException();
        public List<Mediocampo> ListarPresupuestoBajo => throw new NotImplementedException();
        public List<Mediocampo> ListarPresupuestoBajo5 => throw new NotImplementedException();
        public List<Mediocampo> ListarPresupuestoBajo3 => repositorio.ReadPresupuestoBajo3;
        public List<Mediocampo> ListarPresupuestoBajo2 => throw new NotImplementedException();
        public List<Mediocampo> ListarPresupuestoAlto => throw new NotImplementedException();
        public List<Mediocampo> ListarPresupuestoAlto5 => throw new NotImplementedException();
        public List<Mediocampo> ListarPresupuestoAlto3 => repositorio.ReadPresupuestoAlto3;
        public List<Mediocampo> ListarPresupuestoAlto2 => throw new NotImplementedException();

        public List<Mediocampo> ListarEdadMed4 => repositorio.ReadEdadMed4;

        public bool Agregar(Mediocampo entidad)
        {
            return repositorio.Create(entidad);
        }

        public Mediocampo BuscarPorId(string Id)
        {
            return Listar.Where(e => e.Id == Id).SingleOrDefault();
        }

        public bool Eliminar(string Id)
        {
            return repositorio.Delete(Id);
        }

        public List<Mediocampo> MediocampoEspecifico(string PosicionEspecifica)
        {
            return Listar.Where(e => e.PosicionEspecifica == PosicionEspecifica).ToList();
        }

        public List<Mediocampo> MediocampoRestante()
        {
            //return Listar.Where(e => e.Nombre == Nombre).ToList();
            return Listar.ToList();
        }

        public bool Modificar(Mediocampo entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
