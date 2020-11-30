using DreamTeam.COMMON.Entidades;
using DreamTeam.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamTeam.DAL
{
    public class RepositorioDefensa : IRepositorio<Defensa>
    {
        private string DBName = "DreamTeam.db";
        private string TableName = "Defensa";

        public List<Defensa> Read
        {
            get
            {
                List<Defensa> datosDefensa = new List<Defensa>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDefensa = db.GetCollection<Defensa>(TableName).FindAll().ToList();
                }
                return datosDefensa;
            }
        }

        public List<Defensa> ReadEdad
        {
            get
            {
                List<Defensa> datosDefensa = new List<Defensa>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDefensa = db.GetCollection<Defensa>(TableName).Find(Query.And(Query.LTE("Edad", 27),
                        Query.Or(Query.EQ("PosicionEspecifica", "Defensa Central"), Query.EQ("PosicionEspecifica", "Lateral Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Lateral Derecho")))).ToList();
                }
                return datosDefensa;
            }
        }

        public List<Defensa> ReadAltura
        {
            get
            {
                List<Defensa> datosDefensa = new List<Defensa>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDefensa = db.GetCollection<Defensa>(TableName).Find(Query.And(Query.GTE("Altura", 187),
                        Query.Or(Query.EQ("PosicionEspecifica", "Defensa Central"), Query.EQ("PosicionEspecifica", "Lateral Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Lateral Derecho")))).ToList();
                }
                return datosDefensa;
            }
        }

        public List<Defensa> ReadAlturaBaja5
        {
            get
            {
                List<Defensa> datosDefensa = new List<Defensa>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDefensa = db.GetCollection<Defensa>(TableName).Find(Query.And(Query.LTE("Altura", 187),
                        Query.Or(Query.EQ("PosicionEspecifica", "Defensa Central"), Query.EQ("PosicionEspecifica", "Lateral Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Lateral Derecho")))).ToList();
                }
                return datosDefensa;
            }
        }

        public List<Defensa> ReadPresupuestoBajo5
        {
            get
            {
                List<Defensa> datosDefensa = new List<Defensa>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDefensa = db.GetCollection<Defensa>(TableName).Find(Query.And(Query.LTE("Sueldo", 125000),
                        Query.Or(Query.EQ("PosicionEspecifica", "Defensa Central"), Query.EQ("PosicionEspecifica", "Lateral Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Lateral Derecho")))).ToList();
                }
                return datosDefensa;
            }
        }

        public List<Defensa> ReadPresupuestoAlto5
        {
            get
            {
                List<Defensa> datosDefensa = new List<Defensa>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosDefensa = db.GetCollection<Defensa>(TableName).Find(Query.And(Query.GTE("Sueldo", 125000),
                        Query.Or(Query.EQ("PosicionEspecifica", "Defensa Central"), Query.EQ("PosicionEspecifica", "Lateral Izquierdo"),
                        Query.EQ("PosicionEspecifica", "Lateral Derecho")))).ToList();
                }
                return datosDefensa;
            }
        }

        public List<Defensa> ReadAlturaBaja3 => throw new NotImplementedException();

        public List<Defensa> ReadAlturaBaja2 => throw new NotImplementedException();

        public List<Defensa> ReadAlturaBaja => throw new NotImplementedException();

        public List<Defensa> ReadPresupuestoBajo => throw new NotImplementedException();

        public List<Defensa> ReadPresupuestoBajo3 => throw new NotImplementedException();

        public List<Defensa> ReadPresupuestoBajo2 => throw new NotImplementedException();

        public List<Defensa> ReadPresupuestoAlto => throw new NotImplementedException();

        public List<Defensa> ReadPresupuestoAlto3 => throw new NotImplementedException();

        public List<Defensa> ReadPresupuestoAlto2 => throw new NotImplementedException();

        public List<Defensa> ReadEdadMed4 => throw new NotImplementedException();

        public bool Create(Defensa entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Defensa>(TableName);
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
                    var coleccion = db.GetCollection<Defensa>(TableName);
                    coleccion.Delete(Convert.ToString(Id));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Defensa entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Defensa>(TableName);
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
