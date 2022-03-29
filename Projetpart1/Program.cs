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
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";

            List<Compte> cpt = new List<Compte>();
            List<Transaction> tr = new List<Transaction>();

            cpt = Compte.ReadAcctFile(acctPath);
            tr = Transaction.ReadTrxnFile(trxnPath);

            Ecriture.Ecriture1(sttsPath,cpt, tr);

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}