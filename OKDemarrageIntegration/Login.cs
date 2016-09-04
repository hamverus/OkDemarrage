using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        
        public Login()
        {
            InitializeComponent();
        }
        //public bool UserInCustomRole(string role)
        //{
        //    WindowsIdentity identity = WindowsIdentity.GetCurrent();
        //    WindowsPrincipal principal = new WindowsPrincipal(identity);
        //    return principal.IsInRole(role);
        //}
        //public bool ValidateApplicationUser()
        //{
        //    AQLM2Entities context = new AQLM2Entities();
        //    PiloteRepositories pilote = new PiloteRepositories(context);
        //    bool validUser = false;

        //    // if you want to do encryption, I recommend that you encrypt the password 
        //    // here so that you don't have to mess with the LINQ query below, but you 
        //    // can still do a direct comparison.

        //    try
        //    {
                

        //        // query the file with LINQ - this query only returns one record from 
        //        var userElement =
        //            pilote.Get(u => u.matricule.Equals(LoginHome.Text) && u.pwd.Equals(motdepasse.Text))
        //                .SingleOrDefault();
        //        //var userElement = (from subitem in
        //        //            (from item in Pilote select item)
        //        //                        where subitem.Element("name").Value.ToLower() == userName.ToLower()
        //        //                        && subitem.Element("password").Value == password
        //        //                        select subitem).SingleOrDefault();

        //        // if you get here without an exception, and if the returned XElement isn't null
        //        // then the user is valid
        //        validUser = (userElement != null);
        //    }

        //    catch (Exception ex)
        //    {
        //        if (ex != null) { MessageBox.Show("login ou mot de passe incorrecte !","Login Failed",MessageBoxButtons.OK,MessageBoxIcon.Stop); }
        //    }

        //    return validUser;
        //}
        private void connecter_Click(object sender, EventArgs e)
        {
            

        }

        private void Login_Load(object sender, EventArgs e)
        {
            AQLM2Entities context=new AQLM2Entities();
            PiloteIntegRepositories pir=new PiloteIntegRepositories(context);
            PiloteFiniRepositories pf=new PiloteFiniRepositories(context);
            PiloteFiniIntegRepositories pfi = new PiloteFiniIntegRepositories(context);
            DateTime dateStart=new DateTime(2016,09,02,11,00,00);
            DateTime dateFinish=new DateTime(2016, 09, 02, 12, 00, 00);
           // Array data;
            var data = pfi.Get(dt => dt.date >= dateStart && dt.date <= dateFinish).Select(dt=>new { dt.matricule,dt.nom,dt.prenom,dt.Fonction}).Distinct().ToList();
           // Console.Write(data.GetValue(0).ToString());
            var cont = pfi.Get(c => c.Fonction.Equals("TQP")).Count();

        if (cont == 4) { 
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
    }
}
