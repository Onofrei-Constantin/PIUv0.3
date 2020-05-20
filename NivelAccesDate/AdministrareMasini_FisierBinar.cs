using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareMasini_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareMasini_FisierBinar(string numeFisier)
        {
            this.NumeFisier = numeFisier;
        }
        public void AddMasina(Masina s)
        {
            throw new Exception("Optiunea AddMasina nu este implementata");
        }
        public void Stergere()
        {
            throw new Exception("Optiunea Stergere nu este implementata");
        }
        public ArrayList GetMasini()
        {
            throw new Exception("Optiunea GetMasini nu este implementata");
        }
        public Masina GetMasina(string numeVanzator, string tip)
        {
            throw new Exception("Optiunea GetMasini nu este implementata");
        }
        public bool UpdateMasina(Masina s)
        {
            throw new Exception("Optiunea UpdateMasina nu este implementata");
        }
    }
}
