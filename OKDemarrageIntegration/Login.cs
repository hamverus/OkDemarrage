using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Data.Helpers;
using Entities;
using Repositories;

namespace OKDemarrageIntegration
{
    public partial class Login : Form
    {
        AQLM2Entities context = new AQLM2Entities();
        private PiloteIntegRepositories pir; 
        private PiloteFiniRepositories pf;
        private PiloteFiniIntegRepositories pfi;
        private ValOKdIntegrtion valOKdIntegrtion;
        private DateTime dateStart, dateFinish;
        private InsertRepositories insertRepositories;


        public Login()
        {
            InitializeComponent();
             pir = new PiloteIntegRepositories(context);
             pf = new PiloteFiniRepositories(context);
             pfi = new PiloteFiniIntegRepositories(context);
             insertRepositories = new InsertRepositories();

             dateStart = insertRepositories.getDateEquipe();
             dateFinish = insertRepositories.getDateFINEquipe(dateStart);

        }
        private void Login_Load(object sender, EventArgs e)
        {
            valOKdIntegrtion=new ValOKdIntegrtion();
             pir = new PiloteIntegRepositories(context);
           pf = new PiloteFiniRepositories(context);
            pfi = new PiloteFiniIntegRepositories(context);
         

            displayList(dateStart, dateFinish, 3, "TQP");
            displayList(dateFinish, dateStart, 16, "CE");

        }

       
        private void displayList(DateTime dateStart,DateTime dateFinish,int test,String fonction)
        {
            try
            {

           
            // Array data;
            var data = pfi.Get(dt => dt.date >= dateStart && dt.date <= dateFinish).Select(dt => new { dt.matricule, dt.nom, dt.prenom, dt.Fonction }).Distinct().ToList();
            // Console.Write(data.GetValue(0).ToString());
            
            var cont = pfi.Get(c => c.Fonction.Equals(fonction)).Count();
            
            if (cont == test)
            {
                foreach (var d in data)
                {


                    ListViewItem item = new ListViewItem();
                    item.Text = d.matricule;
                    item.SubItems.Add(d.nom);
                    item.SubItems.Add(d.prenom);
                    item.SubItems.Add(d.Fonction);
                    listPiloteFini.Items.Add(item);
                }
            }
            }
            catch (Exception)
            {


            }
        }

        
        private void connecter_Click_1(object sender, EventArgs e)
        {
            AQLM2Entities context = new AQLM2Entities();  


            PiloteIntegRepositories pilote = new PiloteIntegRepositories(context);
            bool validUser = false;
            var userElement =
                    pilote.Get(u => u.matricule.Equals(LoginHome.Text) && u.pwd.Equals(motdepasse.Text))
                        .SingleOrDefault();


            validUser = (userElement != null);
            if (validUser)
            {

                if (userElement.poste.Equals("TQP"))
                {

                    this.Hide();
                    TQP dem = new TQP(LoginHome.Text);
                    dem.Show();
                }
                else if (userElement.poste.Equals("CE"))
                {
                    this.Hide();
                    Integration dem = new Integration(LoginHome.Text);
                    dem.Show();
                }
                else
                {
                    MessageBox.Show("login ou mot de passe incorrecte !", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("login ou mot de passe incorrecte !", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (DateTime.Now <= dateFinish)
            //{
            //    dateStart = insertRepositories.getDateEquipe();
            //    dateFinish = insertRepositories.getDateFINEquipe(dateStart);

            //}

            if (DateTime.Now == dateFinish || DateTime.Now >= dateFinish.AddSeconds(4))
            {
                Environment.Exit(0);
            }
        }
    }
}
