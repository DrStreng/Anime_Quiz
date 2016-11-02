

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

        public DBConnect()
        {
            path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "DB", "aaa.db");
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



        internal void Insert(int punkciki, int maxPytan, int poprawneOdp)
        {
            //  conn.Close();

            //// string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "ciota.db");

            //using (var connection = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(path, false)))
            // {
            //     connection.TraceListener = new DebugTraceListener();
            //     var asyncConnection = new SQLiteAsyncConnection(() => { return connection; });

            // //  await asyncConnection.CreateTableAsync<Wyniki>();
            //  await asyncConnection.InsertAsync(new Wyniki
            //    {
            //         Punkty = punkciki,
            //         IloscPytan = maxPytan,
            //         PoprawneOdp = poprawneOdp
            //      });
            //       //var wniki = await asyncConnection.Table<Wyniki>().ToListAsync();
            //   }
            try
            {
                var s = new Wyniki()
                {
                    Punkty = punkciki,
                    IloscPytan = maxPytan,
                    PoprawneOdp = poprawneOdp
                };
                conn.Insert(s);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Wystąpił Error " + ex.Message);
            }
          
        }

        internal List<Wyniki> getWyniki()
        {
            return conn.Table<Wyniki>().ToList();
        }


    }
}
