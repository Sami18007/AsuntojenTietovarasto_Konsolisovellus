using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asunnonvalitysohjelma
{
    class Program
    {
        public static void Main(string[] args)
        {
            Tietovarasto tietovarasto = new Tietovarasto();
            Asunto omakotitalo;
            Asunto paritalohuoneisto;
            Asunto rivitalohuoneisto;
            Asunto kerrostalohuoneisto;
            bool lopeta = false;
            bool takaisin = false;
            bool paavalikkoon = false;
            bool poistettiin;
            bool muokattiin;
            bool loydettiin;
            char valinta;
            string[] hakutermi = new string[3];
            string vastaanotto;

            while (!lopeta) // pääohjelmasilmukka
            {
                Console.Write("PÄÄVALIKKO (l = lisää, p = poista, m = muokkaa, h = hae, t = tallenna muutokset, s = sulje ohjelma)\nAnna valintasi: ");
                char.TryParse(Console.ReadLine(), out valinta);

                switch (valinta)
                {
                    case 'l': // lisää asunto
                        while (!paavalikkoon) // lisää-toiminnon ohjelmasilmukka
                        {
                            Console.Write(">LISÄÄ (o = omistusasunto, v = vuokra-asunto, t = takaisin)\nAnna valintasi: ");
                            char.TryParse(Console.ReadLine(), out valinta);
                            switch (valinta)
                            {
                                case 'o': // lisää omistusasunto
                                    while (!takaisin) // lisää omistusasunto -toiminnon ohjelmasilmukka
                                    {
                                        Console.Write(">>OMISTUSASUNTO (o = omakotitalo, p = paritalohuoneisto, r = rivitalohuoneisto, k = kerrostalohuoneisto, t = takaisin)\nAnna valintasi: ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'o': // lisää omakotitalo (omistusasunto)
                                                Console.WriteLine(">>>OMAKOTITALO");
                                                omakotitalo = new Omakotitalo();
                                                omakotitalo.KysyTiedot();
                                                omakotitalo.KysyMyytavanTiedot();
                                                tietovarasto.LisaaAsunto(omakotitalo);
                                                break;
                                            case 'p': // lisää paritalohuoneisto (omistusasunto)
                                                Console.WriteLine(">>>PARITALOHUONEISTO");
                                                paritalohuoneisto = new Paritalohuoneisto();
                                                paritalohuoneisto.KysyTiedot();
                                                paritalohuoneisto.KysyMyytavanTiedot();
                                                tietovarasto.LisaaAsunto(paritalohuoneisto);
                                                break;
                                            case 'r': // lisää rivitalohuoneisto (omistusasunto)
                                                Console.WriteLine(">>>RIVITALOHUONEISTO");
                                                rivitalohuoneisto = new Rivitalohuoneisto();
                                                rivitalohuoneisto.KysyTiedot();
                                                rivitalohuoneisto.KysyMyytavanTiedot();
                                                tietovarasto.LisaaAsunto(rivitalohuoneisto);
                                                break;
                                            case 'k': // lisää kerrostalohuoneisto (omistusasunto)
                                                Console.WriteLine(">>>KERROSTALOHUONEISTO");
                                                kerrostalohuoneisto = new Kerrostalohuoneisto();
                                                kerrostalohuoneisto.KysyTiedot();
                                                kerrostalohuoneisto.KysyMyytavanTiedot();
                                                tietovarasto.LisaaAsunto(kerrostalohuoneisto);
                                                break;
                                            case 't': // mene takaisin lisää-toiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 'v': // lisää vuokra-asunto
                                    while (!takaisin) // lisää vuokra-asunto -toiminnon ohjelmasilmukka
                                    {
                                        Console.Write(">>VUOKRA-ASUNTO (o = omakotitalo, p = paritalohuoneisto, r = rivitalohuoneisto, k = kerrostalohuoneisto, t = takaisin)\nAnna valintasi: ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'o': // lisää omakotitalo (vuokra-asunto)
                                                Console.WriteLine(">>>OMAKOTITALO");
                                                omakotitalo = new Omakotitalo();
                                                omakotitalo.KysyTiedot();
                                                omakotitalo.KysyVuokrattavanTiedot();
                                                tietovarasto.LisaaAsunto(omakotitalo);
                                                break;
                                            case 'p': // lisää paritalohuoneisto (vuokra-asunto)
                                                Console.WriteLine(">>>PARITALOHUONEISTO");
                                                paritalohuoneisto = new Paritalohuoneisto();
                                                paritalohuoneisto.KysyTiedot();
                                                paritalohuoneisto.KysyVuokrattavanTiedot();
                                                tietovarasto.LisaaAsunto(paritalohuoneisto);
                                                break;
                                            case 'r': // lisää rivitalohuoneisto (vuokra-asunto)
                                                Console.WriteLine(">>>RIVITALOHUONEISTO");
                                                rivitalohuoneisto = new Rivitalohuoneisto();
                                                rivitalohuoneisto.KysyTiedot();
                                                rivitalohuoneisto.KysyVuokrattavanTiedot();
                                                tietovarasto.LisaaAsunto(rivitalohuoneisto);
                                                break;
                                            case 'k': // lisää kerrostalohuoneisto (vuokra-asunto)
                                                Console.WriteLine(">>>KERROSTALOHUONEISTO");
                                                kerrostalohuoneisto = new Kerrostalohuoneisto();
                                                kerrostalohuoneisto.KysyTiedot();
                                                kerrostalohuoneisto.KysyVuokrattavanTiedot();
                                                tietovarasto.LisaaAsunto(kerrostalohuoneisto);
                                                break;
                                            case 't': // mene takaisin lisää-toiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 't': // mene takaisin päävalikkoon
                                    paavalikkoon = true;
                                    break;
                            }

                            takaisin = false;
                        } // lisää-toiminto päättyy
                        break;
                    case 'p': // poista asuntoja
                        while (!paavalikkoon) // poista-toiminnon ohjelmasilmukka
                        {
                            Console.Write(">POISTA (o = osoitteella, v = välitystilanteella, k = kaikki, t = takaisin)\nAnna valintasi: ");
                            char.TryParse(Console.ReadLine(), out valinta);

                            switch (valinta)
                            {
                                case 'o': // poista osoitteen perusteella (poistetaan yksi kerrallaan)
                                    Console.Write("Katuosoite: ");
                                    hakutermi[0] = Console.ReadLine();
                                    Console.Write("Postinumero: ");
                                    hakutermi[1] = Console.ReadLine();
                                    Console.Write("Kunta: ");
                                    hakutermi[2] = Console.ReadLine();
                                    poistettiin = tietovarasto.PoistaAsunto(hakutermi);

                                    if (poistettiin == true)
                                    {
                                        Console.WriteLine("Asunto poistettiin onnistuneesti...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Asuntoa ei löytynyt...");
                                    }
                                    break;
                                case 'v': // poista välitystilanteen perusteella (voidaan poistaa yksi tai useampia kerralla)
                                    while (!takaisin) // poista välitystilanteella -toiminnon ohjelmasilmukka (tarkennetaan määritelmää)
                                    {
                                        Console.Write(">>VÄLITYSTILANTEELLA (p = peruutetut, v = valmiit, t = takaisin)\nAnna valintasi: ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'p': // poista asunnot, joiden välitystilanne on "peruutettu"
                                                poistettiin = true;
                                                while (poistettiin)
                                                {
                                                    poistettiin = tietovarasto.PoistaStatuksella("peruutettu");
                                                }
                                                Console.WriteLine("Kaikki välitystilanteeltaan perutut poistettiin onnistuneesti...");
                                                break;
                                            case 'v': // poista asunnot, joiden välitystilanne on "valmis"
                                                poistettiin = true;
                                                while (poistettiin)
                                                {
                                                    poistettiin = tietovarasto.PoistaStatuksella("valmis");
                                                }
                                                Console.WriteLine("Kaikki välitystilanteeltaan valmiit poistettiin onnistuneesti...");
                                                break;
                                            case 't': // mene takaisin poista-toiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 'k': // poista kaikki asunnot tietovarastosta
                                    while (!takaisin) // poista kaikki -toiminnon ohjelmasilmukka (varmista poisto)
                                    {
                                        Console.Write("Oletko varma, että haluat poistaa kaikkien asuntojen tiedot? (k = kyllä, e = ei)\nAnna valintasi: ");
                                        char.TryParse(Console.ReadLine(), out valinta);
                                        switch (valinta)
                                        {
                                            case 'k': // poista kaikki
                                                tietovarasto.PoistaKaikkiAsunnot();
                                                Console.WriteLine("Kaikki asunnot poistettiin onnistuneesti...");
                                                takaisin = true;
                                                break;
                                            case 'e': // en haluakaan poistaa mitään
                                                Console.WriteLine("Asuntojen poistaminen peruutettu...");
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 't': // mene takaisin päävalikkoon
                                    paavalikkoon = true;
                                    break;
                            }

                            takaisin = false;
                        } // poista-toiminto päättyy
                        break;
                    case 'm': // muokkaa asunnon tietoja
                        Console.WriteLine(">MUOKKAA\nAnna muokattavan asunnon osoite: "); // määritetään, mitä asuntoa halutaan muokata
                        Console.Write("Katuosoite: ");
                        hakutermi[0] = Console.ReadLine();
                        Console.Write("Postinumero: ");
                        hakutermi[1] = Console.ReadLine();
                        Console.Write("Kunta: ");
                        hakutermi[2] = Console.ReadLine();

                        loydettiin = tietovarasto.HaeAsuntoaOsoitteella(hakutermi);

                        if (!loydettiin)
                        {
                            Console.WriteLine("Osoitetta ei löytynyt...");
                        }

                        while (!paavalikkoon && loydettiin) // muokkaa-toiminnon ohjelmasilmukka (asunto pysyy valittuna, kunnes käydään taas päävalikossa)
                        {
                            Console.Write(">>{0} {1} {2} (r = rahoitustapaa, k = kustannuksia, v = vapautumisajankohtaa, s = välitystilannetta, m = muuton ajankohtaa, t = takaisin)\nAnna valintasi: ", hakutermi[0], hakutermi[1], hakutermi[2]);
                            char.TryParse(Console.ReadLine(), out valinta);

                            switch (valinta)
                            {
                                case 'r': // muokkaa asunnon rahoitustapaa
                                    while (!takaisin) // muokkaa rahoitustapaa -toiminnon ohjelmasilmukka
                                    {
                                        Console.Write("Anna uusi rahoitustapa (o = omistusasunto, v = vuokra-asunto, t = takaisin): ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'o': // valitaan rahoitustavaksi omistusasunto
                                                vastaanotto = "omistusasunto";
                                                muokattiin = tietovarasto.MuokkaaAsunnonRahoitustapaa(hakutermi, vastaanotto);
                                                if (muokattiin)
                                                {
                                                    Console.WriteLine("Asunnon rahoitustapaa muokattiin onnistuneesti...");
                                                    takaisin = true;
                                                }
                                                break;
                                            case 'v': // valitaan rahoitustavaksi vuokra-asunto
                                                vastaanotto = "vuokra-asunto";
                                                muokattiin = tietovarasto.MuokkaaAsunnonRahoitustapaa(hakutermi, vastaanotto);
                                                if (muokattiin)
                                                {
                                                    Console.WriteLine("Asunnon rahoitustapaa muokattiin onnistuneesti...");
                                                    takaisin = true;
                                                }
                                                break;
                                            case 't': // takaisin muokkaa-toiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 'k': // muokkaa asunnon kustannuksia
                                    Console.WriteLine("Anna uudet kustannukset: ");
                                    muokattiin = tietovarasto.MuokkaaAsunnonKustannuksia(hakutermi);
                                    if (muokattiin)
                                    {
                                        Console.WriteLine("Asunnon kustannuksia muokattiin onnistuneesti...");
                                    }
                                    break;
                                case 'v': // muokkaa asunnon vapautumisajankohtaa
                                    Console.Write("Anna uusi vapautumisajankohta: ");
                                    vastaanotto = Console.ReadLine();
                                    muokattiin = tietovarasto.MuokkaaAsunnonVapautumista(hakutermi, vastaanotto);
                                    if (muokattiin)
                                    {
                                        Console.WriteLine("Asunnon vapautumisajankohtaa muokattiin onnistuneesti...");
                                    }
                                    break;
                                case 's': // muokkaa asunnon välitystilannetta
                                    while (!takaisin) // muokkaa välitystilannetta -toiminnon ohjelmasilmukka
                                    {
                                        Console.Write("Anna uusi välitystilanne (e = esittelyssä, v = varattu, p = peruutettu, s = valmis, t = takaisin): ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'e': // valitaan välitystilanteeksi "esittelyssä" ja määritetään muuton ajankohdaksi "ei määritetty"
                                                vastaanotto = "esittelyssä";
                                                muokattiin = tietovarasto.MuokkaaAsunnonStatusta(hakutermi, vastaanotto);
                                                tietovarasto.MuokkaaAsunnonMuuttoa(hakutermi, "ei määritetty");
                                                if (muokattiin)
                                                {
                                                    Console.WriteLine("Asunnon välitystilannetta muokattiin onnistuneesti...");
                                                    takaisin = true;
                                                }
                                                break;
                                            case 'v': // valitaan välitystilanteeksi "varattu" ja kysytään muuton ajankohta
                                                vastaanotto = "varattu";
                                                muokattiin = tietovarasto.MuokkaaAsunnonStatusta(hakutermi, vastaanotto);
                                                Console.Write("Anna muuton ajankohta: ");
                                                tietovarasto.MuokkaaAsunnonMuuttoa(hakutermi, Console.ReadLine());
                                                if (muokattiin)
                                                {
                                                    Console.WriteLine("Asunnon välitystilannetta muokattiin onnistuneesti...");
                                                    takaisin = true;
                                                }
                                                break;
                                            case 'p': // valitaan välitystilanteeksi "peruutettu" ja määritetään muuton ajankohdaksi "ei määritetty"
                                                vastaanotto = "peruutettu";
                                                muokattiin = tietovarasto.MuokkaaAsunnonStatusta(hakutermi, vastaanotto);
                                                tietovarasto.MuokkaaAsunnonMuuttoa(hakutermi, "ei määritetty");
                                                if (muokattiin)
                                                {
                                                    Console.WriteLine("Asunnon välitystilannetta muokattiin onnistuneesti...");
                                                    takaisin = true;
                                                }
                                                break;
                                            case 's': // valitaan välitystilanteeksi "valmis"
                                                vastaanotto = "valmis";
                                                muokattiin = tietovarasto.MuokkaaAsunnonStatusta(hakutermi, vastaanotto);
                                                if (muokattiin)
                                                {
                                                    Console.WriteLine("Asunnon välitystilannetta muokattiin onnistuneesti...");
                                                    takaisin = true;
                                                }
                                                break;
                                            case 't': // mene takaisin muokkaa-toiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 'm': // muokkaa asunnon muuttoajankohtaa
                                    Console.Write("Anna uusi muuttoajankohta: ");
                                    vastaanotto = Console.ReadLine();
                                    muokattiin = tietovarasto.MuokkaaAsunnonMuuttoa(hakutermi, vastaanotto);
                                    if (muokattiin)
                                    {
                                        Console.WriteLine("Asunnon muuttoajankohtaa muokattiin onnistuneesti...");
                                    }
                                    break;
                                case 't': // mene takaisin päävalikkoon
                                    paavalikkoon = true;
                                    break;
                            }

                            takaisin = false;
                        } // muokkaa toiminto päättyy
                        break;
                    case 'h': // hae asuntoja
                        while (!paavalikkoon) // hae asuntoja -toiminnon ohjelmasilmukka
                        {
                            Console.Write(">HAE (k = kaikki, p = postinumerolla, a = asunnon tyypillä, h = huoneiston tyypillä, r = rahoitustavalla, s = välitystilanteella, t = takaisin)\nAnna valintasi: ");
                            char.TryParse(Console.ReadLine(), out valinta);

                            switch (valinta)
                            {
                                case 'k': // hae kaikki asunnot
                                    Console.WriteLine(">>KAIKKI");
                                    hakutermi[1] = "Kaikki";
                                    vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                    Console.Write(vastaanotto);
                                    break;
                                case 'p': // hae asuntoja postinumeron perusteella (kaikki asunnot, joilla on sama postinumero)
                                    Console.WriteLine(">>POSTINUMEROLLA");
                                    Console.Write("Anna asunnon postinumero: ");
                                    hakutermi[0] = Console.ReadLine(); // kysytään postinumero, jolla haetaan asuntoja
                                    hakutermi[1] = "Postinumero"; // tarpeellinen määritys, jotta metodin sisällä tiedetään millä perusteella asuntoja haetaan
                                    vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                    Console.Write(vastaanotto);
                                    break;
                                case 'a': // hae asuntoja asuntotyypillä
                                    while (!takaisin) // hae asuntotyypillä -toiminnon ohjelmasilmukka
                                    {
                                        Console.Write(">>ASUNTOTYYPILLÄ (o = omakotitalo, p = paritalohuoneisto, r = rivitalohuoneisto, k = kerrostalohuoneisto, t = takaisin)\nAnna valintasi: ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'o': // hae omakotitalot
                                                hakutermi[0] = "omakotitalo";
                                                hakutermi[1] = "Asunnon tyyppi";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 'p': // hae paritalohuoneistot
                                                hakutermi[0] = "paritalohuoneisto";
                                                hakutermi[1] = "Asunnon tyyppi";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 'r': // hae rivitalohuoneistot
                                                hakutermi[0] = "rivitalohuoneisto";
                                                hakutermi[1] = "Asunnon tyyppi";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 'k': // hae kerrostalohuoneistot
                                                hakutermi[0] = "kerrostalohuoneisto";
                                                hakutermi[1] = "Asunnon tyyppi";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 't': // mene takaisin hakutoiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 'h': // hae asuntoja huoneistotyypillä
                                    Console.WriteLine(">>HUONEISTOTYYPILLÄ");
                                    Console.Write("Anna huoneiston tyyppi: ");
                                    hakutermi[0] = Console.ReadLine();
                                    hakutermi[1] = "Huoneiston tyyppi";
                                    vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                    Console.Write(vastaanotto);
                                    break;
                                case 'r': // hae asuntoja rahoitustavan perusteella
                                    while (!takaisin) // hae rahoitustavalla -toiminnon ohjelmasilmukka
                                    {
                                        Console.Write(">>RAHOITUSTAVALLA (o = omistusasunto, v = vuokra-asunto, t = takaisin)\nAnna valintasi: ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'o': // hae omistusasunnot
                                                hakutermi[0] = "omistusasunto";
                                                hakutermi[1] = "Rahoitustapa";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 'v': // hae vuokra-asunnot
                                                hakutermi[0] = "vuokra-asunto";
                                                hakutermi[1] = "Rahoitustapa";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 't': // mene takaisin hakutoiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 's': // hae asuntoja välitystilanteen perusteella
                                    while (!takaisin) // hae välitystilanteella -toiminnon ohjelmasilmukka
                                    {
                                        Console.Write(">>VÄLITYSTILANTEELLA (e = esittelyssä, v = varattu, p = peruutettu, s = valmis, t = takaisin)\nAnna valintasi: ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'e': // hae asuntoja, joiden välitystilanne on "esittelyssä"
                                                hakutermi[0] = "esittelyssä";
                                                hakutermi[1] = "Välitystilanne";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 'v': // hae asuntoja, joiden välitystilanne on "varattu"
                                                hakutermi[0] = "varattu";
                                                hakutermi[1] = "Välitystilanne";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 'p': // hae asuntoja, joiden välitystilanne on "peruutettu"
                                                hakutermi[0] = "peruutettu";
                                                hakutermi[1] = "Välitystilanne";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 's': // hae asuntoja, joiden välitystilanne on "valmis"
                                                hakutermi[0] = "valmis";
                                                hakutermi[1] = "Välitystilanne";
                                                vastaanotto = tietovarasto.HaeAsuntoja(hakutermi);
                                                Console.Write(vastaanotto);
                                                break;
                                            case 't': // mene takaisin hakutoiminnon alkuun
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 't': // mene takaisin päävalikkoon
                                    paavalikkoon = true;
                                    break;
                            }

                            takaisin = false;
                        } // hae-toiminto päättyy
                        break;
                    case 't': // tallenna tietovarasto
                        while (!paavalikkoon) // tallenna toiminnon ohjelmasilmukka
                        {
                            Console.Write(">TALLENNA (k = kyllä, e = ei)\nHaluatko varmasti tallentaa muutokset? ");
                            char.TryParse(Console.ReadLine(), out valinta);

                            switch (valinta)
                            {
                                case 'k': // tallenna
                                    tietovarasto.Tallenna();
                                    Console.WriteLine("Muutokset tallennettu onnistuneesti...");
                                    paavalikkoon = true;
                                    break;
                                case 'e': // en tallennakaan
                                    paavalikkoon = true;
                                    Console.WriteLine("Muutoksia ei tallennettu...");
                                    break;
                            }
                        } // tallenna-toiminto päättyy
                        break;
                    case 's': // sulje ohjelma
                        while (!lopeta) // sulje-toiminnon ohjelmasilmukka (kysytään, haluatko tallentaa ennen sulkemista)
                        {
                            Console.Write(">SULJE (t = tallenna muutokset ja sulje, s = sulje tallentamatta)\nHaluatko tallentaa muutokset ennen ohjelman sulkemista? ");
                            char.TryParse(Console.ReadLine(), out valinta);

                            switch (valinta)
                            {
                                case 't': // tallenna tietovarasto ja sulje ohjelma
                                    tietovarasto.Tallenna();
                                    lopeta = true;
                                    break;
                                case 's': // en halua tallentaa tietovarastoa ennen sulkemista
                                    while (!lopeta && !takaisin) // sulje tallentamatta -toiminnon ohjelmasilmukka (varmistetaan valinta)
                                    {
                                        Console.Write(">>SULJE TALLENTAMATTA (k = kyllä, e = ei)\nOletko aivan varma, että haluat sulkea ohjelman tallentamatta muutoksia? ");
                                        char.TryParse(Console.ReadLine(), out valinta);

                                        switch (valinta)
                                        {
                                            case 'k': // lopeta tallentamatta
                                                lopeta = true;
                                                break;
                                            case 'e': // haluan sittenkin vaihtaa valintaani
                                                takaisin = true;
                                                break;
                                        }
                                    }
                                    break;
                            }

                            takaisin = false;
                        } // sulje-toiminto päättyy
                        break;
                }

                paavalikkoon = false;
            } // pääohjelmasilmukka päättyy
        }
    }
}
