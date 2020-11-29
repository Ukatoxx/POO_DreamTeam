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

        public List<Mediocampo> ReadAltura
        {
            get
            {
                List<Mediocampo> datosMediocampo = new List<Mediocampo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datosMediocampo = db.GetCollection<Mediocampo>(TableName).Find(Query.GTE("Altura", 190)).ToList();
                }
                return datosMediocampo;
            }
        }

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
