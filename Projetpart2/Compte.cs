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
        public int Identifiant { get; set; }
        public DateTime Date { get; set; }
        public double SoldeIni { get; set; }
        public int Entrée { get; set; }
        public int Sortie { get; set; }
        public Compte(int identifiant, DateTime date, double soldeIni,int entrée, int sortie)
        {
            Identifiant = identifiant;
            Date = date;
            SoldeIni = soldeIni;
            Entrée = entrée;
            Sortie = sortie;
        }

        public static Dictionary<int, Compte> ReadAcctFile(string acctPath)
        {
            Dictionary<int ,Compte> listCompte = new Dictionary<int, Compte>();

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
                    int sortie;
                    int entrée;
                    string[] ligne = ligneFichierEntree.Split(';');
                    foreach (var item in listCompte)
                    {
                        if (int.Parse(ligne[0]) == item.Value.Identifiant)
                        {
                            isUnique = false;
                        }
                    }
                    //isUnique = listCompte.Any(compte => compte.Numero.Equals(ligne[0]));
                    if (!string.IsNullOrWhiteSpace(ligne[2]))
                    {
                        double.TryParse(ligne[2].Replace('.',','), out solde);
                    }
                    else
                    {
                        solde = 0;
                    }

                    //gestion espace pour l'entrée
                    if (!string.IsNullOrWhiteSpace(ligne[3]))
                    {
                        int.TryParse(ligne[3].Replace('.', ','), out entrée);
                    }
                    else
                    {
                        entrée = 0;
                    }

                    //gestion espace pour la sortie
                    if (!string.IsNullOrWhiteSpace(ligne[4]))
                    {
                        int.TryParse(ligne[4].Replace('.', ','), out sortie);
                    }
                    else
                    {
                        sortie = 0;
                    }

                    if (isUnique && solde >= 0)
                    {
                        Compte c = new Compte(int.Parse(ligne[0]), DateTime.Parse(ligne[1]),solde, entrée, sortie);
                        listCompte.Add(int.Parse(ligne[0]),c);
                    }
                }
            }
            return listCompte;
        }
    }
}