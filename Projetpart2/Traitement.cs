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
             *et date correspond à celle de souscription
             ********* Cloture de compte si :  *******************
             *Champ sortie renseigné 
             *et date correspond à celle de résiliation
             ********* Echange de compte si : *****************
             *les deux champs sont renseignés 
             *et date correspond à la date de transfert
            */
            
            foreach (var compte in listCompte_Transaction)
            {
                if(compte.Type == "1")
                {
                    foreach(var gstn in listGstn)
                    {
                        if(gstn.Identifiant == compte.Entrée)
                        {
                            //Compte_Transaction exp = listCompte_Transaction.Exists(x => x.Identifiant.Equals(item.Identifiant));

                            Console.WriteLine(compte.Identifiant + "ECRIT");
                            Compte c = new Compte(compte.Identifiant, compte.Date, compte.SoldeIni, compte.Entrée, compte.Sortie);
                            gstn.Compte.Add(c);
                            //listCompte.Add(c);
                            results.Add($"{compte.Identifiant};OK");
                            //fichierSortieOpe.WriteLine(item.Identifiant + ";" + "OK");
                        }
                        
                    }
                        listCompte.Clear();
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