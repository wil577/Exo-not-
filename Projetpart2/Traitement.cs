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

            List<string> results = new List<string>();
            int trNumeroPrec = 0;
            List<Compte_Transaction> comptePrec = new List<Compte_Transaction>();
            comptePrec = listCompte_Transaction;
            List<Compte> listCompte = new List<Compte>();

            /*foreach (var item in listCompte_Transaction)
            {
                if (item.Type == "1")
                {
                    listCompte.Add(item);
                }
            }*/

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
            foreach (var compte_Transaction in listCompte_Transaction)
            {
                if (compte_Transaction.Type == "1")
                {
                    //TODO: Traiter opération
                    if (compte_Transaction.SoldeIni >= 0)
                    {
                        //Création
                        if (!string.IsNullOrEmpty(compte_Transaction.Entrée) && string.IsNullOrEmpty(compte_Transaction.Sortie))
                        {
                            foreach (var gstn in listGstn)
                            {
                                if (gstn.Identifiant.Equals(compte_Transaction.Entrée))
                                {
                                    Console.WriteLine(compte_Transaction.Identifiant + "ECRIT");
                                    Compte c = new Compte(compte_Transaction.Identifiant, compte_Transaction.Date, compte_Transaction.SoldeIni, compte_Transaction.Entrée, compte_Transaction.Sortie, gstn.Identifiant);
                                    //listCompte.Add(c);
                                    gstn.Compte.Add(c);
                                    results.Add($"{compte_Transaction.Identifiant};OK");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        results.Add($"{compte_Transaction.Identifiant};KO");
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
                                        //Compte c = new Compte(compte_Transaction.Identifiant, compte_Transaction.Date, compte_Transaction.SoldeIni, compte_Transaction.Entrée, compte_Transaction.Sortie, compte_Transaction.Sortie);
                                        //listCompte.RemoveAll(x=>x.Identifiant.Equals(compte_Transaction.Sortie));
                                        gstn.Compte.RemoveAt(i);
                                    }
                                    //else
                                    //{
                                    //    Console.WriteLine(compte_Transaction.Identifiant + "SUPRRESSION NON");
                                    //    results.Add($"{compte_Transaction.Identifiant};KO");
                                    //    //break;
                                    //}
                                }
                            }
                        }
                        if (isOk)
                        {
                            results.Add($"{compte_Transaction.Identifiant};OK");

                        }
                        else
                        {
                            Console.WriteLine(compte_Transaction.Identifiant + "SUPRRESSION NON");
                            results.Add($"{compte_Transaction.Identifiant};KO");
                            //break;
                        }
                    }

                    if (!string.IsNullOrEmpty(compte_Transaction.Entrée) && !string.IsNullOrEmpty(compte_Transaction.Sortie))
                    {
                        foreach (var gstn in listGstn)
                        {
                            for (int i = 0; i < gstn.Compte.Count; i++)
                            {
                                if (compte_Transaction.Sortie == gstn.Identifiant)
                                {
                                    if (gstn.Compte[i].Identifiant == compte_Transaction.Identifiant)
                                    {
                                        if (gstn.Compte[i].IdGestionnaire.Equals(compte_Transaction.Sortie))
                                        {
                                            Console.WriteLine(compte_Transaction.Identifiant + "CESSION");
                                            //Compte c = new Compte(compte_Transaction.Identifiant, compte_Transaction.Date, compte_Transaction.SoldeIni, compte_Transaction.Entrée, compte_Transaction.Sortie, compte_Transaction.Sortie);
                                            //listCompte.RemoveAll(x=>x.Identifiant.Equals(compte_Transaction.Sortie));
                                            gstn.Compte.RemoveAt(i);
                                            results.Add($"{compte_Transaction.Identifiant};OK");
                                        }
                                        else
                                        {
                                            Console.WriteLine(compte_Transaction.Identifiant + "CESSION NON");
                                            results.Add($"{compte_Transaction.Identifiant};KO");
                                            //break;
                                        }
                                    }
                                }

                            }
                        }
                    }




                    //if (gstn.Identifiant == compte_Transaction.Entrée)
                    //{
                    //Compte_Transaction exp = listCompte_Transaction.Exists(x => x.Identifiant.Equals(item.Identifiant));

                    //fichierSortieOpe.WriteLine(item.Identifiant + ";" + "OK");
                    //}
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
                foreach (string r in results)
                {
                    fichierSortie.WriteLine(r);
                }
            }
            Console.WriteLine();
        }
    }
}