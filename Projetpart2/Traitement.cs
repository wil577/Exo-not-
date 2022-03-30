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

            /*ecrire fichier statut comptes : IDENTIFIANT ; STATUT
             *
             *
            */
            using (StreamWriter fichierSortieOpe = new StreamWriter(sttsAcctPath))
            {
                foreach (var item in listCompte_Transaction)
                {
                    if(item.Type == "1")
                    {
                        Console.WriteLine("ECRITURE");
                        fichierSortieOpe.WriteLine(item.Identifiant + ";" + "OK");
                    }
                }
            }

            //Console.WriteLine($"{t.Numero} : {t.Montant}$ de {t.Expediteur} vers {t.Destinataire}");


            Console.WriteLine("Statut des comptes");
                Console.WriteLine("------------------");
                /*foreach (Compte_Transaction compte in listCompte_Transaction)
                {
                    Console.WriteLine(compte.Numero + " " + compte.Solde);

                }*/
                Console.WriteLine();
        }
    }
}