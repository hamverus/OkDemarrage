using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositories;
using Entities;
namespace OKDemarrageIntegration
{
    public partial class TQP : Form
    {
        private string mat;
        public TQP()
        {
            InitializeComponent();
        }
        public TQP(string mat)
        {
            InitializeComponent();
            this.mat = mat;
        }

        private void ValPBTF_Click(object sender, EventArgs e)
        {
            //AQLM2Entities context = new AQLM2Entities();
            //ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            //OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            ////            LigneRepositories lig = new LigneRepositories(context);

            //RadioButton[] l = {  PBTFrb9Ok, PBTFrb9NOk, PBTFrb9Na, PBTFrb11Ok, PBTFrb11NOk, PBTFrb11Na };
            //RadioButton[] listNok = {  PBTFrb9NOk, PBTFrb11NOk };

            //InsertRepositories insert = new InsertRepositories(ComPBTF, listNok, l, ValPBTF, ComPBTF.Text);
            //insert.checkNokRb();
            //insert.InsertData("Intégration ADT", "Poste BTF", desc, repo);

            bool err = false;
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            
            RadioButton[] l = { PBTFrb9Ok, PBTFrb9NOk, PBTFrb9Na, PBTFrb11Ok, PBTFrb11NOk, PBTFrb11Na };
            RadioButton[] listNok = { PBTFrb9NOk, PBTFrb11NOk };

            PiloteIntegRepositories pil = new PiloteIntegRepositories(context);
            PiloteFiniIntegRepositories pilr = new PiloteFiniIntegRepositories(context);

            PiloteFiniIntegration pilInsert = new PiloteFiniIntegration();
            ValOKdIntegrtion v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage1.Text;

            InsertRepositories insert = new InsertRepositories(ComPBTF, listNok, l, ValPBTF, ComPBTF.Text);
            insert.checkNokRb();
            
            string msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;

            }
            
            
            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            int dd = 64;
            if (insert.checkRb(err)) { 
            for (int i = 0; i < l.Length - 2; i += 3)
            {

                

                v.date = DateTime.Now;
                //v.idLigne = 5;

                bool b = true;
                bool c = false;
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
                MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }else
            {
                MessageBox.Show("Errreur !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ValPEmb_Click(object sender, EventArgs e)
        {
            //AQLM2Entities context = new AQLM2Entities();
            //ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            //OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            ////            LigneRepositories lig = new LigneRepositories(context);

            //RadioButton[] l = {  PEmbrb5Ok, PEmbrb5NOk, PEmbrb5Na };
            //RadioButton[] listNok = { PEmbrb5NOk };

            //InsertRepositories insert = new InsertRepositories(ComPEmb, listNok, l, ValPEmb, ComPEmb.Text);
            //insert.checkNokRb();
            //insert.InsertData("Intégration ADT", "Poste Emballage ", desc, repo);


            bool err = false;
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            RadioButton[] l = { PEmbrb5Ok, PEmbrb5NOk, PEmbrb5Na };
            RadioButton[] listNok = { PEmbrb5NOk };


            PiloteIntegRepositories pil = new PiloteIntegRepositories(context);
            PiloteFiniIntegRepositories pilr = new PiloteFiniIntegRepositories(context);

            PiloteFiniIntegration pilInsert = new PiloteFiniIntegration();
            ValOKdIntegrtion v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage2.Text;

            InsertRepositories insert = new InsertRepositories(ComPEmb, listNok, l, ValPEmb, ComPEmb.Text);
            insert.checkNokRb();
            string msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;

            }

            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            v.idDescription = 93;
            for (int i = 0; i < l.Length - 2; i += 3)
            {


                
                v.date = DateTime.Now;
                //v.idLigne = 5;

                bool b = true;
                bool c = false;
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
                MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AQLM2Entities context = new AQLM2Entities();
            //ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            //OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            ////            LigneRepositories lig = new LigneRepositories(context);

            //RadioButton[] l = { Ppaletrb1Ok, Ppaletrb1NOk, Ppaletrb1Na };
            //RadioButton[] listNok = { Ppaletrb1NOk };

            //InsertRepositories insert = new InsertRepositories(ComPpalet, listNok, l, ValPpalet, ComPpalet.Text);
            //insert.checkNokRb();
            //insert.InsertData("Intégration ADT", "Poste Paléttisation", desc, repo);

            bool err = false;
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            RadioButton[] l = { Ppaletrb1Ok, Ppaletrb1NOk, Ppaletrb1Na };
            RadioButton[] listNok = { Ppaletrb1NOk };

            PiloteIntegRepositories pil = new PiloteIntegRepositories(context);
            PiloteFiniIntegRepositories pilr = new PiloteFiniIntegRepositories(context);

            PiloteFiniIntegration pilInsert = new PiloteFiniIntegration();
            ValOKdIntegrtion v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage3.Text;

            InsertRepositories insert = new InsertRepositories(ComPpalet, listNok, l, ValPpalet, ComPpalet.Text);
            insert.checkNokRb();
            string msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;

            }

            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            v.idDescription = 102;
            for (int i = 0; i < l.Length - 2; i += 3)
            {

               

                v.date = DateTime.Now;
                //v.idLigne = 5;

                bool b = true;
                bool c = false;
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
                MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("S'il vous plait remplir les chaps ci-dessus");
            }

}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void TQP_Load(object sender, EventArgs e)
        { AQLM2Entities context=new AQLM2Entities();
            DateTime dateStart = new DateTime(2016, 09, 05, 12, 05, 00);
            DateTime dateFinish = new DateTime(2016, 09, 05, 12, 11, 00);
            PiloteFiniIntegRepositories pfi=new PiloteFiniIntegRepositories(context);
            List<String> poste =
                pfi.Get(p => p.date > dateStart && p.date < dateFinish && p.Fonction.Equals("TQP"))
                    .Select(p => p.Poste)
                    .ToList();
            foreach (var d in poste)
            {
                if (d.Equals(navigationPage1.Text))
                {
                    ValPBTF.Enabled = false;
                }
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ValPEmb_Click_1(object sender, EventArgs e)
        {

            bool err = false;
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            RadioButton[] l = { PEmbrb5Ok, PEmbrb5NOk, PEmbrb5Na };
            RadioButton[] listNok = { PEmbrb5NOk };


            PiloteIntegRepositories pil = new PiloteIntegRepositories(context);
            PiloteFiniIntegRepositories pilr = new PiloteFiniIntegRepositories(context);

            PiloteFiniIntegration pilInsert = new PiloteFiniIntegration();
            ValOKdIntegrtion v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage2.Text;

            InsertRepositories insert = new InsertRepositories(ComPEmb, listNok, l, ValPEmb, ComPEmb.Text);
            insert.checkNokRb();
            string msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;

            }

            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            v.idDescription = 93;
            for (int i = 0; i < l.Length - 2; i += 3)
            {



                v.date = DateTime.Now;
                //v.idLigne = 5;

                bool b = true;
                bool c = false;
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
                MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ValPpalet_Click(object sender, EventArgs e)
        {
            bool err = false;
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            RadioButton[] l = { Ppaletrb1Ok, Ppaletrb1NOk, Ppaletrb1Na };
            RadioButton[] listNok = { Ppaletrb1NOk };

            PiloteIntegRepositories pil = new PiloteIntegRepositories(context);
            PiloteFiniIntegRepositories pilr = new PiloteFiniIntegRepositories(context);

            PiloteFiniIntegration pilInsert = new PiloteFiniIntegration();
            ValOKdIntegrtion v = new ValOKdIntegrtion();
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationPage3.Text;

            InsertRepositories insert = new InsertRepositories(ComPpalet, listNok, l, ValPpalet, ComPpalet.Text);
            insert.checkNokRb();
            string msg = "";

            if (!String.IsNullOrEmpty(ComPpalet.Text))
            {
                msg = ComPpalet.Text;

            }

            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            v.idDescription = 102;
            for (int i = 0; i < l.Length - 2; i += 3)
            {



                v.date = DateTime.Now;
                //v.idLigne = 5;

                bool b = true;
                bool c = false;
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
                MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("S'il vous plait remplir les chaps ci-dessus");
            }
        }
    }
}
