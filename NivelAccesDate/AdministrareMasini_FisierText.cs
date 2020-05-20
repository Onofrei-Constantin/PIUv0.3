using LibrarieModele;
using System;
using System.Collections;
using System.IO;

namespace NivelAccesDate
{
    public class AdministrareMasini_FisierText : IStocareData
    {
        private const int PAS_ALOCARE = 18;
        private const int ID_PRIMA_MASINA = 1;
        private const int INCREMENT = 1;
        string NumeFisier { get; set; }
        public AdministrareMasini_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void Stergere()
        {
            File.WriteAllText(NumeFisier, String.Empty);
        }
        public void AddMasina(Masina s)
        {
            s.IdMasina = GetId();
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(s.ConversiaLaSir_PentruFisier_PentruForma());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica.Mesaj: " + eGen.Message);
            }
        }


        public ArrayList GetMasini()
        {
            ArrayList masini = new ArrayList();

            try
            {
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Masina s = new Masina(line);
                        masini.Add(s);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return masini;
        }
        public Masina GetMasina(string numeVanzator, string tip)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Masina masina = new Masina(line);
                        if (masina.NumeVanzator.Equals(numeVanzator) && masina.Tip.Equals(tip))
                            return masina;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }
        public bool UpdateMasina(Masina maisnaActualizata)
        {
            ArrayList masini = GetMasini();
            bool actualizareCuSucces = false;
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'false' al constructorului StreamWriter indica modul 'overwrite' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
                {
                    foreach (Masina mas in masini)
                    {
                        //informatiile despre studentul actualizat vor fi preluate din parametrul "studentActualizat"
                        if (mas.IdMasina != maisnaActualizata.IdMasina)
                        {
                            swFisierText.WriteLine(mas.ConversiaLaSir_PentruFisier_PentruForma());
                        }
                        else
                        {
                            swFisierText.WriteLine(maisnaActualizata.ConversiaLaSir_PentruFisier_PentruForma());
                        }
                    }
                    actualizareCuSucces = true;
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return actualizareCuSucces;
        }

        private int GetId()
        {
            int IdMasina = ID_PRIMA_MASINA;
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Masina s = new Masina(line);
                        IdMasina = s.IdMasina + INCREMENT;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return IdMasina;
        }
    }
}
