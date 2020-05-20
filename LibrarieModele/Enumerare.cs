using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarieModele
{

    public enum Optiuni
    {
        CutieAutomata = 1,
        AerConditionat = 2,
        Navigatie = 3,
        SenzoriParcare = 4,
        IncalzireScaune = 5,
        CruiseControl = 6,
    };
    public enum Culori
    {
        Culoare_Inexistenta = 0,
        Alb = 1,
        Negru = 2,
        Rosu = 3,
        Albastru =4,
        Galben =5,
        Verde=6,
    };

    public enum CampuriMasina
    {
        ID=0,
        NUME_VANZATOR=1,
        NUME_CUMPARATOR = 2,
        TIP = 3,
        AN_FABRICARE = 4,
        DATA_TRANZACTIE = 5,
        PRET = 6,
        OPTIUNI = 7,
        CULOARE = 8,
    }

}
