﻿using DreamTeam.COMMON.Entidades;
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

        //public bool Delete(string Id)
        //{
        //    try
        //    {
        //        int r;
        //        using (var db = new LiteDatabase(DBName))
        //        {
        //            var coleccion = db.GetCollection<Portero>(TableName);
        //            r = coleccion.Delete(e => e.Id == Id);
        //        }
        //        return r > 0;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public bool Delete(string Id)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Portero>(TableName);
                    coleccion.Delete(Convert.ToInt32(Id));
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
