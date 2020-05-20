using System;
using System.Drawing;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;
using System.Collections;

namespace Proiect_Forma_II
{
    public partial class Form1 : Form
    {
        IStocareData adminMasini;
        ArrayList optiuniSelectate = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            adminMasini = StocareFactory.GetAdministratorStocare();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            ResetCuloareEtichete();

            CodEroare codValidare = Validare(txtNumeVanzator.Text, txtNumeCumparator.Text, txtTip.Text, txtAnFabricare.Text, txtDataTranzactie.Text, txtPret.Text);

            if (codValidare != CodEroare.CORECT)
            {
                MarcheazaControaleCuDateIncorecte(codValidare);
            }
            else
            {
                Masina s = new Masina(txtNumeVanzator.Text, txtNumeCumparator.Text, txtTip.Text, txtAnFabricare.Text, txtDataTranzactie.Text, txtPret.Text);


                s.ProgramCulori = GetCuloareSelectata();
                //set Discipline
                s.ProgramOptiuni = new ArrayList();
                s.ProgramOptiuni.AddRange(optiuniSelectate);

                adminMasini.AddMasina(s);
                lblMesaj.Text = "Masina a fost adaugata";

                //resetarea controalelor pentru a introduce datele unui student nou
                ResetareControale();
            }

        }

        private void btnAfiseaza_Click(object sender, EventArgs e)
        {
            rtbAfisare.Clear();
            var antetTabel = String.Format("{0,15}{1,20}{2,20}{3,20}{4,20}{5,20}{6,20}{7,40}{8,20}\n", "Id", "Nume Vanzator", "Nume Cumparator", "Tip", "An Fabricare", "Data Tranzactie", "Pret", "Optiuni", "Culoare");
            rtbAfisare.AppendText(antetTabel);

            ArrayList masini = adminMasini.GetMasini();
            foreach (Masina s in masini)
            {
                var linieTabel = String.Format("{0,15}{1,20}{2,20}{3,20}{4,20}{5,20}{6,20}{7,40}{8,20}\n", s.IdMasina, s.NumeVanzator, s.NumeCumparator, s.Tip, s.AnFabricare, s.DataTranzactie, s.Pret, s.OptiuneAsString, s.ProgramCulori.ToString());
                rtbAfisare.AppendText(linieTabel);
            }
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            Masina s = adminMasini.GetMasina(txtNumeVanzator.Text, txtTip.Text);
            if (s != null)
            {
                lblMesaj.Text = s.ConversieLaSir_PentruForma();
                foreach (var optiune in gpbOptiuni.Controls)
                {
                    if (optiune is CheckBox)
                    {
                        var optiuneBox = optiune as CheckBox;
                        foreach (String opt in s.ProgramOptiuni)
                            if (optiuneBox.Text.Equals(opt))
                                optiuneBox.Checked = true;
                    }
                }
            }
            else
                lblMesaj.Text = "Nu s-a gasit masina";
            if (txtNumeVanzator.Enabled == true && txtTip.Enabled == true)
            {
                txtNumeVanzator.Enabled = false;
                txtTip.Enabled = false;
                //dezactivare butoane radio
                foreach (var button in gpbCulori.Controls)
                {
                    if (button is RadioButton)
                    {
                        var radioButton = button as RadioButton;
                        radioButton.Enabled = false;
                    }
                }
            }
            else
            {
                txtNumeVanzator.Enabled = true;
                txtPret.Enabled = true;
                //activare butoane radio
                foreach (var button in gpbCulori.Controls)
                {
                    if (button is RadioButton)
                    {
                        var radioButton = button as RadioButton;
                        radioButton.Enabled = true;
                    }
                }
            }

        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            Masina s = adminMasini.GetMasina(txtNumeVanzator.Text, txtTip.Text);
            if (s != null)
            {

                s.NumeCumparator = txtNumeCumparator.Text;
                s.AnFabricare = txtAnFabricare.Text;
                s.DataTranzactie = txtDataTranzactie.Text;
                s.Pret = txtPret.Text;

                adminMasini.UpdateMasina(s);
                lblModifica.Text = "Modificare efectuata";
                txtNumeVanzator.Enabled = true;
                txtTip.Enabled = true;
            }
            else
            {
                lblMesaj.Text = "Masina inexistenta";
            }

        }

        private void ckbDiscipline_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; //operator 'as'
            //sau
            //CheckBox checkBoxControl = (CheckBox)sender;  //operator cast

            string optiuneSelectata = checkBoxControl.Text;

            //verificare daca checkbox-ul asupra caruia s-a actionat este selectat
            if (checkBoxControl.Checked == true)
                optiuniSelectate.Add(optiuneSelectata);
            else
                optiuniSelectate.Remove(optiuneSelectata);
        }

        private void ResetareControale()
        {
            txtNumeVanzator.Text = txtNumeCumparator.Text = txtTip.Text = txtAnFabricare.Text = txtDataTranzactie.Text = txtPret.Text = string.Empty;
            rdbNegru.Checked = false;
            rdbRosu.Checked = false;
            rdbVerde.Checked = false;
            rdbGalben.Checked = false;
            rdbAlb.Checked = false;
            rdbAlbastru.Checked = false;
            ckbAerConditionat.Checked = false;
            ckbIncalzireScaune.Checked = false;
            ckbCruiseControl.Checked = false;
            ckbSenzoriParcare.Checked = false;
            ckbCutieAutomata.Checked = false;
            ckbNavigatie.Checked = false;
            optiuniSelectate.Clear();
            lblMesaj.Text = string.Empty;
        }

        private CodEroare Validare(string numeVanzator, string numeCumparator, string Tip, string AnFabricare, string DataTranzactie, string Pret)
        {
            CodEroare rezultatValidare = CodEroare.CORECT;
            if (numeVanzator == string.Empty)
            {
                rezultatValidare |= CodEroare.NUMEVANZATOR_INCORECT;
            }
            if (numeCumparator == string.Empty)
            {
                rezultatValidare |= CodEroare.NUMECUMPARATOR_INCORECT;
            }
            if (Tip == string.Empty)
            {
                rezultatValidare |= CodEroare.TIP_INCORECTE;
            }
            if (AnFabricare == string.Empty)
            {
                rezultatValidare |= CodEroare.ANFABRICARE_INCORECT;
            }
            if (DataTranzactie == string.Empty)
            {
                rezultatValidare |= CodEroare.DATATRANZACTIE_INCORECT;
            }
            if (Pret == string.Empty)
            {
                rezultatValidare |= CodEroare.PRET_INCORECTE;
            }

            if (optiuniSelectate.Count == 0)
            {
                rezultatValidare |= CodEroare.OPTIUNE_INCORECT;
            }

            int culoareSelectata = 0;
            foreach (var control in gpbCulori.Controls)
            {
                RadioButton rdb = null;
                try
                {
                    rdb = (RadioButton)control;
                }
                catch { }

                if (rdb != null && rdb.Checked == true)
                    culoareSelectata = 1;
            }
            if (culoareSelectata == 0)
            {
                rezultatValidare |= CodEroare.CULOARE_INCORECT;
            }

            if(optiuniSelectate.Count==0)
            {
                rezultatValidare |= CodEroare.OPTIUNE_INCORECT;
            }

            return rezultatValidare;
        }
        private void MarcheazaControaleCuDateIncorecte(CodEroare codValidare)
        {
            if ((codValidare & CodEroare.NUMEVANZATOR_INCORECT) == CodEroare.NUMEVANZATOR_INCORECT)
            {
                lblNumeVanzator.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.NUMECUMPARATOR_INCORECT) == CodEroare.NUMECUMPARATOR_INCORECT)
            {
                lblNumeCumparator.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.TIP_INCORECTE) == CodEroare.TIP_INCORECTE)
            {
                lblTip.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.ANFABRICARE_INCORECT) == CodEroare.ANFABRICARE_INCORECT)
            {
                lblAnFabricare.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.DATATRANZACTIE_INCORECT) == CodEroare.DATATRANZACTIE_INCORECT)
            {
                lblDataTranzacrie.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.PRET_INCORECTE) == CodEroare.PRET_INCORECTE)
            {
                lblPret.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.CULOARE_INCORECT) == CodEroare.CULOARE_INCORECT)
            {
                lblCuloare.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.OPTIUNE_INCORECT) == CodEroare.OPTIUNE_INCORECT)
            {
                lblOptiuni.ForeColor = Color.Red;
            }
        }
        private void ResetCuloareEtichete()
        {
            lblNumeCumparator.ForeColor = Color.Black;
            lblNumeVanzator.ForeColor = Color.Black;
            lblDataTranzacrie.ForeColor = Color.Black;
            lblAnFabricare.ForeColor = Color.Black;
            lblTip.ForeColor = Color.Black;
            lblPret.ForeColor = Color.Black;
            lblOptiuni.ForeColor = Color.Black;
            lblCuloare.ForeColor = Color.Black;
        }
        private Culori GetCuloareSelectata()
        {
            if (rdbAlb.Checked)
                return Culori.Alb;
            if (rdbAlbastru.Checked)
                return Culori.Albastru;
            if (rdbGalben.Checked)
                return Culori.Galben;
            if (rdbNegru.Checked)
                return Culori.Negru;
            if (rdbRosu.Checked)
                return Culori.Rosu;
            if (rdbVerde.Checked)
                return Culori.Verde;
            return Culori.Culoare_Inexistenta;
        }        
    }
}
