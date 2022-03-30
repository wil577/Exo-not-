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
        public int Identifiant { get; set; }
        public string Type { get; set; }
        public int NbTransaction { get; set; }
        public Gestionnaire(int identifiant, string type, int nbTransaction)
        {
            Identifiant = identifiant;
            Type = type;
            NbTransaction = nbTransaction;
        }

        public static List<Gestionnaire> ReadGstnFile(string trxnPath)
        {
            List<Gestionnaire> gestionnaire = new List<Gestionnaire>();
            //prendre les valeurs d'entrées du fichier
            using (StreamReader fichierEntree = new StreamReader(trxnPath))
            {
                while (!fichierEntree.EndOfStream)
                {
                    string ligneFichierEntree = fichierEntree.ReadLine();
                    //les mettre dans un tableau
                    //Séparer les champs
                    string[] ligne1 = ligneFichierEntree.Split(';');

                    Gestionnaire a = new Gestionnaire(int.Parse(ligne1[0]), ligne1[1], int.Parse(ligne1[2]));
                    gestionnaire.Add(a);
                }
            }
            return gestionnaire;
        }
    }
}