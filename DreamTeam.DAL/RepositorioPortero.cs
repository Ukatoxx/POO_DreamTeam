using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.DAL
{
    public class RepositorioPortero : IRepositorio<Portero>
    {

        private string DBName = "DreamTeam.db";
        private string TableName = "Portero";

        public List<Portero> Read {
            get
            {
                List<Portero> datosPortero = new List<Portero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosPortero = db.GetCollection<Portero>(TableName).FindAll().ToList();
                }
                return datosPortero;
            }
        }

        public List<Portero> ReadEdad
        {
            get
            {
                List<Portero> datosPortero = new List<Portero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosPortero = db.GetCollection<Portero>(TableName).Find(Query.LTE("Edad", 27)).ToList();
                    
                }
                return datosPortero;
            }
        }

        public List<Portero> ReadAltura{
            get
            {
                List<Portero> datosPortero = new List<Portero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosPortero = db.GetCollection<Portero>(TableName).Find(Query.GTE("Altura", 190)).ToList();
                }
                return datosPortero;
            }
        }

        public List<Portero> ReadAlturaBaja
        {
            get
            {
                List<Portero> datosPortero = new List<Portero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosPortero = db.GetCollection<Portero>(TableName).Find(Query.LTE("Altura", 190)).ToList();
                }
                return datosPortero;
            }
        }

        public List<Portero> ReadPresupuestoBajo
        {
            get
            {
                List<Portero> datosPortero = new List<Portero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosPortero = db.GetCollection<Portero>(TableName).Find(Query.LTE("Sueldo", 120000)).ToList();
                }
                return datosPortero;
            }
        }

        public List<Portero> ReadPresupuestoAlto
        {
            get
            {
                List<Portero> datosPortero = new List<Portero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosPortero = db.GetCollection<Portero>(TableName).Find(Query.GTE("Sueldo", 120000)).ToList();
                }
                return datosPortero;
            }
        }

        public List<Portero> ReadAlturaBaja5 => throw new NotImplementedException();

        public List<Portero> ReadAlturaBaja3 => throw new NotImplementedException();

        public List<Portero> ReadAlturaBaja2 => throw new NotImplementedException();

        public List<Portero> ReadPresupuestoBajo5 => throw new NotImplementedException();

        public List<Portero> ReadPresupuestoBajo3 => throw new NotImplementedException();

        public List<Portero> ReadPresupuestoBajo2 => throw new NotImplementedException();

        public List<Portero> ReadPresupuestoAlto5 => throw new NotImplementedException();

        public List<Portero> ReadPresupuestoAlto3 => throw new NotImplementedException();

        public List<Portero> ReadPresupuestoAlto2 => throw new NotImplementedException();

        public List<Portero> ReadEdadMed4 => throw new NotImplementedException();

        public bool Create(Portero entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Portero>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string Id)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Portero>(TableName);
                    coleccion.Delete(Convert.ToString(Id));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Portero entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Portero>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        
    }
}
