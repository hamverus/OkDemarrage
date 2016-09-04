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
    public partial class Integration : Form
    {
        public Integration()
        {
            InitializeComponent();
        }

        public Integration(string text)
        {
            InitializeComponent();
            Text = text;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ValAss1_Click_1(object sender, EventArgs e)
        {
            RadioButton[] listNok = { Ass1rb1Nok, Ass1rb2NOk, Ass1rb3NOk, Ass1rb4NOk, Ass1rb5NOk, Ass1rb6NOk, Ass1rb7NOk };
            RadioButton[] l = { Ass1rb1Ok, Ass1rb1Nok, Ass1rb1Na, Ass1rb2Ok, Ass1rb2NOk, Ass1rb2Na, Ass1rb3Ok, Ass1rb3NOk, Ass1rb3Na, Ass1rb4Ok, Ass1rb4NOk, Ass1rb4Na, Ass1rb5Ok, Ass1rb5NOk, Ass1rb5Na, Ass1rb6Ok, Ass1rb6NOk, Ass1rb6Na, Ass1rb7Ok, Ass1rb7NOk, Ass1rb7Na };
            AQLM2Entities context = new AQLM2Entities();
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            InsertRepositories insert = new InsertRepositories(ComAss1, listNok, l, ValAss1, ComAss1.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Assembage  01", desc, repo);
        }

        private void ValAss2_Click(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { Ass2rb1Ok, Ass2rb1NOk, Ass2rb1Na, Ass2rb2Ok, Ass2rb2NOk, Ass2rb2Na, Ass2rb3Ok, Ass2rb3NOk, Ass2rb3Na, Ass2rb4Ok, Ass2rb4NOk, Ass2rb4Na, Ass2rb5Ok, Ass2rb5NOk, Ass2rb5Na, Ass2rb6Ok, Ass2rb6NOk, Ass2rb6Na, Ass2rb7Ok, Ass2rb7NOk, Ass2rb7Na };
            RadioButton[] listNok = { Ass2rb1NOk, Ass2rb2NOk, Ass2rb3NOk, Ass2rb4NOk, Ass2rb5NOk, Ass2rb6NOk, Ass2rb7NOk };

            InsertRepositories insert = new InsertRepositories(ComAss2, listNok, l, ValAss2, ComAss2.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Assembage 02", desc, repo);
        }

        private void ValAss3_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { Ass3rb1Ok, Ass3rb1NOk, Ass3rb1Na, Ass3rb2Ok, Ass3rb2NOk, Ass3rb2Na, Ass3rb3Ok, Ass3rb3NOk, Ass3rb3Na, Ass3rb4Ok, Ass3rb4NOk, Ass3rb4Na, Ass3rb5Ok, Ass3rb5NOk, Ass3rb5Na, Ass3rb6Ok, Ass3rb6NOk, Ass3rb6Na, Ass3rb7Ok, Ass3rb7NOk, Ass3rb7Na };
            RadioButton[] listNok = { Ass3rb1NOk, Ass3rb2NOk, Ass3rb3NOk, Ass3rb4NOk, Ass3rb5NOk, Ass3rb6NOk, Ass3rb7NOk };

            InsertRepositories insert = new InsertRepositories(ComAss3, listNok, l, ValAss3, ComAss3.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Assembage 03", desc, repo);
        }

        private void ValAss4_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { Ass4rb1Ok, Ass4rb1NOk, Ass4rb1Na, Ass4rb2Ok, Ass4rb2NOk, Ass4rb2Na, Ass4rb3Ok, Ass4rb3NOk, Ass4rb3Na, Ass4rb4Ok, Ass4rb4NOk, Ass4rb4Na, Ass4rb5Ok, Ass4rb5NOk, Ass4rb5Na, Ass4rb6Ok, Ass4rb6NOk, Ass4rb6Na, Ass4rb7Ok, Ass4rb7NOk, Ass4rb7Na };
            RadioButton[] listNok = { Ass4rb1NOk, Ass4rb2NOk, Ass4rb3NOk, Ass4rb4NOk, Ass4rb5NOk, Ass4rb6NOk, Ass4rb7NOk };

            InsertRepositories insert = new InsertRepositories(ComAss3, listNok, l, ValAss4, ComAss3.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Assembage 04", desc, repo);
        }

        private void ValAss5_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { Ass5rb1Ok, Ass5rb1NOk, Ass5rb1Na, Ass5rb2Ok, Ass5rb2NOk, Ass5rb2Na, Ass5rb3Ok, Ass5rb3NOk, Ass5rb3Na, Ass5rb4Ok, Ass5rb4NOk, Ass5rb4Na, Ass5rb5Ok, Ass5rb5NOk, Ass5rb5Na, Ass5rb6Ok, Ass5rb6NOk, Ass5rb6Na, Ass5rb7Ok, Ass5rb7NOk, Ass5rb7Na };
            RadioButton[] listNok = { Ass5rb1NOk, Ass5rb2NOk, Ass5rb3NOk, Ass5rb4NOk, Ass5rb5NOk, Ass5rb6NOk, Ass5rb7NOk };

            InsertRepositories insert = new InsertRepositories(ComAss5, listNok, l, ValAss5, ComAss5.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Assembage 05", desc, repo);
        }

        private void ValAss6_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { Ass6rb1Ok, Ass6rb1NOk, Ass6rb1Na, Ass6rb2Ok, Ass6rb2NOk, Ass6rb2Na, Ass6rb3Ok, Ass6rb3NOk, Ass6rb3Na, Ass6rb4Ok, Ass6rb4NOk, Ass6rb4Na, Ass6rb5Ok, Ass6rb5NOk, Ass6rb5Na, Ass6rb6Ok, Ass6rb6NOk, Ass6rb6Na, Ass6rb7Ok, Ass6rb7NOk, Ass6rb7Na };
            RadioButton[] listNok = { Ass6rb1NOk, Ass6rb2NOk, Ass6rb3NOk, Ass6rb4NOk, Ass6rb5NOk, Ass6rb6NOk, Ass6rb7NOk };

            InsertRepositories insert = new InsertRepositories(ComAss6, listNok, l, ValAss6, ComAss6.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Assembage 06", desc, repo);
        }

        private void ValPv_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PVrb1Ok, PVrb1NOk, PVrb1Na, PVrb2Ok, PVrb2NOk, PVrb2Na, PVrb3Ok, PVrb3NOk, PVrb3Na, PVrb4Ok, PVrb4NOk, PVrb4Na, PVrb5Ok, PVrb5NOk, PVrb5Na };
            RadioButton[] listNok = { PVrb1NOk, PVrb2NOk, PVrb3NOk, PVrb4NOk, PVrb5NOk };

            InsertRepositories insert = new InsertRepositories(ComPV, listNok, l, ValPv, ComPV.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Poste Vision", desc, repo);
        }

        private void ValPD_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PDrb1Ok, PDrb1NOk, PDrb1Na, PDrb2Ok, PDrb2NOk, PDrb2Na, PDrb3Ok, PDrb3NOk, PDrb3Na, PDrb4Ok, PDrb4NOk, PDrb4Na };
            RadioButton[] listNok = { PDrb1NOk, PDrb2NOk, PDrb3NOk, PDrb4NOk };

            InsertRepositories insert = new InsertRepositories(ComPD, listNok, l, ValPD, ComPD.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Poste Dielectrique", desc, repo);
        }

        private void ValPWifi_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PWifirb1Ok, PWifirb1NOk, PWifirb1Na, PWifirb2Ok, PWifirb2NOk, PWifirb2Na, PWifirb3Ok, PWifirb3NOk, PWifirb3Na, PWifirb4Ok, PWifirb4NOk, PWifirb4Na };
            RadioButton[] listNok = { PWifirb1NOk, PWifirb2NOk, PWifirb3NOk, PWifirb4NOk };

            InsertRepositories insert = new InsertRepositories(ComPWifi, listNok, l, ValPWifi, ComPWifi.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Poste Wifi", desc, repo);
        }

        private void ValPBTF_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PBTFrb1Ok, PBTFrb1NOk, PBTFrb1Na, PBTFrb2Ok, PBTFrb2NOk, PBTFrb2Na, PBTFrb3Ok, PBTFrb3NOk, PBTFrb3Na, PBTFrb4Ok, PBTFrb4NOk, PBTFrb4Na, PBTFrb5Ok, PBTFrb5NOk, PBTFrb5Na, PBTFrb6Ok, PBTFrb6NOk, PBTFrb6Na, PBTFrb7Ok, PBTFrb7NOk, PBTFrb7Na, PBTFrb8Ok, PBTFrb8NOk, PBTFrb8Na, PBTFrb9Ok, PBTFrb9NOk, PBTFrb9Na, PBTFrb10Ok, PBTFrb10NOk, PBTFrb10Na, PBTFrb11Ok, PBTFrb11NOk, PBTFrb11Na };
            RadioButton[] listNok = { PBTFrb1NOk, PBTFrb2NOk, PBTFrb3NOk, PBTFrb4NOk, PBTFrb5NOk, PBTFrb6NOk, PBTFrb7NOk, PBTFrb8NOk, PBTFrb9NOk, PBTFrb10NOk, PBTFrb11NOk };

            InsertRepositories insert = new InsertRepositories(ComPBTF, listNok, l, ValPBTF, ComPBTF.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Poste BTF", desc, repo);
        }

        private void ValFSOS_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { FSOSrb1Ok, FSOSrb1NOk, FSOSrb1Na, FSOSrb2Ok, FSOSrb2NOk, FSOSrb2Na, FSOSrb3Ok, FSOSrb3NOk, FSOSrb3Na, FSOSrb4Ok, FSOSrb4NOk, FSOSrb4Na };
            RadioButton[] listNok = { FSOSrb1NOk, FSOSrb2NOk, FSOSrb3NOk, FSOSrb4NOk };

            InsertRepositories insert = new InsertRepositories(ComFSOS, listNok, l, ValFSOS, ComFSOS.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "F SOS", desc, repo);
        }

        private void ValTelch_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { Telchrb1Ok, Telchrb1NOk, Telchrb1Na, Telchrb2Ok, Telchrb2NOk, Telchrb2Na, Telchrb3Ok, Telchrb3NOk, Telchrb3Na, Telchrb4Ok, Telchrb4NOk, Telchrb4Na, Telchrb5Ok, Telchrb5NOk, Telchrb5Na, Telchrb6Ok, Telchrb6NOk, Telchrb6Na, Telchrb7Ok, Telchrb7NOk, Telchrb7Na, Telchrb8Ok, Telchrb8NOk, Telchrb8Na };
            RadioButton[] listNok = { Telchrb1NOk, Telchrb2NOk, Telchrb3NOk, Telchrb4NOk, Telchrb5NOk, Telchrb6NOk, Telchrb7NOk, Telchrb8NOk };

            InsertRepositories insert = new InsertRepositories(ComTelch, listNok, l, ValTelch, ComTelch.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Téléchargement", desc, repo);
        }

        private void ValPerMur_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PerMurrb1Ok, PerMurrb1NOk, PerMurrb1Na, PerMurrb2Ok, PerMurrb2NOk, PerMurrb2Na, PerMurrb3Ok, PerMurrb3NOk, PerMurrb3Na, PerMurrb4Ok, PerMurrb4NOk, PerMurrb4Na, PerMurrb5Ok, PerMurrb5NOk, PerMurrb5Na, PerMurrb6Ok, PerMurrb6NOk, PerMurrb6Na };
            RadioButton[] listNok = { PerMurrb1NOk, PerMurrb2NOk, PerMurrb3NOk, PerMurrb4NOk, PerMurrb5NOk, PerMurrb6NOk };

            InsertRepositories insert = new InsertRepositories(ComPerMur, listNok, l, ValPerMur, ComPerMur.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Prérecette", desc, repo);
        }

        private void ValPEmb_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PEmbrb1Ok, PEmbrb1NOk, PEmbrb1Na, PEmbrb2Ok, PEmbrb2NOk, PEmbrb2Na, PEmbrb3Ok, PEmbrb3NOk, PEmbrb3Na, PEmbrb4Ok, PEmbrb4NOk, PEmbrb4Na, PEmbrb5Ok, PEmbrb5NOk, PEmbrb5Na };
            RadioButton[] listNok = { PEmbrb1NOk, PEmbrb2NOk, PEmbrb3NOk, PEmbrb4NOk, PEmbrb5NOk };

            InsertRepositories insert = new InsertRepositories(ComPEmb, listNok, l, ValPEmb, ComPEmb.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Poste Emballage ", desc, repo);
        }

        private void ValPpalet_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { Ppaletrb1Ok, Ppaletrb1NOk, Ppaletrb1Na, Ppaletrb2Ok, Ppaletrb2NOk, Ppaletrb2Na, Ppaletrb3Ok, Ppaletrb3NOk, Ppaletrb3Na, Ppaletrb4Ok, Ppaletrb4NOk, Ppaletrb4Na, Ppaletrb5Ok, Ppaletrb5NOk, Ppaletrb5Na, Ppaletrb6Ok, Ppaletrb6NOk, Ppaletrb6Na, Ppaletrb7Ok, Ppaletrb7NOk, Ppaletrb7Na, Ppaletrb8Ok, Ppaletrb8NOk, Ppaletrb8Na, Ppaletrb9Ok, Ppaletrb9NOk, Ppaletrb9Na };
            RadioButton[] listNok = { Ppaletrb1NOk, Ppaletrb2NOk, Ppaletrb3NOk, Ppaletrb4NOk, Ppaletrb5NOk, Ppaletrb6NOk, Ppaletrb7NOk, Ppaletrb8NOk, Ppaletrb9NOk };

            InsertRepositories insert = new InsertRepositories(ComPpalet, listNok, l, ValPpalet, ComPpalet.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Poste Paléttisation", desc, repo);
        }

        private void ValPAQL_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PAQLrb1Ok, PAQLrb1NOk, PAQLrb1Na, PAQLrb2Ok, PAQLrb2NOk, PAQLrb2Na, PAQLrb3Ok, PAQLrb3NOk, PAQLrb3Na, PAQLrb4Ok, PAQLrb4NOk, PAQLrb4Na, PAQLrb5Ok, PAQLrb5NOk, PAQLrb5Na, PAQLrb6Ok, PAQLrb6NOk, PAQLrb6Na, PAQLrb7Ok, PAQLrb7NOk, PAQLrb7Na, PAQLrb8Ok, PAQLrb8NOk, PAQLrb8Na };
            RadioButton[] listNok = { PAQLrb1NOk, PAQLrb2NOk, PAQLrb3NOk, PAQLrb4NOk, PAQLrb5NOk, PAQLrb6NOk, PAQLrb7NOk, PAQLrb8NOk };

            InsertRepositories insert = new InsertRepositories(ComPAQL, listNok, l, ValPAQL, ComPAQL.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "Poste Paléttisation", desc, repo);
        }

        private void ValPrepBt_Click(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();
            ValOKdIntegrepositories repo = new ValOKdIntegrepositories(context);
            OkDescriptRepositorie desc = new OkDescriptRepositorie(context);
            //            LigneRepositories lig = new LigneRepositories(context);

            RadioButton[] l = { PrepBtrb1Ok, PrepBtrb1NOk, PrepBtrb1Na, PrepBtrb2Ok, PrepBtrb2NOk, PrepBtrb2Na, PrepBtrb3Ok, PrepBtrb3NOk, PrepBtrb3Na, PrepBtrb4Ok, PrepBtrb4NOk, PrepBtrb4Na };
            RadioButton[] listNok = { PrepBtrb1NOk, PrepBtrb2NOk, PrepBtrb3NOk, PrepBtrb4NOk };

            InsertRepositories insert = new InsertRepositories(ComPrepBt, listNok, l, ValPrepBt, ComPrepBt.Text);
            insert.checkNokRb();
            insert.InsertData("Intégration ADT", "F SOS", desc, repo);
        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.ShowDialog();
        }

        private void Fermer_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
