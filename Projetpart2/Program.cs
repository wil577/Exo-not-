using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetpart1
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            //Fichiers entrée
            string mngrPath = path + @"\Gestionnaires_1.txt";
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            //Fichiers sortie
            string sttsAcctPath = path + @"\StatutOpe_1.txt";
            string sttsTrxnPath = path + @"\StatutTra_1.txt";
            string mtrlPath = path + @"\Metrologie_1.txt";

            Dictionary<int, Compte> cpt = new Dictionary<int, Compte>();
            List<Transaction> tr = new List<Transaction>();
            List<Gestionnaire> gstn = new List<Gestionnaire>();

            cpt = Compte.ReadAcctFile(acctPath);
            tr = Transaction.ReadTrxnFile(trxnPath);
            gstn = Gestionnaire.ReadGstnFile(mngrPath);

            //Ecriture.Ecriture1(sttsPath,cpt, tr);

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}