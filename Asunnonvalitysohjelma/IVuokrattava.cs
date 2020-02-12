using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asunnonvalitysohjelma
{
    interface IVuokrattava
    {
        void KysyTiedot();
        void KysyVuokrattavanTiedot();
        string ToString();
    }
}
