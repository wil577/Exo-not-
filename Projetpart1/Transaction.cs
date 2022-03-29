using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{
    public class Transaction
    {
        public int Numero { get; set; }
        public double Montant { get; set; }
        public string Expéditeur { get; set; }
        public string Destinataire { get; set; }
        public Transaction(int numero, double solde, string expéditeur, string destinataire)
        {
            Numero = numero;
            Montant = solde;
            Expéditeur = expéditeur;
            Destinataire = destinataire;
        }

        public static List<Transaction> ReadTrxnFile(string trxnPath)
        {
            List<Transaction> transaction = new List<Transaction>();
            //prendre les valeurs d'entrées du fichier
            using (StreamReader fichierEntree = new StreamReader(trxnPath))
            {
                while (!fichierEntree.EndOfStream)
                {
                    string ligneFichierEntree = fichierEntree.ReadLine();
                    //les mettre dans un tableau
                    //Séparer les champs
                    string[] ligne1 = ligneFichierEntree.Split(';');

                    Transaction a = new Transaction(int.Parse(ligne1[0]), double.Parse(ligne1[1]), ligne1[2], ligne1[3]);
                    transaction.Add(a);
                }
            }
            return transaction;
        }
    }
}