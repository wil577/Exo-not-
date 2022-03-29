using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{

    public class Compte
    {

        public string Numero { get; set; }
        public double Solde { get; set; }
        public Compte(string numero, double solde)
        {
            Numero = numero;
            Solde = solde;
        }



        public static List<Compte> ReadAcctFile(string acctPath)
        {
            List<Compte> compte = new List<Compte>();

            //prendre les valeurs d'entrées du fichier
            using (StreamReader fichierEntree = new StreamReader(acctPath))
            {
                while (!fichierEntree.EndOfStream)
                {
                    string ligneFichierEntree = fichierEntree.ReadLine();
                    //les mettre dans un tableau
                    //Séparer les champs
                    string[] ligne1 = ligneFichierEntree.Split(';');

                    Compte a = new Compte(ligne1[0], double.Parse(ligne1[1]));
                    compte.Add(a);
                    /*if (comptes.ContainsKey(ligne1[1]))
                    {
                        comptes[ligne1[1]].Add(float.Parse(ligne1[2]));
                    }
                    else
                    {
                        comptes.Add(ligne1[1], new List<float>() { float.Parse(ligne1[2]) });
                    }*/
                }
            }

            return compte;

            //throw new NotImplementedException();
        }
    }
}