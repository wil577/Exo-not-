using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{

    public class Compte_Transaction : IComparable<Compte_Transaction>
    {
        public string Identifiant { get; set; }
        public DateTime Date { get; set; }
        public double SoldeIni { get; set; }
        public string Entrée { get; set; }
        public string Sortie { get; set; }
        public string Type { get; set; }
        public Compte_Transaction(string identifiant, DateTime date, double soldeIni, string entrée, string sortie, string type)
        {
            Identifiant = identifiant;
            Date = date;
            SoldeIni = soldeIni;
            Entrée = entrée;
            Sortie = sortie;
            Type = type;
        }

        public int CompareTo(Compte_Transaction other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            // The temperature comparison depends on the comparison of
            // the underlying Double values.
            return Date.CompareTo(other.Date);
        }

        // Define the is greater than operator.
        public static bool operator >(Compte_Transaction operand1, Compte_Transaction operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        // Define the is less than operator.
        public static bool operator <(Compte_Transaction operand1, Compte_Transaction operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(Compte_Transaction operand1, Compte_Transaction operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(Compte_Transaction operand1, Compte_Transaction operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
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
                    string[] ligne = ligneFichierEntree.Split(';');
                    //gestion espace/vide pour solde
                    DateTime date = !string.IsNullOrWhiteSpace(ligne[1]) && DateTime.TryParse(ligne[1], out DateTime dt) ? dt : DateTime.MinValue;
                    //gestion espace/vide pour solde
                    double solde = !string.IsNullOrWhiteSpace(ligne[2]) && double.TryParse(ligne[2], out double d) ? d : 0;
                    //gestion espace/vide pour l'entrée
                    string entrée = !string.IsNullOrWhiteSpace(ligne[3]) ? ligne[3] : string.Empty;
                    //gestion espace/vide pour la sortie
                    string sortie = !string.IsNullOrWhiteSpace(ligne[4]) ? ligne[4] : string.Empty;

                    //entrée = ligne[3];
                    //sortie = ligne[4];
                    /*foreach (var item in listCompte)
                    {
                        if (int.Parse(ligne[0]) == item.Identifiant)
                        {
                            isUnique = false;
                        }
                    }*/
                    //isUnique = listCompte.Any(compte => compte.Numero.Equals(ligne[0]));
                    //if (!string.IsNullOrWhiteSpace(ligne[2]))
                    //{
                    //    double.TryParse(ligne[2].Replace('.', ','), out solde);
                    //}
                    //else
                    //{
                    //    solde = 0;
                    //}

                    //gestion espace pour la sortie
                    //if (!string.IsNullOrWhiteSpace(ligne[4]))
                    //{
                    //    //int.TryParse(ligne[4].Replace('.', ','), out sortie);
                    //}
                    //else
                    //{
                    //    sortie = null;
                    //}

                    //if (isUnique && solde >= 0)
                    //{
                    Compte_Transaction c = new Compte_Transaction(ligne[0], date, solde, entrée, sortie, "1");
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

                    Compte_Transaction c = new Compte_Transaction(ligne1[0], DateTime.Parse(ligne1[1]), double.Parse(ligne1[2]), ligne1[3], ligne1[4], "2");
                    listCompte.Add(c);
                }
            }
            Console.WriteLine("ID   DATE            Solde  E  S  TYPE");
            listCompte.Sort();
            foreach (Compte_Transaction compte in listCompte)
            {
                Console.WriteLine(compte.Identifiant + " " + compte.Date + " " + compte.SoldeIni + "  " + compte.Entrée + "  " + compte.Sortie + "  " + compte.Type);
            }
            return listCompte;
        }
    }
}