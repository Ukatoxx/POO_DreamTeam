using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.DAL
{
    public class RepositorioDelantero : IRepositorio<Delantero>
    {

        private string DBName = "DreamTeam.db";
        private string TableName = "Delantero";

        public List<Delantero> Read
        {
            get
            {
                List<Delantero> datosDelantero = new List<Delantero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDelantero = db.GetCollection<Delantero>(TableName).FindAll().ToList();
                }
                return datosDelantero;
            }
        }

        public List<Delantero> ReadEdad
        {
            get
            {
                List<Delantero> datosDelantero = new List<Delantero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDelantero = db.GetCollection<Delantero>(TableName).Find(Query.And(Query.LTE("Edad", 27),
                        Query.EQ("PosicionEspecifica", "Delantero"))).ToList();
                }
                return datosDelantero;
            }
        }

        public List<Delantero> ReadAltura
        {
            get
            {
                List<Delantero> datosDelantero = new List<Delantero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDelantero = db.GetCollection<Delantero>(TableName).Find(Query.And(Query.GTE("Altura", 187),
                        Query.EQ("PosicionEspecifica", "Delantero"))).ToList();
                }
                return datosDelantero;
            }
        }

        public List<Delantero> ReadAlturaBaja2
        {
            get
            {
                List<Delantero> datosDelantero = new List<Delantero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDelantero = db.GetCollection<Delantero>(TableName).Find(Query.And(Query.LTE("Altura", 187),
                        Query.EQ("PosicionEspecifica", "Delantero"))).ToList();
                }
                return datosDelantero;
            }
        }

        public List<Delantero> ReadPresupuestoBajo2
        {
            get
            {
                List<Delantero> datosDelantero = new List<Delantero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDelantero = db.GetCollection<Delantero>(TableName).Find(Query.And(Query.LTE("Sueldo", 180000),
                        Query.EQ("PosicionEspecifica", "Delantero"))).ToList();
                }
                return datosDelantero;
            }
        }

        public List<Delantero> ReadPresupuestoAlto2
        {
            get
            {
                List<Delantero> datosDelantero = new List<Delantero>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDelantero = db.GetCollection<Delantero>(TableName).Find(Query.And(Query.GTE("Sueldo", 180000),
                        Query.EQ("PosicionEspecifica", "Delantero"))).ToList();
                }
                return datosDelantero;
            }
        }

        public List<Delantero> ReadAlturaBaja5 => throw new NotImplementedException();

        public List<Delantero> ReadAlturaBaja3 => throw new NotImplementedException();

        public List<Delantero> ReadAlturaBaja => throw new NotImplementedException();

        public List<Delantero> ReadPresupuestoBajo => throw new NotImplementedException();

        public List<Delantero> ReadPresupuestoBajo5 => throw new NotImplementedException();

        public List<Delantero> ReadPresupuestoBajo3 => throw new NotImplementedException();

        public List<Delantero> ReadPresupuestoAlto => throw new NotImplementedException();

        public List<Delantero> ReadPresupuestoAlto5 => throw new NotImplementedException();

        public List<Delantero> ReadPresupuestoAlto3 => throw new NotImplementedException();

        public List<Delantero> ReadEdadMed4 => throw new NotImplementedException();

        public bool Create(Delantero entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Delantero>(TableName);
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
                    var coleccion = db.GetCollection<Delantero>(TableName);
                    coleccion.Delete(Convert.ToString(Id));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Delantero entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Delantero>(TableName);
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
