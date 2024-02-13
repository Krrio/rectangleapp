using Zadanko.Models;

namespace Zadanko.Services
{
    public class ProstokatSerwis
    {
        private readonly List<Prostokat> _prostokaty = new List<Prostokat>();

        public void DodajProstokat(Prostokat prostokat)
        {
            // Walidacja danych
            if (prostokat.Wysokosc <= 0 || prostokat.Wysokosc > 1000000)
            {
                throw new ArgumentException("Wysokość musi być dodatnią liczbą całkowitą mniejszą niż 1 000 000.");
            }

            if (prostokat.Szerokosc <= 0 || prostokat.Szerokosc > 1000000)
            {
                throw new ArgumentException("Szerokość musi być dodatnią liczbą całkowitą mniejszą niż 1 000 000.");
            }

            prostokat.Powierzchnia = ObliczPowierzchnie(prostokat.Wysokosc, prostokat.Szerokosc, prostokat.Jednostka);
            prostokat.DataCzasUtworzenia = DateTime.UtcNow;

            _prostokaty.Add(prostokat);
        }

        public List<Prostokat> PobierzListeProstokatow()
        {
            return _prostokaty;
        }

        public Prostokat PobierzProstokat(int id)
        {
            return _prostokaty.FirstOrDefault(x => x.Id == id);
        }

        private double ObliczPowierzchnie(int wysokosc, int szerokosc, JednostkaDlugosci jednostka)
        {
            switch (jednostka)
            {
                case JednostkaDlugosci.Milimetry:
                    return (wysokosc * szerokosc) / 1000000.0;
                case JednostkaDlugosci.Centymetry:
                    return (wysokosc * szerokosc) / 10000.0;
                case JednostkaDlugosci.Metry:
                    return wysokosc * szerokosc;
                default:
                    throw new ArgumentException("Nieznana jednostka długości.");
            }
        }
    }
}
