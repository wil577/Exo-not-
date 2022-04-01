using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{
    internal class EcritureTr
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
        public static void Traitement(string sttsAcctPath, string sttsTrxnPath, string mtrlPath, List<Compte_Transaction> listCompte_Transaction, List<Gestionnaire> listGstn)
        {

            List<string> resultsC = new List<string>();
            List<string> resultsT = new List<string>();
            List<Compte_Transaction> comptePrec = new List<Compte_Transaction>();
            comptePrec = listCompte_Transaction;
            List<Compte> listCompte = new List<Compte>();

            /*ecrire fichier statut comptes : IDENTIFIANT ; STATUT
             ********* Création si compte n'existe pas : ******
             *champ ENTREE renseigné
             *Solde Supérieur ou égal à 0
             *et date correspond à celle de souscription
             ********* Cloture de compte si :  *******************
             *compte existe
             *Champ sortie renseigné 
             *et date correspond à celle de résiliation
             ********* Echange de compte si : *****************
             *les deux champs sont renseignés 
             *et date correspond à la date de transfert
            */

            foreach (Gestionnaire g in listGstn)
            {
                foreach (Compte c in g.Compte)
                {
                    Console.WriteLine($"{g.Identifiant}: POSSEDE : {c.Identifiant}");
                }
            }

            foreach (var compte_Transaction in listCompte_Transaction)
            {
                if (compte_Transaction.Type == "1")
                {
                    if (compte_Transaction.SoldeIni >= 0)
                    {
                        if (!string.IsNullOrEmpty(compte_Transaction.Entrée) && string.IsNullOrEmpty(compte_Transaction.Sortie))
                        {
                            //Création
                            foreach (var gstn in listGstn)
                            {
                                if (gstn.Identifiant.Equals(compte_Transaction.Entrée))
                                {
                                    Console.WriteLine(compte_Transaction.Identifiant + "ECRIT");
                                    Compte c = new Compte(compte_Transaction.Identifiant, compte_Transaction.Date, compte_Transaction.SoldeIni, compte_Transaction.Entrée, compte_Transaction.Sortie, gstn.Identifiant);
                                    gstn.Compte.Add(c);
                                    resultsC.Add($"{compte_Transaction.Identifiant};OK");
                                    break;
                                }
                            }   
                        }
                    }
                    else
                    {
                        resultsC.Add($"{compte_Transaction.Identifiant};KO");
                        break;
                    }

                    if (string.IsNullOrEmpty(compte_Transaction.Entrée) && !string.IsNullOrEmpty(compte_Transaction.Sortie))
                    {
                        bool isOk = false;
                        foreach (var gstn in listGstn)
                        {
                            for (int i = 0; i < gstn.Compte.Count && !isOk; i++)
                            {
                                if (gstn.Compte[i].Identifiant == compte_Transaction.Identifiant)
                                {
                                    if (gstn.Compte[i].IdGestionnaire.Equals(compte_Transaction.Sortie))
                                    {
                                        isOk = true;
                                        Console.WriteLine(compte_Transaction.Identifiant + "SUPRRESSION");
                                        gstn.Compte.RemoveAt(i);
                                    }
                                }
                            }
                        }
                        if (isOk)
                        {
                            resultsC.Add($"{compte_Transaction.Identifiant};OK");

                        }
                        else
                        {
                            Console.WriteLine(compte_Transaction.Identifiant + "SUPRRESSION NON");
                            resultsC.Add($"{compte_Transaction.Identifiant};KO");
                        }
                    }

                    if (!string.IsNullOrEmpty(compte_Transaction.Entrée) && !string.IsNullOrEmpty(compte_Transaction.Sortie))
                    {
                        bool isOk = false;
                        foreach (var gstn in listGstn)
                        {
                            for (int i = 0; i < gstn.Compte.Count && !isOk; i++)
                            {
                                if (compte_Transaction.Sortie == gstn.Identifiant && compte_Transaction.Entrée == gstn.Compte[i].IdGestionnaire)
                                {
                                    if (gstn.Compte[i].Identifiant == compte_Transaction.Identifiant)
                                    {
                                        isOk = true;
                                        gstn.Compte.RemoveAt(i);
                                        Compte c = new Compte(compte_Transaction.Identifiant, compte_Transaction.Date, compte_Transaction.SoldeIni, compte_Transaction.Entrée, compte_Transaction.Sortie, gstn.Identifiant);
                                        gstn.Compte.Add(c);
                                        Console.WriteLine(compte_Transaction.Identifiant + "CESSION");
                                    }
                                }
                            }
                        }
                        if (isOk)
                        {
                            resultsC.Add($"{compte_Transaction.Identifiant};OK");
                        }
                        else
                        {
                            resultsC.Add($"{compte_Transaction.Identifiant};KO");
                        }
                    }
                }
                else if (compte_Transaction.Type == "2")
                {
                    //TODO: Traiter transaction
                }
            }



            //Console.WriteLine($"{t.Numero} : {t.Montant}$ de {t.Expediteur} vers {t.Destinataire}");


            Console.WriteLine("Statut des comptes");
            Console.WriteLine("------------------");
            /*foreach (Compte_Transaction compte in listCompte_Transaction)
            {
                Console.WriteLine(compte.Numero + " " + compte.Solde);

            }*/

            using (StreamWriter fichierSortie = new StreamWriter(sttsAcctPath))
            {
                foreach (string r in resultsC)
                {
                    fichierSortie.WriteLine(r);
                }
            }

            using (StreamWriter fichierSortie = new StreamWriter(sttsTrxnPath))
            {
                foreach (string r in resultsT)
                {
                    fichierSortie.WriteLine(r);
                }
            }

            foreach (Gestionnaire g in listGstn)
            {
                foreach (Compte c in g.Compte)
                {
                    Console.WriteLine($"{g.Identifiant}: POSSEDE : {c.Identifiant}");
                }
            }


            Console.WriteLine();
        }
    }
}