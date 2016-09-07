using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entities;

namespace Repositories
{
    public class InsertRepositories
    {
        private  string dateNow;
        private EquipeRepositories equipeRepository;
        private String input;
        private RadioButton[] listNok;
        private RadioButton[] listRb;
        private Button valid;
        private Button b;
        private TextBox commentaire;
        private AQLM2Entities context;
        private DateTime dateDebutRecherche;
        private DateTime dateFinEquipe;
        private PiloteIntegRepositories pil;
        private PiloteFiniIntegration pilInsert;
        private PiloteFiniIntegRepositories pilr;
        
        private bool err;

        public InsertRepositories(TextBox commentaire, RadioButton[] listNok, RadioButton[] listRb, Button valid,
            String input)
        {
            this.listNok = listNok;
            this.listRb = listRb;
            this.commentaire = commentaire;
            this.input = input;
            err = false;
            this.valid = valid;
            context = new AQLM2Entities();
            equipeRepository = new EquipeRepositories(context);
            pil = new PiloteIntegRepositories(context);
            pilr = new PiloteFiniIntegRepositories(context);
            pilInsert = new PiloteFiniIntegration();
            dateNow = DateTime.Now.Date.ToString("d");
        }

        public InsertRepositories()
        {
            context = new AQLM2Entities();
            equipeRepository = new EquipeRepositories(context);
            pil = new PiloteIntegRepositories(context);
            pilr = new PiloteFiniIntegRepositories(context);
            pilInsert = new PiloteFiniIntegration();
            dateNow = DateTime.Now.Date.ToString("d");
        }
        //Vérifier les radio button non ok si sont cochés
        //Vérifier le commentaire si c'est à la forme du chaine du caractaire 
        public bool checkNokRb(bool err)
        {
            for (var i = 0; i < listNok.Length; i++)
            {
                if (listNok[i].Checked)
                {
                    var pattern = @"\w+\d*\s*";


                    var m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
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
            return err;
        }
        //Vérifier si les radio buttion sont cochés
        public bool checkRb(bool err)
        {
            var stat = true;
            bool res;
            for (var i = 0; i < listRb.Length - 2; i += 3)
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
            if (stat && checkNokRb(err) == false)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }

        public void insertPiloteFini(String mat,String navigationpage)
        {
            var pl = pil.Get(b => b.matricule.Equals(mat)).SingleOrDefault();
            pilInsert.matricule = pl.matricule;
            pilInsert.nom = pl.nom;
            pilInsert.prenom = pl.prenom;
            pilInsert.Fonction = pl.poste;
            pilInsert.date = DateTime.Now;
            pilInsert.Poste = navigationpage;
        }
        //methode d'insertion 
        public void InsertData(DateTime dateDebut, String module, String poste, OkDescriptRepositorie desc,
            ValOKdIntegrepositories repo)
        {    
            if (checkRb(err))//Si les radio button sont cochés
            {
                var msg = "";

                if (!String.IsNullOrEmpty(input))//si le champs commentaire n'est pas vide
                {
                    msg = input;
                }
                //récuperer l'id de la  premiere contrainte  
                var dd = desc.Get(bd => bd.poste.Equals(poste) && bd.module.Equals(module)).Select(bd => bd.id).First();
                
                for (var i = 0; i < listRb.Length - 2; i += 3)
                {
                    var v = new ValOKdIntegrtion();//Crée nouveau valeur ok description

                    v.date = DateTime.Now;
                    v.equipe = getEquipe(dateDebut);
                    //v.idLigne = 5;

                    var b = true;
                    var c = false;
                    v.ok = c;
                    v.nok = c;
                    v.na = c;
                    if (listRb[i].Checked) //si le chamops ok est cochés
                    {
                        v.ok = b;
                        
                    }
                    else if (listRb[i + 1].Checked)//si le chamops non ok est cochés
                    {
                        v.nok = b;
                        
                        v.commentaire = msg;
                        
                    }
                    else //si le chamops non appliqué est cochés
                    {
                        v.na = b;
                        
                    }
                    v.idDescription = dd;
                    dd++;//incrémentaion d'id
                    repo.Insert(v);
                }
                if (checkNokRb(err) == false)
                {   
                    valid.Enabled = false;
                    MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("S'il vous plait remplir les champs commentaire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (checkNokRb(err))
                {
                    MessageBox.Show("S'il vous plait remplir les champs commentaire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { MessageBox.Show("S'il vous plait remplir les champs ci-dessus", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
                
            }
        }

        public string getEquipe(DateTime datedebut)
        {
            var timeDebut = datedebut.ToString("HH:mm:ss tt");
            var t = TimeSpan.Parse(timeDebut);
            var x = equipeRepository.Get(b => b.dateDebut == t).Select(b => b.designation).First();
            return x;
        }

        public DateTime getDateFINEquipe(DateTime datedebut)
        {
            var timeDebut = datedebut.ToString("HH:mm:ss tt");
            var t = TimeSpan.Parse(timeDebut);
            var x = equipeRepository.Get(b => b.dateDebut == t).Select(b => b.dateFin).First();
            dateFinEquipe = DateTime.Parse(dateNow + " " + TimeSpan.Parse(x.ToString()));
            if (datedebut == DateTime.Parse(dateNow + " 15:59:00"))
            {
                dateFinEquipe = dateFinEquipe.AddDays(1);
            }
            return dateFinEquipe;
        }

        public DateTime getDateEquipe()
        {
            var listDateDabutEquipe = equipeRepository.GetAll().Select(b => b.dateDebut).ToList();
            for (var i = 0; i < listDateDabutEquipe.Count; i++)
            {
                var dateEquipe = DateTime.Parse(dateNow + " " + listDateDabutEquipe[i]);
                var dateFinEquipe = getDateFINEquipe(dateEquipe);
                if (dateEquipe == DateTime.Parse(dateNow + " 15:59:00"))
                {
                    dateFinEquipe = dateFinEquipe.AddDays(1);
                }
                if (DateTime.Now >= dateEquipe && DateTime.Now < dateFinEquipe)

                {
                    dateDebutRecherche = dateEquipe;
                }
            }
            return dateDebutRecherche;
        }
    }
}