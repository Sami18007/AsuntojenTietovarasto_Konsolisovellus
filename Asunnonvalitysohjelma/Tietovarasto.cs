using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Asunnonvalitysohjelma
{
    class Tietovarasto : Dictionary<string, Asunto>
    {
        StreamWriter fout;
        StreamReader fin;
        string osoite, palautus;
        bool poistettiin;
        bool muokattiin;
        bool loydettiin;
        int i;

        public Tietovarasto()
        {
            if (File.Exists("AutoSave.txt")) // jos "AutoSave.txt" tiedosto on olemassa tietovarastoa luotaessa, niin haetaan sen sisältämät tiedot ohjelmaan
            {
                string rivi = "";
                string[] jaettu = new string[12];
                fin = File.OpenText("AutoSave.txt");
                Asunto asunto;
                string katuosoite;
                string postinumero;
                string kunta;
                string os;
                string asuntotyyppi;
                string huoneistotyyppi;
                int pinta_ala;
                string rahoitustapa;
                double kustannus1;
                double kustannus2;
                string vapautuu;
                string status;
                string muutto;


                while (!fin.EndOfStream) // haetaan tiedoston sisältämät tiedot rivi riviltä tietovarastoon
                {
                    rivi = fin.ReadLine();
                    jaettu = rivi.Split(';');
                    katuosoite = jaettu[0];
                    postinumero = jaettu[1];
                    kunta = jaettu[2];
                    os = jaettu[0] + " " + jaettu[1] + " " + jaettu[2];
                    asuntotyyppi = jaettu[3];
                    huoneistotyyppi = jaettu[4];
                    int.TryParse(jaettu[5], out pinta_ala);
                    rahoitustapa = jaettu[6];
                    double.TryParse(jaettu[7], out kustannus1);
                    double.TryParse(jaettu[8], out kustannus2);
                    vapautuu = jaettu[9];
                    status = jaettu[10];
                    muutto = jaettu[11];

                    if (jaettu[3] == "omakotitalo")
                    {
                        asunto = new Omakotitalo(katuosoite, postinumero, kunta, asuntotyyppi, huoneistotyyppi, pinta_ala, rahoitustapa, kustannus1, kustannus2, vapautuu, status, muutto);
                    }
                    else if (jaettu[3] == "paritalohuoneisto")
                    {
                        asunto = new Paritalohuoneisto(katuosoite, postinumero, kunta, asuntotyyppi, huoneistotyyppi, pinta_ala, rahoitustapa, kustannus1, kustannus2, vapautuu, status, muutto);
                    }
                    else if (jaettu[3] == "rivitalohuoneisto")
                    {
                        asunto = new Rivitalohuoneisto(katuosoite, postinumero, kunta, asuntotyyppi, huoneistotyyppi, pinta_ala, rahoitustapa, kustannus1, kustannus2, vapautuu, status, muutto);
                    }
                    else
                    {
                        asunto = new Kerrostalohuoneisto(katuosoite, postinumero, kunta, asuntotyyppi, huoneistotyyppi, pinta_ala, rahoitustapa, kustannus1, kustannus2, vapautuu, status, muutto);
                    }

                    this.Add(os, asunto);
                }

                fin.Close();
            }
        }

        public void LisaaAsunto(Asunto asunto) // lisää yksi asunto tietovarastoon
        {
            osoite = asunto.Katuosoite + " " + asunto.Postinumero + " " + asunto.Kunta;
            Add(osoite, asunto);
            Console.WriteLine("Asunto lisättiin onnistuneesti...");
        }

        public bool PoistaAsunto(string[] hakutermi) // poista asunto osoitteen perusteella
        {
            poistettiin = false;
            osoite = hakutermi[0] + " " + hakutermi[1] + " " + hakutermi[2];

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                if (p.Key == osoite)
                {
                    Remove(osoite);
                    poistettiin = true;
                    break;
                }
                else { }
            }

            return poistettiin; // jos poistaminen onnistui, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public bool PoistaStatuksella(string maare) // poista asunto välitystilanteen perusteella
        {
            poistettiin = false;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                osoite = p.Value.Katuosoite + " " + p.Value.Postinumero + " " + p.Value.Kunta;

                if (p.Value.Status == maare)
                {
                    Remove(osoite);
                    poistettiin = true;
                    break;
                }
                else { }
            }

            return poistettiin; // jos poistaminen onnistui, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public void PoistaKaikkiAsunnot() // poista kaikki asunnot tietovarastosta
        {
            this.Clear();
        }

        public bool MuokkaaAsunnonRahoitustapaa(string[] hakutermi, string uusiarvo) // muokkaa asunnon rahoitustapaa
        {
            osoite = hakutermi[0] + " " + hakutermi[1] + " " + hakutermi[2];
            muokattiin = false;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                if (p.Key == osoite)
                {
                    if (uusiarvo == "omistusasunto")
                    {
                        p.Value.KysyMyytavanTiedot(); // jos asunnosta halutaan omistusasunto, niin kysytään uudet omistusasunnon kustannustiedot
                    }
                    else
                    {
                        p.Value.KysyVuokrattavanTiedot(); // jos asunnosta halutaan vuokra-asunto, niin kysytään uudet vuokra-asunnon kustannustiedot
                    }

                    muokattiin = true;
                    break;
                }
                else { }
            }

            return muokattiin; // jos muokkaus onnistui, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public bool MuokkaaAsunnonVapautumista(string[] hakutermi, string uusiarvo) // muokkaa asunnon vapautumisajankohtaa
        {
            osoite = hakutermi[0] + " " + hakutermi[1] + " " + hakutermi[2];
            muokattiin = false;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                if (p.Key == osoite)
                {
                    p.Value.Vapautuu = uusiarvo;
                    muokattiin = true;
                    break;
                }
                else { }
            }

            return muokattiin; // jos muokkaus onnistui, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public bool MuokkaaAsunnonStatusta(string[] hakutermi, string uusiarvo) // muokkaa asunnon välitystilannetta
        {
            osoite = hakutermi[0] + " " + hakutermi[1] + " " + hakutermi[2];
            muokattiin = false;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                if (p.Key == osoite)
                {
                    p.Value.Status = uusiarvo;
                    muokattiin = true;
                    break;
                }
                else { }
            }

            return muokattiin; // jos muokkaus onnistui, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public bool MuokkaaAsunnonMuuttoa(string[] hakutermi, string uusiarvo) // muokkaa asunnon muuttoajankohtaa
        {
            osoite = hakutermi[0] + " " + hakutermi[1] + " " + hakutermi[2];
            muokattiin = false;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                if (p.Key == osoite)
                {
                    p.Value.Muutto = uusiarvo;
                    muokattiin = true;
                    break;
                }
                else { }
            }

            return muokattiin; // jos muokkaus onnistui, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public bool MuokkaaAsunnonKustannuksia(string[] hakutermi) // muokkaa asunnon kustannustietoja
        {
            osoite = hakutermi[0] + " " + hakutermi[1] + " " + hakutermi[2];
            muokattiin = false;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                if (p.Key == osoite)
                {
                    if (p.Value.Rahoitustapa == "omistusasunto") // jos kyseessä on omistusasunto, niin kysytään sille uudet kustannukset muuttamatta rahoitustapaa
                    {
                        p.Value.KysyMyytavanTiedot();
                    }
                    else
                    {
                        p.Value.KysyVuokrattavanTiedot(); // jos kyseessä on vuokra-asunto, niin kysytään sille uudet kustannukset muuttamatta rahoitustapaa
                    }

                    muokattiin = true;
                    break;
                }
                else { }
            }

            return muokattiin; // jos muokkaus onnistui, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public bool HaeAsuntoaOsoitteella(string[] hakutermi) // hae asuntoa tietovarastosta
        {
            osoite = hakutermi[0] + " " + hakutermi[1] + " " + hakutermi[2];
            loydettiin = false;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                if (p.Key == osoite)
                {
                    loydettiin = true;
                    break;
                }
                else { }
            }

            return loydettiin; // jos hakutuloksia ei löydy, niin ilmoitetaan siitä program-tiedoston puolella
        }

        public string HaeAsuntoja(string[] hakutermi) //hae asuntoja erilaisin perustein
        {
            palautus = "";
            i = 1;

            if (hakutermi[1] == "Postinumero") // hae postinumeron perusteella
            {
                foreach (KeyValuePair<string, Asunto> p in this)
                {
                    if (p.Value.Postinumero == hakutermi[0])
                    {
                        palautus = palautus + i + ": " + "\t" + p.Value.ToString() + "\n";

                        i++;
                    }
                }
            }
            else if (hakutermi[1] == "Asunnon tyyppi") // hae asunnon tyypin perusteella
            {
                foreach (KeyValuePair<string, Asunto> p in this)
                {
                    if (p.Value.Asuntotyyppi == hakutermi[0])
                    {
                        palautus = palautus + i + ": " + "\t" + p.Value.ToString() + "\n";

                        i++;
                    }
                }
            }
            else if (hakutermi[1] == "Huoneiston tyyppi") // hae huoneiston tyypin perusteella
            {
                foreach (KeyValuePair<string, Asunto> p in this)
                {
                    if (p.Value.Huoneistotyyppi.Contains(hakutermi[0]))
                    {
                        palautus = palautus + i + ": " + "\t" + p.Value.ToString() + "\n";

                        i++;
                    }
                }
            }
            else if (hakutermi[1] == "Rahoitustapa") // hae rahoitustavan perusteella
            {
                foreach (KeyValuePair<string, Asunto> p in this)
                {
                    if (p.Value.Rahoitustapa == hakutermi[0])
                    {
                        palautus = palautus + i + ": " + "\t" + p.Value.ToString() + "\n";

                        i++;
                    }
                }
            }
            else if (hakutermi[1] == "Välitystilanne") // hae välitystilanteen perusteella
            {
                foreach (KeyValuePair<string, Asunto> p in this)
                {
                    if (p.Value.Status == hakutermi[0])
                    {
                        palautus = palautus + i + ": " + "\t" + p.Value.ToString() + "\n";

                        i++;
                    }
                }
            }
            else // hae kaikki asunnot tietovarastosta
            {
                foreach (KeyValuePair<string, Asunto> p in this)
                {
                    palautus = palautus + i + ": " + "\t" + p.Value.ToString() + "\n";

                    i++;
                }
            }

            if (palautus == "")
            {
                palautus = "Hakuehdolla ei löytynyt hakutuloksia...\n"; // jos hakutuloksia ei löytynyt, niin ilmoitetaan siitä programin puolella
            }

            return palautus;
        }

        public void Tallenna() // tallenna tietovarasto
        {
            fout = File.CreateText("AutoSave.txt");
            i = 0;

            foreach (KeyValuePair<string, Asunto> p in this)
            {
                fout.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}", p.Value.Katuosoite, p.Value.Postinumero, p.Value.Kunta, p.Value.Asuntotyyppi, p.Value.Huoneistotyyppi,
                    p.Value.Pinta_ala, p.Value.Rahoitustapa, p.Value.Kustannus1, p.Value.Kustannus2, p.Value.Vapautuu, p.Value.Status, p.Value.Muutto);
            }

            fout.Close();
        }
    }
}
