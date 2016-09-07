using System;
using System.Linq;
using System.Linq;
using System;
using System.Windows.Forms;
using Entities;
using Repositories;
using Entities;
using Repositories;

namespace OKDemarrageIntegration
{
    public partial class TQP : Form
    {
        private AQLM2Entities context;
        private string mat;
        private PiloteIntegRepositories pil;
        private PiloteFiniIntegration pilInsert;
        private PiloteFiniIntegRepositories pilr;
        private ValOKdIntegrepositories repo;
        private InsertRepositories insertRepositories;
        private DateTime dateStart, dateFinish;


        public TQP()
        {
            InitializeComponent();

            context = new AQLM2Entities();
            repo = new ValOKdIntegrepositories(context);
            pil = new PiloteIntegRepositories(context);
            pilr = new PiloteFiniIntegRepositories(context);
            pilInsert = new PiloteFiniIntegration();
            insertRepositories=new InsertRepositories();
            dateStart = insertRepositories.getDateEquipe();
            dateFinish = insertRepositories.getDateFINEquipe(dateStart);
        }

        public TQP(string mat)
        {
            InitializeComponent();

            context = new AQLM2Entities();
            repo = new ValOKdIntegrepositories(context);
            pil = new PiloteIntegRepositories(context);
            pilr = new PiloteFiniIntegRepositories(context);
            pilInsert = new PiloteFiniIntegration();
            this.mat = mat;
            insertRepositories = new InsertRepositories();
            dateStart = insertRepositories.getDateEquipe();
            dateFinish = insertRepositories.getDateFINEquipe(dateStart);
        }

        private void ValPBTF_Click(object sender, EventArgs e)
        {
            Boolean err = false;
            RadioButton[] l = { PBTFrb9Ok, PBTFrb9NOk, PBTFrb9Na, PBTFrb11Ok, PBTFrb11NOk, PBTFrb11Na };
            RadioButton[] listNok = { PBTFrb9NOk, PBTFrb11NOk };

            var v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage1.Text;

            var insert = new InsertRepositories(ComPBTF, listNok, l, ValPBTF, ComPBTF.Text);
            err = insert.checkNokRb(err);

            var msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;
            }


            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            var dd = 64;
            if (insert.checkRb(err))
            {

                for (var i = 0; i < l.Length - 2; i += 3)
                {
                    v.date = DateTime.Now;
                    v.equipe = insert.getEquipe(dateStart);
                    //v.idLigne = 5;

                    var b = true;
                    var c = false;
                    v.ok = c;
                    v.nok = c;
                    v.na = c;

                    if (l[i].Checked)
                    {
                        v.ok = b;
                        v.idDescription = dd;
                    }
                    else if (l[i + 1].Checked)
                    {
                        v.nok = b;
                        v.idDescription = dd;

                        v.commentaire = msg;
                    }
                    else
                    {
                        v.na = b;
                        v.idDescription = dd;
                    }
                    dd = dd + 2;
                    repo.Insert(v);
                }
                if (err == false)
                {
                    ValPBTF.Enabled = false;
                    pilr.Insert(pilInsert);
                    MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {


                if (err)
                {
                    MessageBox.Show("S'il vous plait remplir les champs commentaire", "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Vérifier votre choix!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new Login();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TQP_Load(object sender, EventArgs e)
        {
            
             
            var pfi = new PiloteFiniIntegRepositories(context);
            var poste =
                pfi.Get(p => p.date > dateStart && p.date < dateFinish && p.Fonction.Equals("TQP"))
                    .Select(p => p.Poste)
                    .ToList();
            foreach (var d in poste)
            {
                if (d.Equals(navigationPage1.Text))
                {
                    ValPBTF.Enabled = false;
                }
                else if (d.Equals(navigationPage2.Text))
                {
                    ValPEmb.Enabled = false;
                }else if (d.Equals(navigationPage3.Text))
                {
                    ValPpalet.Enabled = false;
                }
                
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ValPEmb_Click_1(object sender, EventArgs e)
        {
            var err = false;
            RadioButton[] l = { PEmbrb5Ok, PEmbrb5NOk, PEmbrb5Na };
            RadioButton[] listNok = { PEmbrb5NOk };
            var v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage2.Text;

            var insert = new InsertRepositories(ComPEmb, listNok, l, ValPEmb, ComPEmb.Text);
            err = insert.checkNokRb(err);
            var msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;
            }

            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            v.idDescription = 93;
            if (insert.checkRb(err))
            {
                for (var i = 0; i < l.Length - 2; i += 3)
                {
                    v.date = DateTime.Now;
                    v.equipe = insert.getEquipe(dateStart);

                    //v.idLigne = 5;

                    var b = true;
                    var c = false;
                    v.ok = c;
                    v.nok = c;
                    v.na = c;

                    if (l[i].Checked)
                    {
                        v.ok = b;
                    }
                    else if (l[i + 1].Checked)
                    {
                        v.nok = b;
                        //dd++;
                        v.commentaire = msg;
                    }
                    else
                    {
                        v.na = b;
                        //dd++;
                    }

                    repo.Insert(v);
                }
                if (err == false)
                {
                    ValPEmb.Enabled = false;
                    pilr.Insert(pilInsert);
                    MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                if (err)
                {
                    MessageBox.Show("S'il vous plait remplir les champs commentaire","Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show("Vérifier votre choix!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void ValPpalet_Click(object sender, EventArgs e)
        {
            var err = false;
            RadioButton[] l = { Ppaletrb1Ok, Ppaletrb1NOk, Ppaletrb1Na };
            RadioButton[] listNok = { Ppaletrb1NOk };

            var v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage3.Text;

            var insert = new InsertRepositories(ComPpalet, listNok, l, ValPpalet, ComPpalet.Text);
            err = insert.checkNokRb(err);
            var msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;
            }

            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            v.idDescription = 102;
            if (insert.checkRb(err))
            {
                for (var i = 0; i < l.Length - 2; i += 3)
                {
                    v.date = DateTime.Now;
                    //v.idLigne = 5;
                    v.equipe = insert.getEquipe(dateStart);

                    var b = true;
                    var c = false;
                    v.ok = c;
                    v.nok = c;
                    v.na = c;
                    if (l[i].Checked)
                    {
                        v.ok = b;
                    }
                    else if (l[i + 1].Checked)
                    {
                        v.nok = b;
                        v.commentaire = msg;
                    }
                    else
                    {
                        v.na = b;
                    }

                    repo.Insert(v);
                }
                if (err == false)
                {
                    ValPpalet.Enabled = false;
                    pilr.Insert(pilInsert);
                    MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                if (err)
                {
                    MessageBox.Show("S'il vous plait remplir les champs commentaire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Vérifier votre choix!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}