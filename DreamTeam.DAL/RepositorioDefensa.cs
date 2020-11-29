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
                    //datosDefensa = db.GetCollection<Defensa>(TableName).Find(Query.LTE("Edad", 27)).ToList();
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
                    datosDefensa = db.GetCollection<Defensa>(TableName).Find(Query.GTE("Altura", 190)).ToList();
                }
                return datosDefensa;
            }
        }

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
