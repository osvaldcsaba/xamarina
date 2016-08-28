
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
using Android.Database.Sqlite;
using System.IO;

namespace UsingDataInLists
{
	public class vtcDatabase
	{
		private SQLiteDatabase sqlDatabase;

        public vtcDatabase(string DatabaseName)
        {
            CreateDatabase(DatabaseName);
        }

        public void CreateDatabase(string DatabaseName)
        {
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, DatabaseName);
            bool bIsExists = File.Exists(sDB);
            if (!bIsExists)
            {
                sqlDatabase = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                string sql = "CREATE TABLE IF NOT EXISTS Customers " +
                    "(_id INTEGER PRIMARY KEY AUTOINCREMENT,Nev VARCHAR,Email VARCHAR,Telefon VARCHAR);";
                sqlDatabase.ExecSQL(sql);
                AddRecords();
            }
            else
            {
                sqlDatabase = SQLiteDatabase.OpenDatabase(sDB, null, DatabaseOpenFlags.OpenReadwrite);
            }
        }

        public void AddRecord(string Nev, string Email, string Telefon)
        {
            string sql = "INSERT INTO " +
                "Customers " +
                "(Nev,Email,Telefon)" +
                "VALUES('" + Nev + "','" + Email + "','" + Telefon + "');";
            sqlDatabase.ExecSQL(sql);
        }

        public Android.Database.ICursor GetRecordCursor()
        {
            Android.Database.ICursor icTemp = null;
            string sql = "SELECT * FROM Customers;";
            icTemp = sqlDatabase.RawQuery(sql, null);
            return icTemp;
        }

        ~vtcDatabase()
        {
            sqlDatabase.Close();
        }

        private void AddRecords()
        {
            AddRecord("Kiss Andrea", "kiss.andrea@gmail.com", "(85) 510-121");
            AddRecord("Fehér Gyula", "fehergyula@hotmail.com", "(85) 313-477");
            AddRecord("Kovács Katalin", "katalin.kovacs@gmail.com", "(1) 123-456");
            AddRecord("Nagy Elemér", "nagy.elemer@freemail.hu", "(30) 2555-121");
            AddRecord("Osvald Csaba", "csaba.osvald@gmail.com", "(30) 844-7307");
            AddRecord("Osvald Béla", "bela.osvald@hotmail.com", "(30) 855-1122");
        }
	}
}

