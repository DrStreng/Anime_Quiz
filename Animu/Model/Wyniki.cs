using SQLite.Net.Attributes;

namespace Animu.Model
{
    internal class Wyniki
    {
        [PrimaryKey, AutoIncrement,Unique,NotNull]
        public int Id { get; set; }

        public int Punkty { get; set; }

        public int IloscPytan { get; set; }

        public int PoprawneOdp { get; set; }

    }
}