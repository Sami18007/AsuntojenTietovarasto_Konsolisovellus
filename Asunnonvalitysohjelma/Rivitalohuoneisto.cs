
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asunnonvalitysohjelma
{
    class Rivitalohuoneisto : Asunto
    {
        private int nro1;
        private double nro2;

        public Rivitalohuoneisto() { }

        public Rivitalohuoneisto(string Katuosoite, string Postinumero, string Kunta, string Asuntotyyppi, string Huoneistotyyppi, int Pinta_ala, string Rahoitustapa, double Kustannus1, double Kustannus2, string Vapautuu, string Status, string Muutto)
            : base(Katuosoite, Postinumero, Kunta, Asuntotyyppi, Huoneistotyyppi, Pinta_ala, Rahoitustapa, Kustannus1, Kustannus2, Vapautuu, Status, Muutto)
        { }

        public override void KysyTiedot() // kysytään asunnon perustiedot
        {
            Console.Write("Anna katuosoite: ");
            Katuosoite = Console.ReadLine();
            Console.Write("Anna postinumero: ");
            Postinumero = Console.ReadLine();
            Console.Write("Anna kunta: ");
            Kunta = Console.ReadLine();
            Asuntotyyppi = "rivitalohuoneisto";
            Console.Write("Anna huoneistotyyppi: ");
            Huoneistotyyppi = Console.ReadLine();
            Console.Write("Anna pinta-ala: ");
            int.TryParse(Console.ReadLine(), out nro1);
            Pinta_ala = nro1;
            Console.Write("Milloin vapautuu: ");
            Vapautuu = Console.ReadLine();
            Status = "esittelyssä";
            Muutto = "ei määritelty";
        }

        public override void KysyMyytavanTiedot() // määritetään asunto omistusasunnoksi
        {
            Rahoitustapa = "omistusasunto";
            Console.Write("Anna ostohinta: ");
            double.TryParse(Console.ReadLine(), out nro2);
            Kustannus1 = nro2;
            Console.Write("Anna vastike: ");
            double.TryParse(Console.ReadLine(), out nro2);
            Kustannus2 = nro2;
        }

        public override void KysyVuokrattavanTiedot() // määritetään asunto vuokra-asunnoksi
        {
            Rahoitustapa = "vuokra-asunto";
            Console.Write("Anna vuokraennakko: ");
            double.TryParse(Console.ReadLine(), out nro2);
            Kustannus1 = nro2;
            Console.Write("Anna kuukausivuokra: ");
            double.TryParse(Console.ReadLine(), out nro2);
            Kustannus2 = nro2;
        }

        public override string ToString()
        {
            if (Rahoitustapa == "omistusasunto") // tulostusmuoto, jos rahoitustapana on "omistusasunto"
            {
                return string.Format("Osoite: {0}, {1}, {2}; Asuntotyyppi: {3};\n\tHuoneistotyyppi: {4}; Pinta-ala: {5} m^2; Rahoitustapa: {6};\n\tKustannukset: ostohinta {7} euroa, vastike {8} euroa;\n\tVapautuu: {9}; Välitystilanne: {10}; Muutto: {11}",
                Katuosoite, Postinumero, Kunta, Asuntotyyppi, Huoneistotyyppi, Pinta_ala, Rahoitustapa, Kustannus1, Kustannus2, Vapautuu, Status, Muutto);
            }
            else // tulostusmuoto, jos rahoitustapana on "vuokra-asunto"
            {
                return string.Format("Osoite: {0}, {1}, {2}; Asuntotyyppi: {3};\n\tHuoneistotyyppi: {4}; Pinta-ala: {5} m^2; Rahoitustapa: {6};\n\tKustannukset: vuokraennakko {7} euroa, kuukausivuokra {8} euroa;\n\tVapautuu: {9}; Välitystilanne: {10}; Muutto: {11}",
                Katuosoite, Postinumero, Kunta, Asuntotyyppi, Huoneistotyyppi, Pinta_ala, Rahoitustapa, Kustannus1, Kustannus2, Vapautuu, Status, Muutto);
            }
        }
    }
}
