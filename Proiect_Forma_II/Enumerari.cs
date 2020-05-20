using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Forma_II
{
    [Flags]
    public enum CodEroare
    {
        CORECT = 0,
        NUMEVANZATOR_INCORECT = 1,
        NUMECUMPARATOR_INCORECT = 2,
        TIP_INCORECTE = 3,
        ANFABRICARE_INCORECT = 4,
        DATATRANZACTIE_INCORECT = 5,
        PRET_INCORECTE = 6,
        OPTIUNE_INCORECT = 7,
        CULOARE_INCORECT = 8,
    }
}
