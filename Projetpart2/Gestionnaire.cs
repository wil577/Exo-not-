using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{
    public class Gestionnaire
    {
        public string Identifiant { get; set; }
        public string Type { get; set; }
        public int NbTransaction { get; set; }
        public List<Compte> Compte { get; set; }
        public Gestionnaire(string identifiant, string type, int nbTransaction, List<Compte> compte)
        {
            Identifiant = identifiant;
            Type = type;
            NbTransaction = nbTransaction;
            Compte = compte;
        }

        public static List<Gestionnaire> ReadGstnFile(string trxnPath)
        {
            List<Gestionnaire> gestionnaire = new List<Gestionnaire>();
            List<Compte> compte = new List<Compte>();
            //prendre les valeurs d'entrées du fichier
            using (StreamReader fichierEntree = new StreamReader(trxnPath))
            {
                while (!fichierEntree.EndOfStream)
                {
                    string ligneFichierEntree = fichierEntree.ReadLine();
                    //les mettre dans un tableau
                    //Séparer les champs
                    string[] ligne1 = ligneFichierEntree.Split(';');

                    Gestionnaire a = new Gestionnaire(ligne1[0], ligne1[1], int.Parse(ligne1[2]), compte);
                    gestionnaire.Add(a);
                }
            }
            return gestionnaire;
        }
    }
}