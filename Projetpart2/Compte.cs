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
            List<Compte> listCompte = new List<Compte>();

            //prendre les valeurs d'entrées du fichier
            using (StreamReader fichierEntree = new StreamReader(acctPath))
            {
                while (!fichierEntree.EndOfStream)
                {
                    string ligneFichierEntree = fichierEntree.ReadLine();
                    //les mettre dans un tableau
                    //Séparer les champs
                    bool isUnique = true;
                    double solde;
                    string[] ligne = ligneFichierEntree.Split(';');
                    foreach (var item in listCompte)
                    {
                        if (ligne[0] == item.Numero)
                        {
                            isUnique = false;
                        }
                    }
                    //isUnique = listCompte.Any(compte => compte.Numero.Equals(ligne[0]));
                    if (!string.IsNullOrWhiteSpace(ligne[1]))
                    {
                        double.TryParse(ligne[1].Replace('.',','), out solde);
                    }
                    else
                    {
                        solde = 0;
                    }

                    if (isUnique && solde >= 0)
                    {
                        Compte c = new Compte(ligne[0], solde);
                        listCompte.Add(c);
                    }
                }
            }
            return listCompte;
        }
    }
}