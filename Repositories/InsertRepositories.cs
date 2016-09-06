﻿using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entities;
namespace Repositories
{
    public class InsertRepositories
    {
        TextBox commentaire;
             
        private Button b;
        RadioButton[] listNok;
        RadioButton[] listRb;
        Button valid;
        
        
        String input;
        bool err;
        testEntities context ;


        public InsertRepositories(TextBox commentaire,RadioButton[] listNok,RadioButton[] listRb,Button valid, String input )
        {
            
            
            
            this.listNok = listNok;
            this.listRb = listRb;
            this.commentaire = commentaire;
            this.input = input;
            this.err = false;
            this.valid = valid;


        }
        

        public void checkNokRb()
        {
            
            for (int i = 0; i < listNok.Length; i++)
            {
                if (listNok[i].Checked)
                {
                    string pattern = @"^[A-Za-z]*$";


                    Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                    if (input.Equals(""))
                    {
                        err = true;

                    }
                    if (!m.Success)
                    {
                        err = true;

                    }


                }
            }
        }

        public bool checkRb(bool err)
        {
            bool stat = true;
            bool res;
            for (int i = 0; i < listRb.Length - 2; i+=3)
            {
                if (listRb[i].Checked || listRb[i + 1].Checked || listRb[i + 2].Checked)
                {
                    stat = stat && true;

                }
                else
                {
                    stat = stat && false;
                }
            }
            if (stat == true && err == false)
            {
                res = true;
            }
            else
            {
                res = false;

            }
            return res;
        }

        public void InsertData(String module,String poste, OkDescriptRepositorie desc,ValOKdIntegrepositories repo )
        {

            if (checkRb(err))
            {


                string msg = "";

                if (!String.IsNullOrEmpty(input))
                {
                    msg = input; 

                }

                int dd = desc.Get(bd => bd.poste.Equals(poste) && bd.module.Equals(module)).Select(bd => bd.id).First();
                //incrémentaion d'id
                for (int i = 0; i < listRb.Length - 2; i += 3)
                {

                    ValOKdIntegrtion v = new ValOKdIntegrtion();

                    v.date = DateTime.Now;
                    //v.idLigne = 5;

                    bool b = true;
                    bool c = false;
                    v.ok = c;
                    v.nok = c;
                    v.na = c;
                    if (listRb[i].Checked)
                    {
                        v.ok = b;
                        v.idDescription = dd;
                        dd++;
                        repo.Insert(v);
                    }
                    else if (listRb[i + 1].Checked)
                    {


                        v.nok = b;
                        v.idDescription = dd;
                        dd++;
                        v.commentaire = msg;
                        repo.Insert(v);


                    }
                    else
                    {
                        v.na = b;
                        v.idDescription = dd;
                        dd++;
                        repo.Insert(v);
                    }


                }
                if (err == false)
                {
                    valid.Enabled = false;
                    MessageBox.Show("Succés validation !","Validation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("S'il vous plait remplir les chaps ci-dessus");
                }
            }
            else
            {
                MessageBox.Show("S'il vous plait remplir les chaps ci-dessus");
            }

        }
    }
}
