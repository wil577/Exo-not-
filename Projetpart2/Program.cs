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

            List<Compte_Transaction> cpt = new List<Compte_Transaction>();
            //Dictionary<int, Transaction> tr = new Dictionary<int, Transaction>();
            List<Gestionnaire> gstn = new List<Gestionnaire>();

            cpt = Compte_Transaction.ReadAcctFile(acctPath, trxnPath);
            //tr = Transaction.ReadTrxnFile(trxnPath);
            gstn = Gestionnaire.ReadGstnFile(mngrPath);

            EcritureTr.Traitement(sttsAcctPath,sttsTrxnPath, mtrlPath,cpt,gstn);

            //Ecriture.Ecriture1(sttsPath,cpt, tr);

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}