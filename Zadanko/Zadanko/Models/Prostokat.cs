namespace Zadanko.Models
{
    public class Prostokat
    {
        public int Id { get; set; }
        public int Wysokosc { get; set; }
        public int Szerokosc { get; set; }
        public JednostkaDlugosci Jednostka { get; set; }
        public double Powierzchnia { get; set; }
        public DateTime DataCzasUtworzenia { get; set; }
    }

    public enum JednostkaDlugosci
    {
        Milimetry,
        Centymetry,
        Metry
    }
}
