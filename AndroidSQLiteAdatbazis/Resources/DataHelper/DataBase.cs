using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Android.Util;
using AndroidSQLite.Resources.Model;

namespace AndroidSQLite.Resources.DataHelper
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDataBase()    // Adatbázis létrehozása
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "szemelyek.db")))
                {
                    connection.CreateTable<Szemely>();
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool insertIntoTableSzemely(Szemely szemely)    // Új rekord felvitele
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "szemelyek.db")))
                {
                    connection.Insert(szemely);
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Szemely> selectTableSzemely()     // Adatbázis kapcsolat
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "szemelyek.db")))
                {
                    return connection.Table<Szemely>().ToList();
                   
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool updateTableSzemely(Szemely szemely)    // Módosítás
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "szemelyek.db")))
                {
                    connection.Query<Szemely>("UPDATE Szemely set Name=?,Age=?,Email=? Where Id=?",szemely.Name,szemely.Age,szemely.Email,szemely.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool deleteTableSzemely(Szemely szemely)    // Törlés
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "szemelyek.db")))
                {
                    connection.Delete(szemely);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool selectQueryTableSzemely(int Id)  // Tábla adatainak lekérése
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "szemelyek.db")))
                {
                    connection.Query<Szemely>("SELECT * FROM Szemely Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

    }
}