

using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace Animu.Model
{
    public class DebugTraceListener : ITraceListener
    {
        public void Receive(string message)
        {
            Debug.WriteLine(message);
        }
    }

    public class DBConnect
    {
        string path;
        SQLiteConnection conn;
        string path2;

        public DBConnect()
        {
            path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "DB", "aaa.db");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            path2 = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "wyniki.db");
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

        internal async void Insert(int punkciki, int maxPytan, int poprawneOdp)
        {
            conn.Close();
            using (var connection = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(path2, false)))
            {
               connection.TraceListener = new DebugTraceListener();
               var asyncConnection = new SQLiteAsyncConnection(() => { return connection; });
               await asyncConnection.CreateTableAsync<Wyniki>();
               await asyncConnection.InsertAsync(new Wyniki
               {
                   Punkty = punkciki,
                   IloscPytan = maxPytan,
                   PoprawneOdp = poprawneOdp
                });
            }
        }

        internal List<Wyniki> getWyniki()
        {
            using (var connection = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(path2, false)))
            {
                return connection.Table<Wyniki>().ToList();
            }
        }
    }
}
