using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.DAL
{
    public class RepositorioMediocampo : IRepositorio<Mediocampo>
    {

        private string DBName = "DreamTeam.db";
        private string TableName = "Mediocampo";

        public List<Mediocampo> Read
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).FindAll().ToList();
                }
                return datosMediocampo;
            }
        }

        public List<Mediocampo> ReadEdad
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).Find(Query.And(Query.LTE("Edad", 27),
                        Query.Or(Query.EQ("PosicionEspecifica", "Mediocentro Defensivo"), Query.EQ("PosicionEspecifica", "Medio Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Medio Derecho")))).ToList();
                }
                return datosMediocampo;
            }
        }

        public List<Mediocampo> ReadEdadMed4
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).Find(Query.And(Query.LTE("Edad", 27),
                        Query.Or(Query.EQ("PosicionEspecifica", "Medio Centro"), Query.EQ("PosicionEspecifica", "Medio Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Medio Derecho")))).ToList();
                }
                return datosMediocampo;
            }
        }

        public List<Mediocampo> ReadAltura
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).Find(Query.And(Query.GTE("Altura", 185),
                        Query.Or(Query.EQ("PosicionEspecifica", "Mediocentro Defensivo"), Query.EQ("PosicionEspecifica", "Medio Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Medio Derecho")))).ToList();
                }
                return datosMediocampo;
            }
        }

        public List<Mediocampo> ReadAlturaBaja3
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).Find(Query.And(Query.LTE("Altura", 185),
                        Query.Or(Query.EQ("PosicionEspecifica", "Mediocentro Defensivo"), Query.EQ("PosicionEspecifica", "Medio Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Medio Derecho")))).ToList();
                }
                return datosMediocampo;
            }
        }

        public List<Mediocampo> ReadPresupuestoBajo3
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).Find(Query.And(Query.LTE("Sueldo", 125000),
                        Query.Or(Query.EQ("PosicionEspecifica", "Mediocentro Defensivo"), Query.EQ("PosicionEspecifica", "Medio Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Medio Derecho")))).ToList();
                }
                return datosMediocampo;
            }
        }

        public List<Mediocampo> ReadPresupuestoAlto3
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).Find(Query.And(Query.GTE("Sueldo", 125000),
                        Query.Or(Query.EQ("PosicionEspecifica", "Mediocentro Defensivo"), Query.EQ("PosicionEspecifica", "Medio Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Medio Derecho")))).ToList();
                }
                return datosMediocampo;
            }
        }

        public List<Mediocampo> ReadAlturaBaja5 => throw new NotImplementedException();

        public List<Mediocampo> ReadAlturaBaja2 => throw new NotImplementedException();

        public List<Mediocampo> ReadAlturaBaja => throw new NotImplementedException();

        public List<Mediocampo> ReadPresupuestoBajo => throw new NotImplementedException();

        public List<Mediocampo> ReadPresupuestoBajo5 => throw new NotImplementedException();

        public List<Mediocampo> ReadPresupuestoBajo2 => throw new NotImplementedException();

        public List<Mediocampo> ReadPresupuestoAlto => throw new NotImplementedException();

        public List<Mediocampo> ReadPresupuestoAlto5 => throw new NotImplementedException();

        public List<Mediocampo> ReadPresupuestoAlto2 => throw new NotImplementedException();

        public bool Create(Mediocampo entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Mediocampo>(TableName);
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
                    var coleccion = db.GetCollection<Mediocampo>(TableName);
                    coleccion.Delete(Convert.ToString(Id));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Mediocampo entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Mediocampo>(TableName);
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
