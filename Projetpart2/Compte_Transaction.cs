using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{

    public class Compte_Transaction
    {
        public int Identifiant { get; set; }
        public DateTime Date { get; set; }
        public double SoldeIni { get; set; }
        public int Entrée { get; set; }
        public int Sortie { get; set; }
        public string Type { get; set; }
        public Compte_Transaction(int identifiant, DateTime date, double soldeIni, int entrée, int sortie, string type)
        {
            Identifiant = identifiant;
            Date = date;
            SoldeIni = soldeIni;
            Entrée = entrée;
            Sortie = sortie;
            Type = type;
        }

        public static List<Compte_Transaction> ReadAcctFile(string acctPath, string trxnPath)
        {
            List<Compte_Transaction> listCompte = new List<Compte_Transaction>();

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
                    /*foreach (var item in listCompte)
                    {
                        if (int.Parse(ligne[0]) == item.Identifiant)
                        {
                            isUnique = false;
                        }
                    }*/
                    //isUnique = listCompte.Any(compte => compte.Numero.Equals(ligne[0]));
                    if (!string.IsNullOrWhiteSpace(ligne[2]))
                    {
                        double.TryParse(ligne[2].Replace('.', ','), out solde);
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

                    //if (isUnique && solde >= 0)
                    //{
                    Compte_Transaction c = new Compte_Transaction(int.Parse(ligne[0]), DateTime.Parse(ligne[1]), solde, entrée, sortie, "1");
                    listCompte.Add(c);
                    //}
                }
            }

            using (StreamReader fichierEntree = new StreamReader(trxnPath))
            {
                while (!fichierEntree.EndOfStream)
                {
                    string ligneFichierEntree = fichierEntree.ReadLine();
                    //les mettre dans un tableau
                    //Séparer les champs
                    string[] ligne1 = ligneFichierEntree.Split(';');

                    Compte_Transaction c = new Compte_Transaction(int.Parse(ligne1[0]), DateTime.Parse(ligne1[1]), double.Parse(ligne1[2]), int.Parse(ligne1[3]), int.Parse(ligne1[4]), "2");
                    listCompte.Add(c);
                }
            }
            Console.WriteLine("ID   DATE            Solde  E  S  TYPE");
            foreach (Compte_Transaction compte in listCompte)
            {
                Console.WriteLine(compte.Identifiant + " " + compte.Date + " " + compte.SoldeIni + "  " + compte.Entrée + "  " + compte.Sortie + "  " + compte.Type);

            }
            return listCompte;
        }
    }
}