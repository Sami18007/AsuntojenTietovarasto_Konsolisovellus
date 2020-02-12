using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asunnonvalitysohjelma
{
    abstract class Asunto : IMyytava, IVuokrattava
    {
        public string Katuosoite { get; set; }
        public string Postinumero { get; set; }
        public string Kunta { get; set; }
        public string Asuntotyyppi { get; set; }
        public string Huoneistotyyppi { get; set; }
        public int Pinta_ala { get; set; }
        public string Rahoitustapa { get; set; }
        public double Kustannus1 { get; set; }
        public double Kustannus2 { get; set; }
        public string Vapautuu { get; set; }
        public string Status { get; set; }
        public string Muutto { get; set; }

        public Asunto() { }

        public Asunto(string Katuosoite, string Postinumero, string Kunta, string Asuntotyyppi, string Huoneistotyyppi, int Pinta_ala, string Rahoitustapa, double Kustannus1, double Kustannus2, string Vapautuu, string Status, string Muutto)
        {
            this.Katuosoite = Katuosoite;
            this.Postinumero = Postinumero;
            this.Kunta = Kunta;
            this.Asuntotyyppi = Asuntotyyppi;
            this.Huoneistotyyppi = Huoneistotyyppi;
            this.Pinta_ala = Pinta_ala;
            this.Rahoitustapa = Rahoitustapa;
            this.Kustannus1 = Kustannus1;
            this.Kustannus2 = Kustannus2;
            this.Vapautuu = Vapautuu;
            this.Status = Status;
            this.Muutto = Muutto;
        }

        public abstract void KysyTiedot();

        public abstract void KysyMyytavanTiedot();

        public abstract void KysyVuokrattavanTiedot();

        public abstract override string ToString();
    }
}
