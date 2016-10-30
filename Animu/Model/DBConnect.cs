using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Animu.Model
{
    public class DBConnect
    {
        string path;
        SQLiteConnection conn;

        public DBConnect()
        {
            path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "DB", "Animu.db");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        internal List<Pytanka> getEasy()
        {
            var data = conn.Table<Pytanka>().Take(10);
            return data.ToList();
        }

        internal List<Pytanka> getMedium()
        {
            var data = conn.Table<Pytanka>().Take(20);
            return data.ToList();
        }
        internal List<Pytanka> getHard()
        {
            var data = conn.Table<Pytanka>().Take(30);
            return data.ToList();
        }
        internal List<Pytanka> getVeryHard()
        {
            var data = conn.Table<Pytanka>().Take(40);
            return data.ToList();
        }

        public int wprowadzWynik(int punkty, int iloscPytan)
        {
            return conn.Insert(new Wyniki() {
                Punkty = punkty,
                IloscPytan = iloscPytan
            });
        }

        internal List<Wyniki> getWyniki()
        {
            return conn.Table<Wyniki>().ToList();
        }


    }
}
