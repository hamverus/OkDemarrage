﻿using System;
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
        testEntities context ;
        private PiloteIntegRepositories pir; 
        private PiloteFiniRepositories pf;
        private PiloteFiniIntegRepositories pfi;
        public Login()
        {
            InitializeComponent();
            context = new testEntities();
             pir = new PiloteIntegRepositories(context);
             pf = new PiloteFiniRepositories(context);
             pfi = new PiloteFiniIntegRepositories(context);
        }
        private void Login_Load(object sender, EventArgs e)
        {
             pir = new PiloteIntegRepositories(context);
             pf = new PiloteFiniRepositories(context);
             pfi = new PiloteFiniIntegRepositories(context);

            DateTime dateStart = new DateTime(2016, 09, 05, 12, 05, 00);
            DateTime dateFinish = new DateTime(2016, 09, 05, 12, 50, 00);

            displayList(dateStart, dateFinish, 3, "TQP");
            displayList(dateFinish, dateStart, 16, "CE");

        }

        //public bool UserInCustomRole(string role)
        //{
        //    WindowsIdentity identity = WindowsIdentity.GetCurrent();
        //    WindowsPrincipal principal = new WindowsPrincipal(identity);
        //    return principal.IsInRole(role);
        //}
        //public bool ValidateApplicationUser()
        //{
        //    testEntities context = new testEntities();
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
        private void displayList(DateTime dateStart,DateTime dateFinish,int test,String fonction)
        {
            
            try
            {

           
            // Array data;
            var data =pfi.Get(dt => dt.date >= dateStart  && dt.date <= dateFinish).Select(dt => new { dt.matricule, dt.nom, dt.prenom, dt.Fonction }).Distinct().ToList();
                // Console.Write(data.GetValue(0).ToString());
            
            var cont = pfi.Get(c => c.Fonction.Equals(fonction)).Count();

            if ((cont == test)&& (data!=null))
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
            catch (Exception e)
            {

                
            }
        }


        private void connecter_Click_1(object sender, EventArgs e)
        {
             


           
            bool validUser = false;
           
            if(!(String.IsNullOrEmpty(LoginHome.Text) ||String.IsNullOrEmpty(motdepasse.Text)))
              {


          var  userElement =pir.Get(u => u.matricule.Equals(LoginHome.Text) && u.pwd.Equals(motdepasse.Text)).SingleOrDefault();
                //userElement = pir.Get().First();

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
                        MessageBox.Show("login ou mot de passe incorrecte !", "Login Failed", MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("login ou mot de passe incorrecte !", "Login Failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
       else
        {

               MessageBox.Show("les champs sont vides!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              }
           
        }
    }
}
