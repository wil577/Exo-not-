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

            List<string> results = new List<string>();
            int trNumeroPrec = 0;
            List<Compte> comptePrec = new List<Compte>();
            comptePrec = listCompte;

            /*
             * Pour chaque transaction de ma liste:
             *  Effectuer le mouvement
             *  Ecrire la sortie
             * Fin
             */

            foreach (Transaction t in listTransaction)
            {
                Console.WriteLine($"{t.Numero} : {t.Montant}$ de {t.Expediteur} vers {t.Destinataire}");
                //* Si l'expéditeur est égal à 0: c'est un dépôt: on rajoute le montant au destinataire
                if (t.Montant > 0)
                {
                    if (t.Numero > trNumeroPrec)
                    {
                        if (t.Destinataire != "0" && t.Expediteur != "0")
                        {
                            if (listCompte.Any(compte => compte.Numero.Equals(t.Destinataire)) && listCompte.Any(compte => compte.Numero.Equals(t.Expediteur)))
                            {
                                Compte exp = listCompte.Find(x => x.Numero.Equals(t.Expediteur));
                                Compte dst = listCompte.Find(x => x.Numero.Equals(t.Destinataire));
                                if (t.Montant > 0 && exp.Solde - t.Montant >= 0)
                                {
                                    exp.Solde -= t.Montant;
                                    dst.Solde += t.Montant;
                                    Console.WriteLine(t.Numero + "OK 1");
                                    results.Add($"{t.Numero};OK");
                                }
                            }
                            else
                            {
                                Console.WriteLine(t.Numero + "KO 1");
                                results.Add($"{t.Numero};KO");
                            }
                        }
                        else if (t.Destinataire == "0" || t.Expediteur != "0")
                        {
                            Compte exp = listCompte.Find(x => x.Numero.Equals(t.Expediteur));
                            if (exp != null && exp.Solde - t.Montant >= 0)
                            {
                                exp.Solde -= t.Montant;
                                results.Add($"{t.Numero};OK");
                            }
                            else
                            {
                                Console.WriteLine(t.Numero + "KO 1");
                                results.Add($"{t.Numero};KO");
                            }
                        }
                        else if (t.Destinataire != "0" || t.Expediteur == "0")
                        {
                            Compte dst = listCompte.Find(x => x.Numero.Equals(t.Destinataire));
                            if (dst != null && t.Montant > 0)
                            {
                                dst.Solde += t.Montant;
                                results.Add($"{t.Numero};OK");
                            }
                            else
                            {
                                Console.WriteLine(t.Numero + "KO 1");
                                results.Add($"{t.Numero};KO");
                            }
                        }
                        else
                        {
                            Console.WriteLine(t.Numero + "KO 1");
                            results.Add($"{t.Numero};KO");
                        }
                    }
                    else
                    {
                        Console.WriteLine(t.Numero + "KO 3");
                        results.Add($"{t.Numero};KO");
                    }
                    if (t.Numero > trNumeroPrec)
                    {
                        trNumeroPrec = t.Numero;
                    }
                }
                else
                {
                    Console.WriteLine(t.Numero + "KO 4");
                    results.Add($"{t.Numero};KO");
                }

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
                foreach (string r in results)
                {
                    fichierSortie.WriteLine(r);
                }
            }
        }
    }
}