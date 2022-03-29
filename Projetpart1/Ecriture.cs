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

        /*public static Compte ChercherCompte(List<Compte> listeDesComptes, string identifiant)
        {
            foreach (Compte c in listeDesComptes)
            {
                if (c.Numero == identifiant)
                    return c;
            }
            return null;
        }*/
        public static void Ecriture1(string sttsPath, List<Compte> listCompte, List<Transaction> listTransaction)
        {
            //string ok = "";
            //string[] ok = new string[] { };
            List<string> ok = new List<string>();
            int trNumeroPrec = 0;
            List<Compte> comptePrec = new List<Compte>();
            comptePrec = listCompte;
            int i = -1;

            /*
             * Pour chaque transaction de ma liste:
             *  Effectuer le mouvement
             *  Ecrire la sortie
             * Fin
             */

            foreach (Transaction t in listTransaction)
            {
                Console.WriteLine($"{t.Numero} : {t.Montant}$ de {t.Expéditeur} vers {t.Destinataire}");
                //* Si l'expéditeur est égal à 0: c'est un dépôt: on rajoute le montant au destinataire
                if(t.Montant != 0)
                {
                    if (t.Numero >= trNumeroPrec)
                    {
                        if (t.Destinataire != "0" && t.Expéditeur != "0")
                        {
                            if (listCompte.Any(compte => compte.Numero.Equals(t.Destinataire)) && listCompte.Any(compte => compte.Numero.Equals(t.Expéditeur)))
                            {
                                foreach (Compte c in listCompte)
                                {
                                    if (c.Numero == t.Destinataire)
                                    {
                                        c.Solde += t.Montant;
                                        ok.Add("OK");
                                    }

                                    if (c.Numero == t.Expéditeur)
                                    {
                                        c.Solde -= t.Montant;
                                        ok.Add("OK");
                                    }
                                }
                            }
                            else
                            {
                                ok.Add("KO");
                            }
                        }
                        else if (t.Destinataire == "0" || t.Expéditeur == "0")
                        {
                            foreach (Compte c in listCompte)
                            {
                                if (c.Numero == t.Destinataire)
                                {
                                    c.Solde += t.Montant;
                                    ok.Add("OK");
                                }

                                if (c.Numero == t.Expéditeur)
                                {
                                    c.Solde -= t.Montant;
                                    ok.Add("OK");
                                }
                            }
                        }
                    }
                    else
                    {
                        ok.Add("KO");
                    }
                }
                else
                {
                    ok.Add("KO");
                }
                trNumeroPrec = t.Numero;
                
                Console.WriteLine("Statut des comptes");
                Console.WriteLine("------------------");
                foreach (Compte compte in listCompte)
                {
                    Console.WriteLine(compte.Numero + " " + compte.Solde);

                }
                Console.WriteLine();
            }


            using (StreamWriter fichierSortie = new StreamWriter(sttsPath))
            {
                i = 1;

                foreach (Transaction t in listTransaction)
                {
                    /*
                    foreach (Compte c1 in listCompte)
                    {
                        foreach (Compte c2 in comptePrec)
                        {
                            if (c1.Numero == c2.Numero)
                            {
                                if (c1.Solde != c2.Solde)
                                {
                                    ok = "KO";
                                }
                                else if (c1.Solde == c2.Solde)
                                {
                                    ok = "OK";
                                }
                            }
                        }*/
                    fichierSortie.WriteLine(t.Numero + ";" + ok[i]);
                    i++;
                }
            }
        }
    }
}