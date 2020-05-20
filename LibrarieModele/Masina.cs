using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Masina
    {
        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        /*private const int ID = 0;
        private const int NUMEVANZATOR = 1;
        private const int NUMECUMPARATOR = 2;
        private const int TIP = 3;
        private const int ANFABRICARE = 4;
        private const int DATATRANZACTIE = 5;
        private const int PRET = 6;
        private const int OPTIUNI = 7;
        private const int CULOARE = 8;*/

        public ArrayList ProgramOptiuni { get; set; }
        public Culori ProgramCulori { get; set; }

        public static int IdUltimaMasina { get; set; } = 0;
        public int IdMasina { get; set; }
        public string NumeVanzator { get; set; }
        public string NumeCumparator { get; set; }
        public string Tip { get; set; }
        public string AnFabricare { get; set; }
        public string DataTranzactie { get; set; }
        public string Pret { get; set; }
        /*public string Optiune { get; set; }
        public string Culoare { get; set; }*/

        public string OptiuneAsString
        {
            get
            {
                string sOptiune = string.Empty;

                foreach (string optiune in ProgramOptiuni)
                {
                    if (sOptiune != string.Empty)
                    {
                        sOptiune += SEPARATOR_SECUNDAR_FISIER;
                    }
                    sOptiune += optiune;
                }

                return sOptiune;
            }
        }

        /*public Masina()
        {
            NumeVanzator = NumeCumparator = Tip = AnFabricare = DataTranzactie = Pret = string.Empty;
            ProgramOptiuni = Optiuni.AerConditionat;
            ProgramCulori = Culori.Alb;
            IdUltimaMasina++;
            IdMasina = IdUltimaMasina;
        }
        public Masina()
        {
            NumeVanzator = NumeCumparator = Tip = AnFabricare = DataTranzactie = Pret = Optiune = Culoare = string.Empty;
            IdUltimaMasina++;
            IdMasina = IdUltimaMasina;
        }*/

        public Masina(string _NumeVanzator, string _NumeCumparator, string _Tip, string _AnFabricare, string _DataTranzactie, string _Pret)
        {
            NumeVanzator = _NumeVanzator;
            NumeCumparator = _NumeCumparator;
            Tip = _Tip;
            AnFabricare = _AnFabricare;
            DataTranzactie = _DataTranzactie;
            Pret = _Pret;
        }
        /*public Masina(string _NumeVanzator, string _NumeCumparator, string _Tip, string _AnFabricare, string _DataTranzactie, string _Pret, Optiuni _obtiune, Culori _culoare)
        {
            NumeVanzator = _NumeVanzator;
            NumeCumparator = _NumeCumparator;
            Tip = _Tip;
            AnFabricare = _AnFabricare;
            DataTranzactie = _DataTranzactie;
            Pret = _Pret;
            ProgramOptiuni = _obtiune;
            ProgramCulori = _culoare;
            IdUltimaMasina++;
            IdMasina = IdUltimaMasina;
        }
        public Masina(string _NumeVanzator, string _NumeCumparator, string _Tip, string _AnFabricare, string _DataTranzactie, string _Pret, string _Optiune, string _Culoare)
        {
            NumeVanzator = _NumeVanzator;
            NumeCumparator = _NumeCumparator;
            Tip = _Tip;
            AnFabricare = _AnFabricare;
            DataTranzactie = _DataTranzactie;
            Pret = _Pret;
            Optiune = _Optiune;
            Culoare = _Culoare;
            IdUltimaMasina++;
            IdMasina = IdUltimaMasina;
        }
        public Masina(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            IdMasina = Convert.ToInt32(dateFisier[ID]);
            NumeVanzator = dateFisier[NUMEVANZATOR];
            NumeCumparator = dateFisier[NUMECUMPARATOR];
            Tip = dateFisier[TIP];
            AnFabricare = dateFisier[ANFABRICARE];
            DataTranzactie = dateFisier[DATATRANZACTIE];
            Pret = dateFisier[PRET];
            ProgramOptiuni = (Optiuni)Enum.Parse(typeof(Optiuni), dateFisier[OPTIUNI]);
            ProgramCulori = (Culori)Enum.Parse(typeof(Culori), dateFisier[CULOARE]);
            IdUltimaMasina = IdMasina;
        }*/
        public Masina(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            IdMasina = Convert.ToInt32(dateFisier[(int)CampuriMasina.ID]);
            NumeVanzator = dateFisier[(int)CampuriMasina.NUME_VANZATOR];
            NumeCumparator = dateFisier[(int)CampuriMasina.NUME_CUMPARATOR];
            Tip = dateFisier[(int)CampuriMasina.TIP];
            AnFabricare = dateFisier[(int)CampuriMasina.AN_FABRICARE];
            DataTranzactie = dateFisier[(int)CampuriMasina.DATA_TRANZACTIE];
            Pret = dateFisier[(int)CampuriMasina.PRET];
            ProgramOptiuni = new ArrayList();
            ProgramOptiuni.AddRange(dateFisier[(int)CampuriMasina.OPTIUNI].Split(SEPARATOR_SECUNDAR_FISIER));
            ProgramCulori = (Culori)Enum.Parse(typeof(Culori), dateFisier[(int)CampuriMasina.CULOARE]);
        }
        public string ConversieLaSir()
        {
            string s = string.Format("Masina cu ID: #{0} a fost vandute de {1} lui {2} si are detaliile:\n -{3}\n-{4}\n-{5}\n-{6}\n-{7}\n-{8}\n", IdMasina, (NumeVanzator ?? " NECUNOSCUT"), (NumeCumparator ?? " NECUNOSCUT"), (Tip ?? " NECUNOSCUT"), (AnFabricare ?? " NECUNOSCUT"), (DataTranzactie ?? " NECUNOSCUT"), (Pret ?? " NECUNOSCUT"), ProgramOptiuni, ProgramCulori);
            return s;
        }
        public string ConversieLaSir_PentruForma()
        {
            string s = string.Format("Masina cu ID: #{0} a fost vandute de {1} lui {2} si are detaliile:\n -{3}\n-{4}\n-{5}\n-{6}\n-{7}\n-{8}\n", IdMasina, (NumeVanzator ?? " NECUNOSCUT"), (NumeCumparator ?? " NECUNOSCUT"), (Tip ?? " NECUNOSCUT"), (AnFabricare ?? " NECUNOSCUT"), (DataTranzactie ?? " NECUNOSCUT"), (Pret ?? " NECUNOSCUT"), OptiuneAsString,ProgramCulori);
            return s;
        }
        public static string ComparaDouaMasini(Masina a, Masina b)
        {

            if (a.Tip == b.Tip && a.Pret == b.Pret && a.AnFabricare == b.AnFabricare && a.ProgramCulori == b.ProgramCulori && a.ProgramOptiuni == b.ProgramOptiuni)
            {
                return string.Format("Masinile sunt identice");
            }
            else
                return string.Format("Masinile sunt diferite");
        }

        public string ConversiaLaSir_PentruFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}",
                SEPARATOR_PRINCIPAL_FISIER, IdMasina.ToString(), (NumeVanzator ?? " NECUNOSCUT"), (NumeCumparator ?? " NECUNOSCUT"), (Tip ?? " NECUNOSCUT"), (AnFabricare ?? " NECUNOSCUT"), (DataTranzactie ?? " NECUNOSCUT"), (Pret ?? " NECUNOSCUT"), ProgramOptiuni, ProgramCulori);
            return s;
        }
        public string ConversiaLaSir_PentruFisier_PentruForma()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}",
                SEPARATOR_PRINCIPAL_FISIER, IdMasina.ToString(), (NumeVanzator ?? " NECUNOSCUT"), (NumeCumparator ?? " NECUNOSCUT"), (Tip ?? " NECUNOSCUT"), (AnFabricare ?? " NECUNOSCUT"), (DataTranzactie ?? " NECUNOSCUT"), (Pret ?? " NECUNOSCUT"), OptiuneAsString, ProgramCulori);
            return s;
        }
    }
}
