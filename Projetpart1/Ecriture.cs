using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{
    internal class Ecriture
    {

        public static Compte ChercherCompte(List<Compte> listeDesComptes, string identifiant)
        {
            foreach (Compte c in listeDesComptes)
            {
                if (c.Numero == identifiant)
                    return c;
            }
            return null;
        }
        public static void Ecriture1 (string sttsPath, List<Compte> listCompte, List<Transaction> listTransaction)
        {
            string numero;
            Transaction premierObjet = listTransaction[0];
            string numerDuPremierObjet = premierObjet.Numero;

            /*
             * Pour chaque transaction de ma liste:
             *  Effectuer le mouvement
             *  Ecrire la sortie
             * Fin
             */

            foreach (Transaction t in listTransaction)
            {
                //* Si l'expéditeur est égal à 0: c'est un dépôt: on rajoute le montant au destinataire
                if(t.Expéditeur == "0")
                {
                    foreach (Compte c in listCompte)
                    {
                        if(c.Numero == t.Destinataire)
                        {
                            c.Solde += t.Solde;
                        }
                    }
                }

                if (t.Destinataire == "0")
                {
                    foreach (Compte c in listCompte)
                    {
                        if (c.Numero == t.Destinataire)
                        {
                            c.Solde -= t.Solde;
                        }
                    }
                }
                // Effectuer le mouvement
                // if t.expediteur == 0:
                //   t.destinataire.Add
            }

            /*
             * Opération:
             * Si l'expéditeur est égal à 0: c'est un dépôt: on rajoute le montant au destinataire
             * Si le destinataire est égal à 0 on enlève le montant à l'expéditeur
             */ 

            Transaction a = new Transaction(numero, solde, expéditeur, destinataire);

            using (StreamWriter fichierSortie = new StreamWriter(sttsPath))
            {
                foreach (var numero in Transaction)
                {
                    string lignetransaction = Transaction[3];
                    //les mettre dans un tableau
                    //Séparer les champs

                    
                    transaction.Add(a);
                    if (Transaction[3] = "0")
                }



                foreach (KeyValuePair<string, List<float>> matiere in matieres)
                {
                    float moyenne;
                    float sum = 0;
                    //parcoure matiere.Value pour calculer la moyenne
                    foreach (float note in matiere.Value)
                    {
                        sum += note;
                    }
                    // moyenne = condition ? si c'est vrai : si c'est faux
                    moyenne = matiere.Value.Count == 0 ? 0 : sum / matiere.Value.Count;
                    fichierSortie.WriteLine(matiere.Key + ";" + moyenne);
                }
            }
        }
    }
}